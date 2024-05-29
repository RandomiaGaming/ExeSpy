using System;
using System.Text;

namespace ExeSpy.Helpers
{
    public static class FormatAs
    {
        public static string Binary(byte[] bytes)
        {
            // 9 because 1 space + 8 bits.
            char[] buffer = new char[bytes.Length * 9];
            int offset = 0;
            for (int i = 0; i < bytes.Length; i++)
            {
                byte b = bytes[i];
                buffer[offset] = (b & 1) == 0 ? '0' : '1';
                buffer[offset + 1] = (b & 2) == 0 ? '0' : '1';
                buffer[offset + 2] = (b & 4) == 0 ? '0' : '1';
                buffer[offset + 3] = (b & 8) == 0 ? '0' : '1';
                buffer[offset + 4] = (b & 16) == 0 ? '0' : '1';
                buffer[offset + 5] = (b & 32) == 0 ? '0' : '1';
                buffer[offset + 6] = (b & 64) == 0 ? '0' : '1';
                buffer[offset + 7] = (b & 128) == 0 ? '0' : '1';

                buffer[offset + 8] = ' ';
                offset += 9;
            }
            // Minus 1 to remove the last trailing space.
            return new string(buffer, 0, buffer.Length - 1);
        }
        public static string Hex(byte[] bytes)
        {
            // 2 because 2 hex digits.
            StringBuilder stringBuilder = new StringBuilder("0x", bytes.Length * 2);
            for (int i = 0; i < bytes.Length; i++)
            {
                stringBuilder.Append(bytes[i].ToString("X2"));
            }
            return stringBuilder.ToString();
        }
        public static string Bytes(byte[] bytes)
        {
            // 5 because 1 comma + 1 space + up to 3 digits.
            StringBuilder stringBuilder = new StringBuilder(bytes.Length * 5);
            if(bytes.Length > 0)
            {
                stringBuilder.Append(bytes[0].ToString());
            }
            for (int i = 1; i < bytes.Length; i++)
            {
                stringBuilder.Append(", ");
                stringBuilder.Append(bytes[i].ToString());
            }
            return stringBuilder.ToString();
        }
    }
    public static class Format
    {
        public static string Time(DateTime value)
        {
            return value.ToString("h:mmtt MM/dd/yyyy").ToLower();
        }
    }
}