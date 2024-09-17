using System;
using System.IO;
namespace ExeSpy
{
    // Prints text and structures to the console.
    public static class Print
    {
        public static void Pair(string key, string value)
        {
            if (key is null) { key = ""; }
            if (value is null) { value = ""; }
            Indented($"{key}: {value}");
        }
        public static void Indented(string message)
        {
            if (message is null) { message = ""; }
            Line($"    {message}");
        }
        public static void NewLine()
        {
            Line("");
        }
        public static void Line(string message)
        {
            if (message is null) { message = ""; }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
        }
        public static void Warning(string warning)
        {
            if (warning is null) { warning = ""; }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Warning: {warning}");
        }
        public static void Error(string error)
        {
            if (error is null) { error = ""; }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"ERROR: {error}");
        }

        public static void MZHeaderV1(MZHeaderV1 value, long FSPOS)
        {
            if (value is null) { throw new Exception("Bad value."); }
            if (FSPOS < 0) { throw new Exception("Bad FSPOS"); }

            Line($"MZHeaderV1 ({FSPOS}):");
            Pair("Magic", $"{value.Magic} ({FormatAs.Ascii(Destruct.Word(value.Magic), true)})");
            Pair("LastPageLength", $"{value.LastPageLength} bytes");
            Pair("PageCount", $"{value.PageCount} pages ({value.PageCount * 512} bytes)");
            Pair("RelocationEntiryCount", $"{value.RelocationEntiryCount}");
            Pair("HeaderSize", $"{value.HeaderSize} paragraphs ({value.HeaderSize * 16} bytes)");
            Pair("MinimumAllocation", $"{value.MinimumAllocation} paragraphs ({value.MinimumAllocation * 16} bytes)");
            Pair("MaximumAllocation", $"{value.MaximumAllocation} paragraphs ({value.MaximumAllocation * 16} bytes)");
            Pair("InitialSS", $"{value.InitialSS}");
            Pair("InitialSP", $"{value.InitialSP}");
            Pair("Checksum", $"{value.Checksum}");
            Pair("InitialIP", $"{value.InitialIP}");
            Pair("InitialCS", $"{value.InitialCS}");
            Pair("RelocationTableFileAddress", $"{value.RelocationTableFileAddress}");
            Pair("Overlay", value.Overlay is 0 ? $"{value.Overlay} (Main Executable)" : $"{value.Overlay}");
            NewLine();
        }
        public static void MZHeaderV2(MZHeaderV2 value, long FSPOS)
        {
            if (value is null) { throw new Exception("Bad value."); }
            if (FSPOS < 0) { throw new Exception("Bad FSPOS"); }

            Line($"MZHeaderV2 ({FSPOS}):");
            Pair("Magic", $"{value.Magic} ({FormatAs.Ascii(Destruct.Word(value.Magic), true)})");
            Pair("LastPageLength", $"{value.LastPageLength} bytes");
            Pair("PageCount", $"{value.PageCount} pages ({value.PageCount * 512} bytes)");
            Pair("RelocationEntiryCount", $"{value.RelocationEntiryCount}");
            Pair("HeaderSize", $"{value.HeaderSize} paragraphs ({value.HeaderSize * 16} bytes)");
            Pair("MinimumAllocation", $"{value.MinimumAllocation} paragraphs ({value.MinimumAllocation * 16} bytes)");
            Pair("MaximumAllocation", $"{value.MaximumAllocation} paragraphs ({value.MaximumAllocation * 16} bytes)");
            Pair("InitialSS", $"{value.InitialSS}");
            Pair("InitialSP", $"{value.InitialSP}");
            Pair("Checksum", $"{value.Checksum}");
            Pair("InitialIP", $"{value.InitialIP}");
            Pair("InitialCS", $"{value.InitialCS}");
            Pair("RelocationTableFileAddress", $"{value.RelocationTableFileAddress}");
            Pair("Overlay", value.Overlay is 0 ? $"{value.Overlay} (Main Executable)" : $"{value.Overlay}");
            byte[] reserved1Bytes = Destruct.Words(value.Reserved1);
            Pair("Reserved1", FormatAs.Hex(reserved1Bytes, true));
            Pair("OEMIdentifier", $"{value.OEMIdentifier}");
            Pair("OEMInfo", $"{value.OEMInfo}");
            byte[] reserved2Bytes = Destruct.Words(value.Reserved2);
            Pair("Reserved2", FormatAs.Hex(reserved2Bytes, true));
            Pair("NewHeaderFileAddress", $"{value.NewHeaderFileAddress}");

            NewLine();
        }
        public static void PEHeader(PEHeader value, long FSPOS)
        {
            if (value is null) { throw new Exception("Bad value."); }
            if (FSPOS < 0) { throw new Exception("Bad FSPOS"); }

            Line($"PEHeader ({FSPOS}):");
            Pair("Magic", $"{value.Magic} ({FormatAs.Ascii(Destruct.DWord(value.Magic), true)})");
            Pair("Machine", $"{value.Machine} ({Format.Enum16(value.Machine, ExeSpy.PEHeader.MachineValues, "Unknown")})");
            Pair("NumberOfSections", $"{value.NumberOfSections}");
            Pair("DateTimeStamp", $"{value.DateTimeStamp} ({Format.Epoch32(value.DateTimeStamp)})");
            Pair("PointerToSymbolTable", value.PointerToSymbolTable is 0 ? $"{value.PointerToSymbolTable} (No Symbol Table)" : $"{value.PointerToSymbolTable}");
            Pair("NumberOfSymbols", value.NumberOfSymbols is 0 ? $"{value.NumberOfSymbols} (No Symbol Table)" : $"{value.NumberOfSymbols}");
            Pair("SizeOfOptionalHeader", $"{value.SizeOfOptionalHeader}");
            Pair("Characteristics", $"{value.Characteristics} ({Format.Flags16(value.Characteristics, ExeSpy.PEHeader.CharacteristicsValues, "None")})");

            NewLine();
        }
        public static void PEOptionalHeader(PEOptionalHeader value, long FSPOS)
        {
            if (value is null) { throw new Exception("Bad value."); }
            if (FSPOS < 0) { throw new Exception("Bad FSPOS"); }

            Line($"PEOptionalHeader ({FSPOS}):");
            Pair("Magic", $"{value.Magic} ({Format.Enum16(value.Magic, ExeSpy.PEOptionalHeader.MagicValues, "Unknown")})");
            Pair("MajorLinkerVersion", $"{value.MajorLinkerVersion}");
            Pair("MinorLinkerVersion", $"{value.MinorLinkerVersion}");
            Pair("SizeOfCode", $"{value.SizeOfCode}");
            Pair("SizeOfInitializedData", $"{value.SizeOfInitializedData}");
            Pair("SizeOfUninitializedData", $"{value.SizeOfUninitializedData}");
            Pair("AddressOfEntryPoint", $"{value.AddressOfEntryPoint}");
            Pair("BaseOfCode", $"{value.BaseOfCode}");
            Pair("BaseOfData", $"{value.BaseOfData}");
            Pair("ImageBase", $"{value.ImageBase}");
            Pair("SectionAlignment", $"{value.SectionAlignment}");
            Pair("FileAlignment", $"{value.FileAlignment}");
            Pair("MajorOperatingSystemVersion", $"{value.MajorOperatingSystemVersion}");
            Pair("MinorOperatingSystemVersion", $"{value.MinorOperatingSystemVersion}");
            Pair("MajorImageVersion", $"{value.MajorImageVersion}");
            Pair("MinorImageVersion", $"{value.MinorImageVersion}");
            Pair("MajorSubsystemVersion", $"{value.MajorSubsystemVersion}");
            Pair("MinorSubsystemVersion", $"{value.MinorSubsystemVersion}");
            Pair("Win32VersionValue", $"{value.Win32VersionValue}");
            Pair("SizeOfImage", $"{value.SizeOfImage}");
            Pair("SizeOfHeaders", $"{value.SizeOfHeaders}");
            Pair("CheckSum", $"{value.CheckSum}");
            Pair("Subsystem", $"{value.Subsystem} ({Format.Enum16(value.Subsystem, ExeSpy.PEOptionalHeader.SubsystemValues, "Unknown")})");
            Pair("DllCharacteristics", $"{value.DllCharacteristics} ({Format.Flags16(value.DllCharacteristics, ExeSpy.PEOptionalHeader.DLLCharacteristicsValues, "None")})");
            Pair("SizeOfStackReserve", $"{value.SizeOfStackReserve}");
            Pair("SizeOfStackCommit", $"{value.SizeOfStackCommit}");
            Pair("SizeOfHeapReserve", $"{value.SizeOfHeapReserve}");
            Pair("SizeOfHeapCommit", $"{value.SizeOfHeapCommit}");
            Pair("LoaderFlags", $"{value.LoaderFlags}");
            Pair("NumberOfRvaAndSizes", $"{value.NumberOfRvaAndSizes}");
            NewLine();
        }
        public static void PEDataDirectory(PEDataDirectory value, uint index, long FSPOS)
        {
            if (value is null) { throw new Exception("Bad value."); }
            if (FSPOS < 0) { throw new Exception("Bad FSPOS"); }

            Line($"PEDataDirectory ({FSPOS}):");
            Pair("Name (From Coff Spec)", Format.Enum32(index, ExeSpy.PEDataDirectory.DataDirectoryNames, "Unknown"));
            Pair("VirtualSize", $"{value.VirtualSize}");
            Pair("VirtualAddress", $"{value.VirtualAddress}");
            NewLine();
        }
        public static void PESectionHeader(PESectionHeader value, long FSPOS)
        {
            if (value is null) { throw new Exception("Bad value."); }
            if (FSPOS < 0) { throw new Exception("Bad FSPOS"); }

            Line($"PESectionHeader ({FSPOS}):");
            Pair("Name", $"{value.Name} ({FormatAs.Ascii(Destruct.QWord(value.Name), true)})");
            Pair("VirtualSize", $"{value.VirtualSize}");
            Pair("VirtualAddress", $"{value.VirtualAddress}");
            Pair("SizeOfRawData", $"{value.SizeOfRawData}");
            Pair("PointerToRawData", $"{value.PointerToRawData}");
            Pair("PointerToRelocations", $"{value.PointerToRelocations}");
            Pair("PointerToLinenumbers", $"{value.PointerToLinenumbers}");
            Pair("NumberOfRelocations", $"{value.NumberOfRelocations}");
            Pair("NumberOfLinenumbers", $"{value.NumberOfLinenumbers}");
            string characteristicsEnum = Format.Enum32(value.Characteristics & 0x00F00000, ExeSpy.PESectionHeader.CharacteristicsEnumValues, null);
            string characteristicsFlags = Format.Flags32(value.Characteristics ^ (value.Characteristics & 0x00F00000), ExeSpy.PESectionHeader.CharacteristicsFlagValues, null);
            if (characteristicsEnum is null) { Pair("Characteristics", $"{value.Characteristics} ({characteristicsFlags})"); }
            else if (characteristicsFlags is null) { Pair("Characteristics", $"{value.Characteristics} ({characteristicsEnum})"); }
            else { Pair("Characteristics", $"{value.Characteristics} ({characteristicsFlags + " | " + characteristicsEnum})"); }
            NewLine();
        }
        public static void PESection(PESectionHeader header, byte[] payload, long FSPOS)
        {
            if (header is null) { throw new Exception("Bad header."); }
            if (payload is null) { throw new Exception("Bad payload."); }
            if (FSPOS < 0) { throw new Exception("Bad FSPOS"); }

            string sectionName = FormatAs.Ascii(Destruct.QWord(header.Name), false);
            string sectionDisplayName = sectionName.Replace("\0", "");
            Line($"{sectionDisplayName} PESection ({FSPOS}):");
            if (sectionName == ".text\0\0\0")
            {
                MemoryStream payloadStream = new MemoryStream(payload);
                while(payloadStream.Position != payloadStream.Length)
                {
                    Indented(Disassemble.x86(payloadStream));
                }
                payloadStream.Dispose();
            }
            else if (sectionName == ".rdata\0\0")
            {
                Line($"{FormatAs.Ascii(payload, true)}");
            }
            NewLine();
        }
    }
}