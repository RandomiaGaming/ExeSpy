namespace EXESpy
{
    public sealed class TinyStream
    {
        public byte[] buffer = new byte[0];
        public int offset = 0;
        public TinyStream(byte[] buffer)
        {
            this.buffer = buffer;
            offset = 0;
        }
    }
}