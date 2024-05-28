using System;

namespace EXESpy
{
    public struct PEOptionalHeader
    {
        public ushort MagicBytes; // Must be HEX 0x010B for PE32 bit, or HEX 0x020B for PE64 bit
        public byte MajorLinkerVersion;
        public byte MinorLinkerVersion;
        public uint SizeOfCode;
        public uint SizeOfInitializedData;
        public uint SizeOfUninitializedData;
        public uint AddressOfEntryPoint;
        public uint BaseOfCode;
        public uint BaseOfData;
        public uint ImageBase;
        public uint SectionAlignment;
        public uint FileAlignment;
        public ushort MajorOperatingSystemVersion;
        public ushort MinorOperatingSystemVersion;
        public ushort MajorImageVersion;
        public ushort MinorImageVersion;
        public ushort MajorSubsystemVersion;
        public ushort MinorSubsystemVersion;
        public uint Win32VersionValue;
        public uint SizeOfImage;
        public uint SizeOfHeaders;
        public uint Checksum;
        public ushort Subsystem;
        public ushort DllCharacteristics;
        public uint SizeOfStackReserve;
        public uint SizeOfStackCommit;
        public uint SizeOfHeapReserve;
        public uint SizeOfHeapCommit;
        public uint LoaderFlags;
        public uint NumberOfRvaAndSizes;
        public void Print()
        {
            BC.Log("PEOptionalHeader:");
            string magicBytesString = DF.AsHex(MagicBytes);
            if(MagicBytes == 0x010B)
            {
                magicBytesString += " (PE32)";
            }
            else
            {
                magicBytesString += " (PE64)";
            }
            BC.LogPair("Magic Bytes", magicBytesString);
            BC.LogPair("Major Linker Version", DF.AsUInt(MajorLinkerVersion));
            BC.LogPair("Minor Linker Version", DF.AsUInt(MinorLinkerVersion));
            BC.LogPair("Size Of Code", DF.AsUInt(SizeOfCode));
            BC.LogPair("Size Of Initialized Data", DF.AsUInt(SizeOfInitializedData));
            BC.LogPair("Size Of Uninitialized Data", DF.AsUInt(SizeOfUninitializedData));
            BC.LogPair("Address Of Entry Point", DF.AsUInt(AddressOfEntryPoint));
            BC.LogPair("Base Of Code", DF.AsUInt(BaseOfCode));
            BC.LogPair("Base Of Data", DF.AsUInt(BaseOfData));
            BC.LogPair("Image Base", DF.AsUInt(ImageBase));
            BC.LogPair("Section Alignment", DF.AsUInt(SectionAlignment));
            BC.LogPair("File Alignment", DF.AsUInt(FileAlignment));
            BC.LogPair("Major Operating System Version", DF.AsUInt(MajorOperatingSystemVersion));
            BC.LogPair("Minor Operating System Version", DF.AsUInt(MinorOperatingSystemVersion));
            BC.LogPair("Major Image Version", DF.AsUInt(MajorImageVersion));
            BC.LogPair("Minor Image Version", DF.AsUInt(MinorImageVersion));
            BC.LogPair("Major Subsystem Version", DF.AsUInt(MajorSubsystemVersion));
            BC.LogPair("Minor Subsystem Version", DF.AsUInt(MinorSubsystemVersion));
            BC.LogPair("Win32 Version Value", DF.AsUInt(Win32VersionValue));
            BC.LogPair("Size Of Image", DF.AsUInt(SizeOfImage));
            BC.LogPair("Size Of Headers", DF.AsUInt(SizeOfHeaders));
            BC.LogPair("Checksum", DF.AsUInt(Checksum));
            BC.LogPair("Subsystem", DF.AsUInt(Subsystem));
            BC.LogPair("Dll Characteristics", DF.AsUInt(DllCharacteristics));
            BC.LogPair("Size Of Stack Reserve", DF.AsUInt(SizeOfStackReserve));
            BC.LogPair("Size Of Stack Commit", DF.AsUInt(SizeOfStackCommit));
            BC.LogPair("Size Of Heap Reserve", DF.AsUInt(SizeOfHeapReserve));
            BC.LogPair("Size Of Heap Commit", DF.AsUInt(SizeOfHeapCommit));
            BC.LogPair("Loader Flags", DF.AsUInt(LoaderFlags));
            BC.LogPair("Number Of Rva And Sizes", DF.AsUInt(NumberOfRvaAndSizes));
            BC.NL();
        }
        public static PEOptionalHeader Parse(TinyStream stream)
        {
            PEOptionalHeader output = DF.Parse<PEOptionalHeader>(stream);

            if (output.MagicBytes != 0x010B && output.MagicBytes != 0x020B)
            {
                throw new Exception("PEOptionalHeader.MagicBytes must be Hex 0x010B or Hex 0x020B.");
            }

            return output;
        }
    }
}