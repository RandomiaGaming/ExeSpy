namespace EXESpy
{
    public static class DataSegment
    {
        public static void ParseAndPrint(TinyStream stream, PESectionHeader header)
        {
            if (header.VirtualSize > header.SizeOfRawData)
            {
                Print.Log($"{header.Name} Section (ASCII + {header.VirtualSize - header.SizeOfRawData} Uninitialized Bytes):");
            }
            else
            {
                Print.Log($"{header.Name} Section (ASCII):");
            }
            Print.Log(Read.AsASCII(stream.buffer));
            Print.NL();
        }
    }
}