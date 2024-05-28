using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Remoting.Messaging;

namespace EXESpy
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            args = new string[1] { "D:\\Important Data\\Programming Projects ASM\\HelloASM - Template\\Program.exe" };

            int returnCode = 0;
            if (args is null || args.Length <= 0 || args.Length > 1)
            {
                BC.Log("USAGE: ExeSpy pathToExecutable");
                returnCode = 1;
            }
            else
            {
                InspectExe(args[0]);
            }

            BC.Log("Press any key to exit...");
            Stopwatch stopwatch = Stopwatch.StartNew();
            while (true)
            {
                Console.ReadKey(true);
                if (stopwatch.ElapsedTicks > 10000000)
                {
                    break;
                }
            }
            return returnCode;
        }
        public static void InspectExe(string exePath)
        {
            FileStream fileStream = File.Open(exePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            byte[] buffer = new byte[fileStream.Length];
            fileStream.Read(buffer, 0, buffer.Length);
            fileStream.Close();
            fileStream.Dispose();
            TinyStream stream = new TinyStream(buffer);
            InspectExe(stream);
        }
        public static void InspectExe(TinyStream stream)
        {
            MZHeaderV2 mzHeaderV2 = MZHeaderV2.Parse(stream);
            mzHeaderV2.Print();

            if (stream.offset != mzHeaderV2.PEHeaderStart)
            {
                byte[] DOSStub = new byte[mzHeaderV2.PEHeaderStart - stream.offset];
                Array.Copy(stream.buffer, stream.offset, DOSStub, 0, DOSStub.Length);
                stream.offset = (int)mzHeaderV2.PEHeaderStart;

                BC.Log("DOS Stub:");
                BC.Log(DF.AsASCII(DOSStub));
                BC.NL();
            }

            PEHeader peHeader = PEHeader.Parse(stream);
            peHeader.Print();

            int offsetAfterPEOptionalHeader = stream.offset + peHeader.SizeOfOptionalHeader;
            if (peHeader.SizeOfOptionalHeader > 0)
            {
                PEOptionalHeader peOptionalHeader = PEOptionalHeader.Parse(stream);
                peOptionalHeader.Print();
            }

            if (stream.offset != offsetAfterPEOptionalHeader)
            {
                byte[] spacerBytes = new byte[offsetAfterPEOptionalHeader - stream.offset];
                Array.Copy(stream.buffer, stream.offset, spacerBytes, 0, spacerBytes.Length);
                stream.offset = offsetAfterPEOptionalHeader;

                BC.Log("Spacer Bytes:");
                BC.Log(DF.AsHex(spacerBytes));
                BC.NL();
            }

            PESectionHeader[] peSectionHeaders = new PESectionHeader[peHeader.NumberOfSections];
            for (int i = 0; i < peSectionHeaders.Length; i++)
            {
                peSectionHeaders[i] = PESectionHeader.Parse(stream);
                peSectionHeaders[i].Print(i);
            }

            for (int i = 0; i < peSectionHeaders.Length; i++)
            {
                if (7168 >= stream.offset && 7168 <= stream.offset + peSectionHeaders[i].SizeOfRawData)
                {

                }
                byte[] sectionBuffer = new byte[peSectionHeaders[i].SizeOfRawData];
                Array.Copy(stream.buffer, stream.offset, sectionBuffer, 0, sectionBuffer.Length);
                stream.offset += sectionBuffer.Length;
                TinyStream sectionStream = new TinyStream(sectionBuffer);
                InspectSection(sectionStream, peSectionHeaders[i]);
            }
        }
        public static void InspectSection(TinyStream stream, PESectionHeader header)
        {
            if (header.Name == ".text")
            {
                TextSegment.ParseAndPrint(stream, header);
            }
            else if (header.Name == ".data")
            {
                DataSegment.ParseAndPrint(stream, header);
            }
            else if (header.Name == ".rdata")
            {
                RDataSegment.ParseAndPrint(stream, header);
            }else
            {
                BC.Log($"Unknown Section {header.Name} (ASCII):");
                BC.Log(DF.AsASCII(stream.buffer));
                BC.NL();
            }
        }
    }
}