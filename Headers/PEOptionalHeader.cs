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
            EXESpy.Print.Log("PEOptionalHeader:");
            string magicBytesString = Read.AsHex(MagicBytes);
            if(MagicBytes == 0x010B)
            {
                magicBytesString += " (PE32)";
            }
            else
            {
                magicBytesString += " (PE64)";
            }
            EXESpy.Print.LogPair("Magic Bytes", magicBytesString);
            EXESpy.Print.LogPair("Major Linker Version", Read.AsUInt(MajorLinkerVersion));
            EXESpy.Print.LogPair("Minor Linker Version", Read.AsUInt(MinorLinkerVersion));
            EXESpy.Print.LogPair("Size Of Code", Read.AsUInt(SizeOfCode));
            EXESpy.Print.LogPair("Size Of Initialized Data", Read.AsUInt(SizeOfInitializedData));
            EXESpy.Print.LogPair("Size Of Uninitialized Data", Read.AsUInt(SizeOfUninitializedData));
            EXESpy.Print.LogPair("Address Of Entry Point", Read.AsUInt(AddressOfEntryPoint));
            EXESpy.Print.LogPair("Base Of Code", Read.AsUInt(BaseOfCode));
            EXESpy.Print.LogPair("Base Of Data", Read.AsUInt(BaseOfData));
            EXESpy.Print.LogPair("Image Base", Read.AsUInt(ImageBase));
            EXESpy.Print.LogPair("Section Alignment", Read.AsUInt(SectionAlignment));
            EXESpy.Print.LogPair("File Alignment", Read.AsUInt(FileAlignment));
            EXESpy.Print.LogPair("Major Operating System Version", Read.AsUInt(MajorOperatingSystemVersion));
            EXESpy.Print.LogPair("Minor Operating System Version", Read.AsUInt(MinorOperatingSystemVersion));
            EXESpy.Print.LogPair("Major Image Version", Read.AsUInt(MajorImageVersion));
            EXESpy.Print.LogPair("Minor Image Version", Read.AsUInt(MinorImageVersion));
            EXESpy.Print.LogPair("Major Subsystem Version", Read.AsUInt(MajorSubsystemVersion));
            EXESpy.Print.LogPair("Minor Subsystem Version", Read.AsUInt(MinorSubsystemVersion));
            EXESpy.Print.LogPair("Win32 Version Value", Read.AsUInt(Win32VersionValue));
            EXESpy.Print.LogPair("Size Of Image", Read.AsUInt(SizeOfImage));
            EXESpy.Print.LogPair("Size Of Headers", Read.AsUInt(SizeOfHeaders));
            EXESpy.Print.LogPair("Checksum", Read.AsUInt(Checksum));
            EXESpy.Print.LogPair("Subsystem", Read.AsUInt(Subsystem));
            EXESpy.Print.LogPair("Dll Characteristics", Read.AsUInt(DllCharacteristics));
            EXESpy.Print.LogPair("Size Of Stack Reserve", Read.AsUInt(SizeOfStackReserve));
            EXESpy.Print.LogPair("Size Of Stack Commit", Read.AsUInt(SizeOfStackCommit));
            EXESpy.Print.LogPair("Size Of Heap Reserve", Read.AsUInt(SizeOfHeapReserve));
            EXESpy.Print.LogPair("Size Of Heap Commit", Read.AsUInt(SizeOfHeapCommit));
            EXESpy.Print.LogPair("Loader Flags", Read.AsUInt(LoaderFlags));
            EXESpy.Print.LogPair("Number Of Rva And Sizes", Read.AsUInt(NumberOfRvaAndSizes));
            EXESpy.Print.NL();
        }
        public static PEOptionalHeader Parse(TinyStream stream)
        {
            PEOptionalHeader output = Read.Parse<PEOptionalHeader>(stream);

            if (output.MagicBytes != 0x010B && output.MagicBytes != 0x020B)
            {
                throw new Exception("PEOptionalHeader.MagicBytes must be Hex 0x010B or Hex 0x020B.");
            }

            return output;
        }
    }
}