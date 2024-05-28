using System;
using System.Runtime.InteropServices;

namespace EXESpy
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PESectionHeader
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        public string Name;
        public uint VirtualSize;
        public uint VirtualAddress;
        public uint SizeOfRawData;
        public uint PointerToRawData;
        public uint PointerToRelocations;
        public uint PointerToLinenumbers;
        public ushort NumberOfRelocations;
        public ushort NumberOfLinenumbers;
        public uint Characteristics;
        public void Print(int sectionNumber)
        {
            BC.Log($"PESectionHeader {sectionNumber}:");
            BC.LogPair("Name", Name);
            BC.LogPair("Virtual Size", DF.AsUInt(VirtualSize));
            BC.LogPair("Virtual Address", DF.AsUInt(VirtualAddress));
            BC.LogPair("Size Of Raw Data", DF.AsUInt(SizeOfRawData));
            BC.LogPair("Pointer To Raw Data", DF.AsUInt(PointerToRawData));
            BC.LogPair("Pointer To Relocations", DF.AsUInt(PointerToRelocations));
            BC.LogPair("Pointer To Linenumbers", DF.AsUInt(PointerToLinenumbers));
            BC.LogPair("Number Of Relocations", DF.AsUInt(NumberOfRelocations));
            BC.LogPair("Number Of Linenumbers", DF.AsUInt(NumberOfLinenumbers));
            BC.LogPair("Characteristics", DF.AsUInt(Characteristics));
            BC.NL();
        }
        public static PESectionHeader Parse(TinyStream stream)
        {
            PESectionHeader output = DF.Parse<PESectionHeader>(stream);
            return output;
        }
    }
}
