using System;
using System.Runtime.Remoting.Messaging;

namespace EXESpy
{
    public struct MZHeader
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
        public ushort OverlayInformation;
        public void Print()
        {
            BC.Log("MZHeader:");
            BC.LogPair("Magic Bytes", DF.AsASCII(MagicBytes));
            BC.LogPair("Extra Bytes", DF.AsHex(ExtraBytes));
            BC.LogPair("Pages", DF.AsUInt(Pages));
            BC.LogPair("Relocation Items", DF.AsUInt(RelocationItems));
            BC.LogPair("Header Size", DF.AsUInt(HeaderSize));
            BC.LogPair("Minimum Allocation", DF.AsUInt(MinimumAllocation));
            BC.LogPair("Maximum Allocation", DF.AsUInt(MaximumAllocation));
            BC.LogPair("Initial SS", DF.AsUInt(InitialSS));
            BC.LogPair("Initial SP", DF.AsUInt(InitialSP));
            BC.LogPair("Checksum", DF.AsHex(Checksum));
            BC.LogPair("Initial IP", DF.AsUInt(InitialIP));
            BC.LogPair("Initial CS", DF.AsUInt(InitialCS));
            BC.LogPair("Relocation Table", DF.AsUInt(RelocationTable));
            BC.LogPair("Overlay", DF.AsUInt(Overlay));
            BC.LogPair("Overlay Information", DF.AsUInt(OverlayInformation));
            BC.NL();
        }
        public static MZHeader Parse(TinyStream stream)
        {
            MZHeader mzHeader = DF.Parse<MZHeader>(stream);

            if(mzHeader.MagicBytes != 0x5A4D)
            {
                throw new Exception("MZHeader.MagicBytes must be MZ or 0x5A4D.");
            }

            return mzHeader;
        }
    }
}