using System;

namespace EXESpy
{
    public struct PEHeader
    {
        public uint MagicBytes; // Must be ASCII PE or HEX 0x00004550
        public ushort Machine;
        public ushort NumberOfSections;
        public uint DateTimeStamp;
        public uint PointerToSymbolTable;
        public uint NumberOfSymbols;
        public ushort SizeOfOptionalHeader;
        public ushort Characteristics;
        public void Print()
        {
            EXESpy.Print.Log("PEHeader:");
            EXESpy.Print.LogPair("Magic Bytes", Read.AsASCII(MagicBytes));
            EXESpy.Print.LogPair("Machine", Read.AsUInt(Machine));
            EXESpy.Print.LogPair("Number Of Sections", Read.AsUInt(NumberOfSections));
            EXESpy.Print.LogPair("Date Time Stamp", Read.AsEpochTime(DateTimeStamp));
            EXESpy.Print.LogPair("Pointer To Symbol Table", Read.AsUInt(PointerToSymbolTable));
            EXESpy.Print.LogPair("Number Of Symbols", Read.AsUInt(NumberOfSymbols));
            EXESpy.Print.LogPair("Size Of Optional Header", Read.AsUInt(SizeOfOptionalHeader));
            EXESpy.Print.LogPair("Characteristics", Read.AsUInt(Characteristics));
            EXESpy.Print.NL();
        }
        public static PEHeader Parse(TinyStream stream)
        {
            PEHeader output = Read.Parse<PEHeader>(stream);

            if (output.MagicBytes != 0x00004550)
            {
                throw new Exception("PEHeader.MagicBytes must be ASCII PE or Hex 0x00004550.");
            }

            return output;
        }
    }
}