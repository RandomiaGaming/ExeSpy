using System;
using System.Diagnostics;
using System.IO;

namespace ExeSpy
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            args = new string[1] { "D:\\Important Data\\Programming Projects ASM\\HelloASM - Template\\Ret69.exe" }; // ASM return 69
            // args = new string[1] { "D:\\Important Data\\Programming Projects ASM\\HelloASM - Template\\HelloWorld.exe" }; // ASM Hello World
            // args = new string[1] { "D:\\School\\WinSeExclusion\\Project5\\Debug\\Project.exe" }; // ASM CS Homework
            // args = new string[1] { "D:\\Important Data\\Programming Projects ASM\\EXESpy\\bin\\Debug\\EXESpy.exe" }; // C# ExeSpy
            // args = new string[1] { "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe" }; // Google Chrome

            int returnCode = 0;
            if (args is null || args.Length <= 0 || args.Length > 1)
            {
                Print.Line("USAGE: ExeSpy pathToExecutable");
                returnCode = 1;
            }
            else
            {
                InspectExe(args[0]);
            }

            if (Debugger.IsAttached)
            {
                Print.Line("Press any key to exit...");
                Stopwatch stopwatch = Stopwatch.StartNew();
                while (true)
                {
                    Console.ReadKey(true);
                    if (stopwatch.ElapsedTicks > 10000000)
                    {
                        break;
                    }
                }
            }

            return returnCode;
        }
        public static void InspectExe(string exePath)
        {
            FileStream stream = File.Open(exePath, FileMode.Open, FileAccess.Read, FileShare.Read);

            MZHeader mzHeader = MZHeader.ReadMe(stream);
            mzHeader.PrintMe();

            /*
             MZHeaderV2 mzHeaderV2 = MZHeaderV2.Parse(stream);
             mzHeaderV2.Print();

             if (stream.offset != mzHeaderV2.PEHeaderStart)
             {
                 byte[] DOSStub = new byte[mzHeaderV2.PEHeaderStart - stream.offset];
                 Array.Copy(stream.buffer, stream.offset, DOSStub, 0, DOSStub.Length);
                 stream.offset = (int)mzHeaderV2.PEHeaderStart;

                 Print.Log("DOS Stub:");
                 Print.Log(Read.AsASCII(DOSStub));
                 Print.NL();
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

                 Print.Log("Spacer Bytes:");
                 Print.Log(Read.AsHex(spacerBytes));
                 Print.NL();
             }

             PESectionHeader[] peSectionHeaders = new PESectionHeader[peHeader.NumberOfSections];
             for (int i = 0; i < peSectionHeaders.Length; i++)
             {
                 peSectionHeaders[i] = PESectionHeader.Parse(stream);
                 peSectionHeaders[i].Print(i);
             }

             for (int i = 0; i < peSectionHeaders.Length; i++)
             {
                 byte[] sectionBuffer = new byte[peSectionHeaders[i].SizeOfRawData];
                 if (stream.offset != (int)peSectionHeaders[i].PointerToRawData)
                 {
                     Console.ForegroundColor = ConsoleColor.Yellow;
                     Print.Log($"Skipped {peSectionHeaders[i].PointerToRawData - stream.offset} bytes from {stream.offset} to {peSectionHeaders[i].PointerToRawData}.");
                     Console.ForegroundColor = ConsoleColor.White;
                     Print.NL();
                     stream.offset = (int)peSectionHeaders[i].PointerToRawData;
                 }
                 Array.Copy(stream.buffer, stream.offset, sectionBuffer, 0, sectionBuffer.Length);
                 stream.offset += sectionBuffer.Length;
                 TinyStream sectionStream = new TinyStream(sectionBuffer);
                 InspectSection(sectionStream, peSectionHeaders[i]);
             }
            */

            if (stream.Position != stream.Length - 1)
            {
                throw new Exception("We should look at the whole file.");
            }

            stream.Close();
            stream.Dispose();
        }
        /*
        public static void InspectSection(TinyStream stream, PESectionHeader header)
        {
            if (header.VirtualSize > header.SizeOfRawData)
            {
                Print.Log($"{header.Name} Section (Hex):");
                Print.LogPair("Body", Read.AsHex(stream.buffer));
                Print.NL();
                Print.LogPair("Uninitialized Bytes", Read.AsInt(header.VirtualSize - header.SizeOfRawData));
                Print.NL();
            }
            else
            {
                byte[] body = new byte[header.VirtualSize];
                Array.Copy(stream.buffer, 0, body, 0, body.Length);

                int paddingSize = (int)(header.SizeOfRawData - header.VirtualSize);
                byte[] padding = new byte[paddingSize];
                Array.Copy(stream.buffer, header.VirtualSize, padding, 0, padding.Length);

                Print.Log($"{header.Name} Section (Hex):");
                Print.LogPair("Body", Read.AsHex(body));
                Print.NL();
                Print.LogPair("Padding", Read.AsHex(padding));
                Print.NL();
            }

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
             }
             else
             {
                 BC.Log($"Unknown Section {header.Name} (ASCII):");
                 BC.Log(DF.AsASCII(stream.buffer));
                 BC.NL();
             }
        }
        */
    }
}