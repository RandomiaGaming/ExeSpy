using System.IO;
using System;
namespace ExeSpy
{
    // Breaks down C# managed types into byte arrays.
    public static class Destruct
    {
        public static byte[] Byte(byte value)
        {
            return new byte[1] { value }; // NOTE: BitConverter assumes bytes are shorts and is not viable.
        }
        public static byte[] SByte(sbyte value)
        {
            return new byte[1] { (byte)value }; // NOTE: BitConverter assumes sbytes are shorts and is not viable.
        }
        public static byte[] Word(ushort value)
        {
            return BitConverter.GetBytes(value);
        }
        public static byte[] SWord(short value)
        {
            return BitConverter.GetBytes(value);
        }
        public static byte[] DWord(uint value)
        {
            return BitConverter.GetBytes(value);
        }
        public static byte[] SDWord(int value)
        {
            return BitConverter.GetBytes(value);
        }
        public static byte[] QWord(ulong value)
        {
            return BitConverter.GetBytes(value);
        }
        public static byte[] SQWord(long value)
        {
            return BitConverter.GetBytes(value);
        }
        public static byte[] Real4(float value)
        {
            return BitConverter.GetBytes(value);
        }
        public static byte[] Real8(double value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] SBytes(sbyte[] values)
        {
            if (values is null) { throw new Exception("Bad values."); }

            MemoryStream outputStream = new MemoryStream();
            for (int i = 0; i < values.Length; i++)
            {
                Write.SByte(outputStream, values[i]);
            }
            byte[] output = outputStream.ToArray();
            outputStream.Dispose();
            return output;
        }
        public static byte[] Words(ushort[] values)
        {
            if (values is null) { throw new Exception("Bad values."); }

            MemoryStream outputStream = new MemoryStream();
            for (int i = 0; i < values.Length; i++)
            {
                Write.Word(outputStream, values[i]);
            }
            byte[] output = outputStream.ToArray();
            outputStream.Dispose();
            return output;
        }
        public static byte[] SWords(short[] values)
        {
            if (values is null) { throw new Exception("Bad values."); }

            MemoryStream outputStream = new MemoryStream();
            for (int i = 0; i < values.Length; i++)
            {
                Write.SWord(outputStream, values[i]);
            }
            byte[] output = outputStream.ToArray();
            outputStream.Dispose();
            return output;
        }
        public static byte[] DWords(uint[] values)
        {
            if (values is null) { throw new Exception("Bad values."); }

            MemoryStream outputStream = new MemoryStream();
            for (int i = 0; i < values.Length; i++)
            {
                Write.DWord(outputStream, values[i]);
            }
            byte[] output = outputStream.ToArray();
            outputStream.Dispose();
            return output;
        }
        public static byte[] SDWords(int[] values)
        {
            if (values is null) { throw new Exception("Bad values."); }

            MemoryStream outputStream = new MemoryStream();
            for (int i = 0; i < values.Length; i++)
            {
                Write.SDWord(outputStream, values[i]);
            }
            byte[] output = outputStream.ToArray();
            outputStream.Dispose();
            return output;
        }
        public static byte[] QWords(ulong[] values)
        {
            if (values is null) { throw new Exception("Bad values."); }

            MemoryStream outputStream = new MemoryStream();
            for (int i = 0; i < values.Length; i++)
            {
                Write.QWord(outputStream, values[i]);
            }
            byte[] output = outputStream.ToArray();
            outputStream.Dispose();
            return output;
        }
        public static byte[] SQWords(long[] values)
        {
            if (values is null) { throw new Exception("Bad values."); }

            MemoryStream outputStream = new MemoryStream();
            for (int i = 0; i < values.Length; i++)
            {
                Write.SQWord(outputStream, values[i]);
            }
            byte[] output = outputStream.ToArray();
            outputStream.Dispose();
            return output;
        }
        public static byte[] Real4s(float[] values)
        {
            if (values is null) { throw new Exception("Bad values."); }

            MemoryStream outputStream = new MemoryStream();
            for (int i = 0; i < values.Length; i++)
            {
                Write.Real4(outputStream, values[i]);
            }
            byte[] output = outputStream.ToArray();
            outputStream.Dispose();
            return output;
        }
        public static byte[] Real8s(double[] values)
        {
            if (values is null) { throw new Exception("Bad values."); }

            MemoryStream outputStream = new MemoryStream();
            for (int i = 0; i < values.Length; i++)
            {
                Write.Real8(outputStream, values[i]);
            }
            byte[] output = outputStream.ToArray();
            outputStream.Dispose();
            return output;
        }
    }
}