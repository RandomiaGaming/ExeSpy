namespace EXESpy
{
    public static class DataSegment
    {
        public static void ParseAndPrint(TinyStream stream, PESectionHeader header)
        {
            if (header.VirtualSize > header.SizeOfRawData)
            {
                BC.Log($"{header.Name} Section (ASCII + {header.VirtualSize - header.SizeOfRawData} Uninitialized Bytes):");
            }
            else
            {
                BC.Log($"{header.Name} Section (ASCII):");
            }
            BC.Log(DF.AsASCII(stream.buffer));
            BC.NL();
        }
    }
}