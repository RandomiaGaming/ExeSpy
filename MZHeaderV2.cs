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
            BC.Log("MZHeader:");
            BC.LogPair("MagicBytes", DF.AsASCII(MagicBytes));
            BC.LogPair("ExtraBytes", DF.AsHex(ExtraBytes));
            BC.LogPair("Pages", DF.AsUInt(Pages));
            BC.LogPair("RelocationItems", DF.AsUInt(RelocationItems));
            BC.LogPair("HeaderSize", DF.AsUInt(HeaderSize));
            BC.LogPair("MinimumAllocation", DF.AsUInt(MinimumAllocation));
            BC.LogPair("MaximumAllocation", DF.AsUInt(MaximumAllocation));
            BC.LogPair("InitialSS", DF.AsUInt(InitialSS));
            BC.LogPair("InitialSP", DF.AsUInt(InitialSP));
            BC.LogPair("Checksum", DF.AsUInt(Checksum));
            BC.LogPair("InitialIP", DF.AsUInt(InitialIP));
            BC.LogPair("InitialCS", DF.AsUInt(InitialCS));
            BC.LogPair("RelocationTable", DF.AsUInt(RelocationTable));
            BC.LogPair("Overlay", DF.AsUInt(Overlay));
            BC.LogPair("Reserved1", DF.AsHex(Reserved1));
            BC.LogPair("OEMIdentifier", DF.AsUInt(OEMIdentifier));
            BC.LogPair("OEMInfo", DF.AsUInt(OEMInfo));
            BC.LogPair("Reserved2", DF.AsHex(Reserved2));
            BC.LogPair("PEHeaderStart", DF.AsUInt(PEHeaderStart));
            BC.NL();
        }
        public static MZHeaderV2 Parse(TinyStream stream)
        {
            MZHeaderV2 mzHeaderV2 = DF.Parse<MZHeaderV2>(stream);

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