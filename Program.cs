using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ExeSpy
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            if (Debugger.IsAttached)
            {
                Print.Line("Running tests...");
                Tests.All();
                Print.Line("All tests passed!");
                Print.NewLine();

                args = new string[1] { "D:\\Coding\\Assembly\\HelloASM - Template\\Ret69.exe" }; // ASM return 69
                // args = new string[1] { "D:\\Coding\\Assembly\\HelloASM - Template\\HelloWorld.exe" }; // ASM Hello World
                // args = new string[1] { "D:\\School\\WinSeExclusion\\Project6\\Debug\\Project.exe" }; // ASM CS Homework
                // args = new string[1] { typeof(Program).Assembly.Location }; // C# ExeSpy
                // args = new string[1] { "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe" }; // Google Chrome
                Print.Line(args[0]);
                Print.NewLine();
            }

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
            // Open file
            long FSPOS = 0;
            FileStream stream = File.Open(exePath, FileMode.Open, FileAccess.Read, FileShare.Read);

            // Load MZ header
            FSPOS = stream.Position;
            MZHeaderV2 mzHeader = Read.MZHeaderV2(stream);
            Print.MZHeaderV2(mzHeader, FSPOS);

            // Check for padding after MZ header
            if (stream.Position != mzHeader.HeaderSize * 16)
            {
                Print.Warning("There was unused bytes in the MZ header.");
                Print.NewLine();
            }

            // Load MSDOS relocation table
            if (mzHeader.RelocationEntiryCount > 0)
            {
                // TODO: Add support for MSDOS relocation tables.
                Print.Warning("MSDOS relocation tables are not yet supported by ExeSpy.");
                Print.NewLine();
            }

            // Load DOS stub
            if (mzHeader.PageCount > 0)
            {
                // KNOWN ISSUE
                // Microsoft's link.exe is dumb and marks the size of the DOS stub as being larger than it actually is.
                // In production this is fine and just means causes the DOS loader to copy extra bytes from the PE header
                // into memory as if they were part of the DOS stub, however, these extra bytes will never be executed
                // as they are beyond the final return of the program so they don't matter. If you hate this as much as
                // I do then you can edit the MZHeader to shrink the size of the DOS stub to its actual size.
                FSPOS = stream.Position;

                int DOSStubLength = ((mzHeader.PageCount - 1) * 512) + mzHeader.LastPageLength;
                if (stream.Position + DOSStubLength >= mzHeader.NewHeaderFileAddress)
                {
                    Print.Warning("DOS stub was marked as larger than it actually is.");
                    Print.NewLine();
                    // Shrink DOS stub if it extends into the PEHeader.
                    DOSStubLength = (int)(mzHeader.NewHeaderFileAddress - stream.Position);
                }
                byte[] DOSStub = Read.Bytes(stream, DOSStubLength);

                Print.Line($"DOS Stub ({FSPOS}):");
                Print.Line(FormatAs.Ascii(DOSStub, false));
                Print.NewLine();
            }

            // Load PE header
            FSPOS = stream.Position;
            PEHeader peHeader = Read.PEHeader(stream);
            Print.PEHeader(peHeader, FSPOS);

            // Calculate and save the file position we will be at when we finish reading the optional header.
            long sectionHeadersPosition = stream.Position + peHeader.SizeOfOptionalHeader;

            // Load PE optional header
            if (peHeader.SizeOfOptionalHeader > 0)
            {
                FSPOS = stream.Position;
                PEOptionalHeader peOptionalHeader = Read.PEOptionalHeader(stream);
                Print.PEOptionalHeader(peOptionalHeader, FSPOS);

                uint DataDirectoryCount = peOptionalHeader.NumberOfRvaAndSizes;
                if (DataDirectoryCount > 16) { DataDirectoryCount = 16; }
                for (uint i = 0; i < DataDirectoryCount; i++)
                {
                    FSPOS = stream.Position;
                    PEDataDirectory peDataDirectory = Read.PEDataDirectory(stream);
                    Print.PEDataDirectory(peDataDirectory, i, FSPOS);
                }
            }

            // Check for padding after PE Optional Header
            if (stream.Position != sectionHeadersPosition)
            {
                Print.Warning("There was unused bytes in the PE optional header.");
                Print.NewLine();
            }

            // Load PE section headers.
            PESectionHeader[] peSectionHeaders = new PESectionHeader[peHeader.NumberOfSections];
            for (int i = 0; i < peHeader.NumberOfSections; i++)
            {
                FSPOS = stream.Position;
                peSectionHeaders[i] = Read.PESectionHeader(stream);
                Print.PESectionHeader(peSectionHeaders[i], FSPOS);
            }

            List<PESectionHeader> peSectionsToInspect = new List<PESectionHeader>(peSectionHeaders);
            while (peSectionsToInspect.Count > 0)
            {
                PESectionHeader nextSection = peSectionsToInspect[0];
                for (int i = 1; i < peSectionsToInspect.Count; i++)
                {
                    if (peSectionsToInspect[i].PointerToRawData < nextSection.PointerToRawData)
                    {
                        Print.Warning($"PE section \"{FormatAs.Ascii(Destruct.QWord(nextSection.Name), true)}\" was out of order.");
                        Print.NewLine();

                        nextSection = peSectionsToInspect[i];
                    }
                }
                peSectionsToInspect.Remove(nextSection);

                if(nextSection.PointerToRawData < stream.Position)
                {
                    Print.Warning($"PE section \"{FormatAs.Ascii(Destruct.QWord(nextSection.Name), true)}\" overlapped with other data.");
                    Print.NewLine();

                    stream.Seek(nextSection.PointerToRawData, SeekOrigin.Begin);
                }
                if (stream.Position != nextSection.PointerToRawData)
                {
                    Print.Warning($"There was unused bytes before PE section \"{FormatAs.Ascii(Destruct.QWord(nextSection.Name), true)}\".");
                    Print.NewLine();

                    stream.Seek(nextSection.PointerToRawData, SeekOrigin.Begin);
                }

                FSPOS = stream.Position;
                byte[] sectionPayload = Read.PESection(stream, nextSection);
                Print.PESection(nextSection, sectionPayload, FSPOS);
            }

            if (stream.Position != stream.Length)
            {
                throw new Exception("Whole file should be read before returning.");
            }
            /*
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
            }*/

            stream.Dispose();
        }
        /*public static void InspectSection(TinyStream stream, PESectionHeader header)
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
        }*/
    }
}