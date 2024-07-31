using System.IO;
using System;
namespace ExeSpy
{
    // Parses byte arrays into C# managed types.
    public static class Construct
    {
        public static byte Byte(byte[] bytes, int index = 0)
        {
            if (bytes is null) { throw new Exception("Bad bytes."); }
            if (index < 0 || index >= bytes.Length) { throw new Exception("Bad index."); }
            if (index + 1 > bytes.Length) { throw new Exception("Too small."); }

            return bytes[0];
        }
        public static sbyte SByte(byte[] bytes, int index = 0)
        {
            if (bytes is null) { throw new Exception("Bad bytes."); }
            if (index < 0 || index >= bytes.Length) { throw new Exception("Bad index."); }
            if (index + 1 > bytes.Length) { throw new Exception("Too small."); }

            return (sbyte)bytes[0];
        }
        public static ushort Word(byte[] bytes, int index = 0)
        {
            if (bytes is null) { throw new Exception("Bad bytes."); }
            if (index < 0 || index >= bytes.Length) { throw new Exception("Bad index."); }
            if (index + 2 > bytes.Length) { throw new Exception("Too small."); }

            return BitConverter.ToUInt16(bytes, index);
        }
        public static short SWord(byte[] bytes, int index = 0)
        {
            if (bytes is null) { throw new Exception("Bad bytes."); }
            if (index < 0 || index >= bytes.Length) { throw new Exception("Bad index."); }
            if (index + 2 > bytes.Length) { throw new Exception("Too small."); }

            return BitConverter.ToInt16(bytes, index);
        }
        public static uint DWord(byte[] bytes, int index = 0)
        {
            if (bytes is null) { throw new Exception("Bad bytes."); }
            if (index < 0 || index >= bytes.Length) { throw new Exception("Bad index."); }
            if (index + 4 > bytes.Length) { throw new Exception("Too small."); }

            return BitConverter.ToUInt32(bytes, index);
        }
        public static int SDWord(byte[] bytes, int index = 0)
        {
            if (bytes is null) { throw new Exception("Bad bytes."); }
            if (index < 0 || index >= bytes.Length) { throw new Exception("Bad index."); }
            if (index + 4 > bytes.Length) { throw new Exception("Too small."); }

            return BitConverter.ToInt32(bytes, index);
        }
        public static ulong QWord(byte[] bytes, int index = 0)
        {
            if (bytes is null) { throw new Exception("Bad bytes."); }
            if (index < 0 || index >= bytes.Length) { throw new Exception("Bad index."); }
            if (index + 8 > bytes.Length) { throw new Exception("Too small."); }

            return BitConverter.ToUInt64(bytes, index);
        }
        public static long SQWord(byte[] bytes, int index = 0)
        {
            if (bytes is null) { throw new Exception("Bad bytes."); }
            if (index < 0 || index >= bytes.Length) { throw new Exception("Bad index."); }
            if (index + 8 > bytes.Length) { throw new Exception("Too small."); }

            return BitConverter.ToInt64(bytes, index);
        }
        public static float Real4(byte[] bytes, int index = 0)
        {
            if (bytes is null) { throw new Exception("Bad bytes."); }
            if (index < 0 || index >= bytes.Length) { throw new Exception("Bad index."); }
            if (index + 4 > bytes.Length) { throw new Exception("Too small."); }

            return BitConverter.ToSingle(bytes, index);
        }
        public static double Real8(byte[] bytes, int index = 0)
        {
            if (bytes is null) { throw new Exception("Bad bytes."); }
            if (index < 0 || index >= bytes.Length) { throw new Exception("Bad index."); }
            if (index + 8 > bytes.Length) { throw new Exception("Too small."); }

            return BitConverter.ToDouble(bytes, index);
        }

        public static sbyte[] SBytes(byte[] bytes, int count, int index = 0)
        {
            if (bytes is null) { throw new Exception("Bad bytes."); }
            if (count < 0) { throw new Exception("Bad count."); }
            if (index < 0 || index >= bytes.Length) { throw new Exception("Bad index."); }
            if (index + (1 * count) > bytes.Length) { throw new Exception("Too small."); }

            MemoryStream stream = new MemoryStream(bytes);
            sbyte[] output = new sbyte[count];
            for (int i = 0; i < count; i++)
            {
                output[i] = Read.SByte(stream);
            }
            stream.Dispose();
            return output;
        }
        public static ushort[] Words(byte[] bytes, int count, int index = 0)
        {
            if (bytes is null) { throw new Exception("Bad bytes."); }
            if (count < 0) { throw new Exception("Bad count."); }
            if (index < 0 || index >= bytes.Length) { throw new Exception("Bad index."); }
            if (index + (2 * count) > bytes.Length) { throw new Exception("Too small."); }

            MemoryStream stream = new MemoryStream(bytes);
            ushort[] output = new ushort[count];
            for (int i = 0; i < count; i++)
            {
                output[i] = Read.Word(stream);
            }
            stream.Dispose();
            return output;
        }
        public static short[] SWords(byte[] bytes, int count, int index = 0)
        {
            if (bytes is null) { throw new Exception("Bad bytes."); }
            if (count < 0) { throw new Exception("Bad count."); }
            if (index < 0 || index >= bytes.Length) { throw new Exception("Bad index."); }
            if (index + (2 * count) > bytes.Length) { throw new Exception("Too small."); }

            MemoryStream stream = new MemoryStream(bytes);
            short[] output = new short[count];
            for (int i = 0; i < count; i++)
            {
                output[i] = Read.SWord(stream);
            }
            stream.Dispose();
            return output;
        }
        public static uint[] DWords(byte[] bytes, int count, int index = 0)
        {
            if (bytes is null) { throw new Exception("Bad bytes."); }
            if (count < 0) { throw new Exception("Bad count."); }
            if (index < 0 || index >= bytes.Length) { throw new Exception("Bad index."); }
            if (index + (4 * count) > bytes.Length) { throw new Exception("Too small."); }

            MemoryStream stream = new MemoryStream(bytes);
            uint[] output = new uint[count];
            for (int i = 0; i < count; i++)
            {
                output[i] = Read.DWord(stream);
            }
            stream.Dispose();
            return output;
        }
        public static int[] SDWords(byte[] bytes, int count, int index = 0)
        {
            if (bytes is null) { throw new Exception("Bad bytes."); }
            if (count < 0) { throw new Exception("Bad count."); }
            if (index < 0 || index >= bytes.Length) { throw new Exception("Bad index."); }
            if (index + (4 * count) > bytes.Length) { throw new Exception("Too small."); }

            MemoryStream stream = new MemoryStream(bytes);
            int[] output = new int[count];
            for (int i = 0; i < count; i++)
            {
                output[i] = Read.SDWord(stream);
            }
            stream.Dispose();
            return output;
        }
        public static ulong[] QWords(byte[] bytes, int count, int index = 0)
        {
            if (bytes is null) { throw new Exception("Bad bytes."); }
            if (count < 0) { throw new Exception("Bad count."); }
            if (index < 0 || index >= bytes.Length) { throw new Exception("Bad index."); }
            if (index + (8 * count) > bytes.Length) { throw new Exception("Too small."); }

            MemoryStream stream = new MemoryStream(bytes);
            ulong[] output = new ulong[count];
            for (int i = 0; i < count; i++)
            {
                output[i] = Read.QWord(stream);
            }
            stream.Dispose();
            return output;
        }
        public static long[] SQWords(byte[] bytes, int count, int index = 0)
        {
            if (bytes is null) { throw new Exception("Bad bytes."); }
            if (count < 0) { throw new Exception("Bad count."); }
            if (index < 0 || index >= bytes.Length) { throw new Exception("Bad index."); }
            if (index + (8 * count) > bytes.Length) { throw new Exception("Too small."); }

            MemoryStream stream = new MemoryStream(bytes);
            long[] output = new long[count];
            for (int i = 0; i < count; i++)
            {
                output[i] = Read.SQWord(stream);
            }
            stream.Dispose();
            return output;
        }
        public static float[] Real4s(byte[] bytes, int count, int index = 0)
        {
            if (bytes is null) { throw new Exception("Bad bytes."); }
            if (count < 0) { throw new Exception("Bad count."); }
            if (index < 0 || index >= bytes.Length) { throw new Exception("Bad index."); }
            if (index + (4 * count) > bytes.Length) { throw new Exception("Too small."); }

            MemoryStream stream = new MemoryStream(bytes);
            float[] output = new float[count];
            for (int i = 0; i < count; i++)
            {
                output[i] = Read.Real4(stream);
            }
            stream.Dispose();
            return output;
        }
        public static double[] Real8s(byte[] bytes, int count, int index = 0)
        {
            if (bytes is null) { throw new Exception("Bad bytes."); }
            if (count < 0) { throw new Exception("Bad count."); }
            if (index < 0 || index >= bytes.Length) { throw new Exception("Bad index."); }
            if (index + (8 * count) > bytes.Length) { throw new Exception("Too small."); }

            MemoryStream stream = new MemoryStream(bytes);
            double[] output = new double[count];
            for (int i = 0; i < count; i++)
            {
                output[i] = Read.Real8(stream);
            }
            stream.Dispose();
            return output;
        }
    }
}