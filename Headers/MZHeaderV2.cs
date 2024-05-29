using System;
using System.Runtime.InteropServices;

namespace EXESpy
{
    public struct MZHeaderV2
    {
        public ushort MagicBytes; // Must be ASCII MZ or Hex 0x5A4D
        public ushort ExtraBytes;
        public ushort Pages;
        public ushort RelocationItems;
        public ushort HeaderSize;
        public ushort MinimumAllocation;
        public ushort MaximumAllocation;
        public ushort InitialSS;
        public ushort InitialSP;
        public ushort Checksum;
        public ushort InitialIP;
        public ushort InitialCS;
        public ushort RelocationTable;
        public ushort Overlay;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] Reserved1; // Must be all 0s
        public ushort OEMIdentifier;
        public ushort OEMInfo;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] Reserved2; // Must be all 0s
        public uint PEHeaderStart;
        public void Print()
        {
            EXESpy.Print.Log("MZHeader:");
            EXESpy.Print.LogPair("MagicBytes", Read.AsASCII(MagicBytes));
            EXESpy.Print.LogPair("ExtraBytes", Read.AsHex(ExtraBytes));
            EXESpy.Print.LogPair("Pages", Read.AsUInt(Pages));
            EXESpy.Print.LogPair("RelocationItems", Read.AsUInt(RelocationItems));
            EXESpy.Print.LogPair("HeaderSize", Read.AsUInt(HeaderSize));
            EXESpy.Print.LogPair("MinimumAllocation", Read.AsUInt(MinimumAllocation));
            EXESpy.Print.LogPair("MaximumAllocation", Read.AsUInt(MaximumAllocation));
            EXESpy.Print.LogPair("InitialSS", Read.AsUInt(InitialSS));
            EXESpy.Print.LogPair("InitialSP", Read.AsUInt(InitialSP));
            EXESpy.Print.LogPair("Checksum", Read.AsUInt(Checksum));
            EXESpy.Print.LogPair("InitialIP", Read.AsUInt(InitialIP));
            EXESpy.Print.LogPair("InitialCS", Read.AsUInt(InitialCS));
            EXESpy.Print.LogPair("RelocationTable", Read.AsUInt(RelocationTable));
            EXESpy.Print.LogPair("Overlay", Read.AsUInt(Overlay));
            EXESpy.Print.LogPair("Reserved1", Read.AsHex(Reserved1));
            EXESpy.Print.LogPair("OEMIdentifier", Read.AsUInt(OEMIdentifier));
            EXESpy.Print.LogPair("OEMInfo", Read.AsUInt(OEMInfo));
            EXESpy.Print.LogPair("Reserved2", Read.AsHex(Reserved2));
            EXESpy.Print.LogPair("PEHeaderStart", Read.AsUInt(PEHeaderStart));
            EXESpy.Print.NL();
        }
        public static MZHeaderV2 Parse(TinyStream stream)
        {
            MZHeaderV2 mzHeaderV2 = Read.Parse<MZHeaderV2>(stream);

            if (mzHeaderV2.MagicBytes != 0x5A4D)
            {
                throw new Exception("MZHeaderV2.MagicBytes must be MZ or 0x5A4D.");
            }
            for (int i = 0; i < mzHeaderV2.Reserved1.Length; i++)
            {
                if(mzHeaderV2.Reserved1[i] != 0)
                {
                    throw new Exception("MZHeaderV2.Reserved1 must contain only 0s.");
                }
            }
            for (int i = 0; i < mzHeaderV2.Reserved2.Length; i++)
            {
                if (mzHeaderV2.Reserved2[i] != 0)
                {
                    throw new Exception("MZHeaderV2.Reserved2 must contain only 0s.");
                }
            }

            return mzHeaderV2;
        }
    }
}