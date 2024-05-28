using System;

namespace EXESpy
{
    public static class RDataSegment
    {
        public static void ParseAndPrint(TinyStream stream, PESectionHeader header)
        {
            if (header.VirtualSize > header.SizeOfRawData)
            {
                throw new Exception("PESectionHeader.VirtualSize may not be greater than PESectionHeader.SizeOfRawData.");
            }

            BC.Log($"{header.Name} Section (ASCII):");
            BC.Log(DF.AsASCII(stream.buffer));
            BC.NL();
        }
    }
}