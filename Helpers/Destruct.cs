using System;
using System.Text;

namespace ExeSpy
{
    public static class Destruct
    {
        public static byte[] Byte(byte value)
        {
            return new byte[1] { value };
        }
        public static byte[] SByte(sbyte value)
        {
            return new byte[1] { (byte)value };
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
        public static byte[] ASCII(string value)
        {
            return Encoding.ASCII.GetBytes(value);
        }
        public static byte[] UTF8(string value)
        {
            return Encoding.UTF8.GetBytes(value);
        }
        public static byte[] UTF16(string value)
        {
            return Encoding.Unicode.GetBytes(value);
        }
        public static byte[] UTF32(string value)
        {
            return Encoding.UTF32.GetBytes(value);
        }
        public static byte[] Epoch32(DateTime value)
        {
            // 621355968000000000 = Epoch start date in ticks (12:00am 01/01/1970 UTC).
            // 10000000 = Number of ticks in one second.
            return DWord((uint)((621355968000000000ul - (ulong)value.Ticks) / 10000000ul));
        }
        public static byte[] Epoch64(DateTime value)
        {
            // 621355968000000000 = Epoch start date in ticks (12:00am 01/01/1970 UTC).
            // 10000000 = Number of ticks in one second.
            return QWord((621355968000000000ul - (ulong)value.Ticks) / 10000000ul);
        }
    }
}