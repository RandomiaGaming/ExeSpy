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
            BC.Log("PEHeader:");
            BC.LogPair("Magic Bytes", DF.AsASCII(MagicBytes));
            BC.LogPair("Machine", DF.AsUInt(Machine));
            BC.LogPair("Number Of Sections", DF.AsUInt(NumberOfSections));
            BC.LogPair("Date Time Stamp", DF.AsEpochTime(DateTimeStamp));
            BC.LogPair("Pointer To Symbol Table", DF.AsUInt(PointerToSymbolTable));
            BC.LogPair("Number Of Symbols", DF.AsUInt(NumberOfSymbols));
            BC.LogPair("Size Of Optional Header", DF.AsUInt(SizeOfOptionalHeader));
            BC.LogPair("Characteristics", DF.AsUInt(Characteristics));
            BC.NL();
        }
        public static PEHeader Parse(TinyStream stream)
        {
            PEHeader output = DF.Parse<PEHeader>(stream);

            if (output.MagicBytes != 0x00004550)
            {
                throw new Exception("PEHeader.MagicBytes must be ASCII PE or Hex 0x00004550.");
            }

            return output;
        }
    }
}