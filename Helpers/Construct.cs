using System;
using System.Text;

namespace ExeSpy
{
    public static class Construct
    {
        public static byte Byte(byte[] buffer)
        {
            if (buffer is null || buffer.Length != 1) { throw new Exception("Bad buffer."); }

            return buffer[0];
        }
        public static sbyte SByte(byte[] buffer)
        {
            if (buffer is null || buffer.Length != 1) { throw new Exception("Bad buffer."); }

            return (sbyte)buffer[0];
        }
        public static ushort Word(byte[] buffer)
        {
            if (buffer is null || buffer.Length != 2) { throw new Exception("Bad buffer."); }

            return BitConverter.ToUInt16(buffer, 0);
        }
        public static short SWord(byte[] buffer)
        {
            if (buffer is null || buffer.Length != 2) { throw new Exception("Bad buffer."); }

            return BitConverter.ToInt16(buffer, 0);
        }
        public static uint DWord(byte[] buffer)
        {
            if (buffer is null || buffer.Length != 4) { throw new Exception("Bad buffer."); }

            return BitConverter.ToUInt32(buffer, 0);
        }
        public static int SDWord(byte[] buffer)
        {
            if (buffer is null || buffer.Length != 4) { throw new Exception("Bad buffer."); }

            return BitConverter.ToInt32(buffer, 0);
        }
        public static ulong QWord(byte[] buffer)
        {
            if (buffer is null || buffer.Length != 8) { throw new Exception("Bad buffer."); }

            return BitConverter.ToUInt64(buffer, 0);
        }
        public static long SQWord(byte[] buffer)
        {
            if (buffer is null || buffer.Length != 8) { throw new Exception("Bad buffer."); }

            return BitConverter.ToInt64(buffer, 0);
        }
        public static float Real4(byte[] buffer)
        {
            if (buffer is null || buffer.Length != 4) { throw new Exception("Bad buffer."); }

            return BitConverter.ToSingle(buffer, 0);
        }
        public static double Real8(byte[] buffer)
        {
            if (buffer is null || buffer.Length != 8) { throw new Exception("Bad buffer."); }

            return BitConverter.ToDouble(buffer, 0);
        }
        public static string ASCII(byte[] buffer)
        {
            if (buffer is null) { throw new Exception("Bad buffer."); }

            return Encoding.ASCII.GetString(buffer);
        }
        public static string UTF8(byte[] buffer)
        {
            if (buffer is null) { throw new Exception("Bad buffer."); }

            return Encoding.UTF8.GetString(buffer);
        }
        public static string UTF16(byte[] buffer)
        {
            if (buffer is null || buffer.Length % 2 != 0) { throw new Exception("Bad buffer."); }

            return Encoding.Unicode.GetString(buffer);
        }
        public static string UTF32(byte[] buffer)
        {
            if (buffer is null || buffer.Length % 4 != 0) { throw new Exception("Bad buffer."); }

            return Encoding.UTF32.GetString(buffer);
        }
        public static DateTime Epoch32(byte[] buffer)
        {
            if (buffer is null || buffer.Length != 4) { throw new Exception("Bad buffer."); }

            return new DateTime((10000000l * SDWord(buffer)) + DateTime.Parse("12:00am 01/01/1970 UTC").Ticks);
        }
        public static DateTime Epoch64(byte[] buffer)
        {
            if (buffer is null || buffer.Length != 8) { throw new Exception("Bad buffer."); }

            return new DateTime((10000000l * SQWord(buffer)) + DateTime.Parse("12:00am 01/01/1970 UTC").Ticks);
        }
    }
}