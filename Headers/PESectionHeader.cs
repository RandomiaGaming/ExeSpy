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
            EXESpy.Print.Log($"PESectionHeader {sectionNumber}:");
            EXESpy.Print.LogPair("Name", Name);
            EXESpy.Print.LogPair("Virtual Size", Read.AsUInt(VirtualSize));
            EXESpy.Print.LogPair("Virtual Address", Read.AsUInt(VirtualAddress));
            EXESpy.Print.LogPair("Size Of Raw Data", Read.AsUInt(SizeOfRawData));
            EXESpy.Print.LogPair("Pointer To Raw Data", Read.AsUInt(PointerToRawData));
            EXESpy.Print.LogPair("Pointer To Relocations", Read.AsUInt(PointerToRelocations));
            EXESpy.Print.LogPair("Pointer To Linenumbers", Read.AsUInt(PointerToLinenumbers));
            EXESpy.Print.LogPair("Number Of Relocations", Read.AsUInt(NumberOfRelocations));
            EXESpy.Print.LogPair("Number Of Linenumbers", Read.AsUInt(NumberOfLinenumbers));
            EXESpy.Print.LogPair("Characteristics", Read.AsUInt(Characteristics));
            EXESpy.Print.NL();
        }
        public static PESectionHeader Parse(TinyStream stream)
        {
            PESectionHeader output = Read.Parse<PESectionHeader>(stream);
            return output;
        }
    }
}
