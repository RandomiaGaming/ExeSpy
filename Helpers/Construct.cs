using System;
using System.Text;

namespace ExeSpy
{
    public static class Construct
    {
        public static byte Byte(byte[] buffer)
        {
            return buffer[0];
        }
        public static sbyte SByte(byte[] buffer)
        {
            return (sbyte)buffer[0];
        }
        public static ushort Word(byte[] buffer)
        {
            return BitConverter.ToUInt16(buffer, 0);
        }
        public static short SWord(byte[] buffer)
        {
            return BitConverter.ToInt16(buffer, 0);
        }
        public static uint DWord(byte[] buffer)
        {
            return BitConverter.ToUInt32(buffer, 0);
        }
        public static int SDWord(byte[] buffer)
        {
            return BitConverter.ToInt32(buffer, 0);
        }
        public static ulong QWord(byte[] buffer)
        {
            return BitConverter.ToUInt64(buffer, 0);
        }
        public static long SQWord(byte[] buffer)
        {
            return BitConverter.ToInt64(buffer, 0);
        }
        public static float Real4(byte[] buffer)
        {
            return BitConverter.ToSingle(buffer, 0);
        }
        public static double Real8(byte[] buffer)
        {
            return BitConverter.ToDouble(buffer, 0);
        }
        public static string ASCII(byte[] buffer)
        {
            return Encoding.ASCII.GetString(buffer);
        }
        public static string UTF8(byte[] buffer)
        {
            return Encoding.UTF8.GetString(buffer);
        }
        public static string UTF16(byte[] buffer)
        {
            return Encoding.Unicode.GetString(buffer);
        }
        public static string UTF32(byte[] buffer)
        {
            return Encoding.UTF32.GetString(buffer);
        }
        public static DateTime Epoch32(byte[] buffer)
        {
           return DateTimeOffset.FromUnixTimeSeconds(DWord(buffer)).LocalDateTime;
        }
        public static DateTime Epoch64(byte[] buffer)
        {
            return DateTimeOffset.FromUnixTimeSeconds(SQWord(buffer)).LocalDateTime;
        }
    }
}