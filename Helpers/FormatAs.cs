using System;
using System.Collections.Generic;
using System.Text;
namespace ExeSpy
{
    // Formats data as strings in various ways.
    public static class FormatAs
    {
        private static bool Printable(char c)
        {
            return char.IsLetterOrDigit(c) || char.IsPunctuation(c) || char.IsSymbol(c) || char.IsWhiteSpace(c);
        }
        private static bool AllZeros(byte[] value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] != 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static string Binary(byte[] bytes)
        {
            if (bytes is null || bytes.Length <= 0) { throw new Exception("Bad bytes."); }

            // 9 because 1 space + 8 bits. Minus 1 to remove the last trailing space.
            char[] buffer = new char[(bytes.Length * 9) - 1];
            int offset = 0;
            for (int i = 0; i < bytes.Length; i++)
            {
                if (i != 0)
                {
                    buffer[offset] = ' ';
                    offset++;
                }

                byte b = bytes[i];

                buffer[offset + 0] = (b & 0x01) == 0 ? '0' : '1';
                buffer[offset + 1] = (b & 0x02) == 0 ? '0' : '1';
                buffer[offset + 2] = (b & 0x04) == 0 ? '0' : '1';
                buffer[offset + 3] = (b & 0x08) == 0 ? '0' : '1';
                buffer[offset + 4] = (b & 0x10) == 0 ? '0' : '1';
                buffer[offset + 5] = (b & 0x20) == 0 ? '0' : '1';
                buffer[offset + 6] = (b & 0x40) == 0 ? '0' : '1';
                buffer[offset + 7] = (b & 0x80) == 0 ? '0' : '1';

                offset += 8;
            }

            // Minus 1 to remove the last trailing space.
            return new string(buffer);
        }
        public static string Hex(byte[] bytes, bool abridgeZeros)
        {
            if (bytes is null || bytes.Length <= 0) { throw new Exception("Bad bytes."); }

            if (AllZeros(bytes))
            {
                return $"0x00 * {bytes.Length}";
            }

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
            if (bytes is null || bytes.Length <= 0) { throw new Exception("Bad bytes."); }

            // 5 because 1 comma + 1 space + up to 3 digits.
            StringBuilder stringBuilder = new StringBuilder(bytes.Length * 5);
            if (bytes.Length > 0)
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
        public static string Ascii(byte[] bytes, bool escapeNonPrintables)
        {
            if (bytes is null || bytes.Length <= 0) { throw new Exception("Bad bytes."); }

            string output = Encoding.ASCII.GetString(bytes);
            if (output.Length != bytes.Length)
            {
                throw new Exception("Bad bytes.");
            }

            if (escapeNonPrintables)
            {
                StringBuilder outputStringBuilder = new StringBuilder();
                for (int i = 0; i < output.Length; i++)
                {
                    if (!Printable(output[i]))
                    {
                        outputStringBuilder.Append("\\a");
                        outputStringBuilder.Append(((byte)output[i]).ToString("X2"));
                    }
                    else if (output[i] == '\\')
                    {
                        outputStringBuilder.Append("\\\\");
                    }
                    else
                    {
                        outputStringBuilder.Append(output[i]);
                    }
                }
                return outputStringBuilder.ToString();
            }
            else
            {
                return output;
            }
        }
        public static string Unicode(byte[] bytes, bool escapeNonPrintables)
        {
            if (bytes is null || bytes.Length <= 0) { throw new Exception("Bad bytes."); }

            string output = Encoding.Unicode.GetString(bytes);
            if (output.Length != (bytes.Length / 2))
            {
                throw new Exception("Bad bytes.");
            }

            if (escapeNonPrintables)
            {
                StringBuilder outputStringBuilder = new StringBuilder();
                for (int i = 0; i < output.Length; i++)
                {
                    if (!Printable(output[i]))
                    {
                        outputStringBuilder.Append("\\u");
                        outputStringBuilder.Append(((ushort)output[i]).ToString("X2"));
                    }
                    else if (output[i] == '\\')
                    {
                        outputStringBuilder.Append("\\\\");
                    }
                    else
                    {
                        outputStringBuilder.Append(output[i]);
                    }
                }
                return outputStringBuilder.ToString();
            }
            else
            {
                return output;
            }
        }
    }
    public static class Format
    {
        private const long EpochTicks = 621355968000000000L; // 12:00:00am on January 1st 1970 in coordinated universal time.

        public static string Epoch32(uint value)
        {
            return new DateTime(EpochTicks + (value * 10000000L)).ToString("h:mmtt MM/dd/yyyy").ToLower();
        }
        public static string Epoch64(ulong value)
        {
            return new DateTime(EpochTicks + ((long)(value) * 10000000L)).ToString("h:mmtt MM/dd/yyyy").ToLower();
        }

        public static string Enum8(byte value, Dictionary<byte, string> keyValuePairs, string unknownValue)
        {
            try
            {
                return keyValuePairs[value];
            }
            catch
            {
                return unknownValue;
            }
        }
        public static string Enum16(ushort value, Dictionary<ushort, string> keyValuePairs, string unknownValue)
        {
            try
            {
                return keyValuePairs[value];
            }
            catch
            {
                return unknownValue;
            }
        }
        public static string Enum32(uint value, Dictionary<uint, string> keyValuePairs, string unknownValue)
        {
            try
            {
                return keyValuePairs[value];
            }
            catch
            {
                return unknownValue;
            }
        }
        public static string Enum64(ulong value, Dictionary<ulong, string> keyValuePairs, string unknownValue)
        {
            try
            {
                return keyValuePairs[value];
            }
            catch
            {
                return unknownValue;
            }
        }

        public static string Flags8(byte value, Dictionary<byte, string> keyValuePairs, string noneValue)
        {
            StringBuilder outputStringBuilder = new StringBuilder();
            for (int i = 0; i < 8; i++)
            {
                byte currentBit = (byte)(1u << i);
                if ((currentBit & value) != 0)
                {
                    if (outputStringBuilder.Length != 0)
                    {
                        outputStringBuilder.Append(" | ");
                    }
                    try
                    {
                        outputStringBuilder.Append(keyValuePairs[currentBit]);
                    }
                    catch
                    {
                        outputStringBuilder.Append(FormatAs.Hex(Destruct.Byte(currentBit), false));
                    }
                }
            }
            if (outputStringBuilder.Length == 0)
            {
                return noneValue;
            }
            return outputStringBuilder.ToString();
        }
        public static string Flags16(ushort value, Dictionary<ushort, string> keyValuePairs, string noneValue)
        {
            StringBuilder outputStringBuilder = new StringBuilder();
            for (int i = 0; i < 16; i++)
            {
                ushort currentBit = (ushort)(1u << i);
                if ((currentBit & value) != 0)
                {
                    if (outputStringBuilder.Length != 0)
                    {
                        outputStringBuilder.Append(" | ");
                    }
                    try
                    {
                        outputStringBuilder.Append(keyValuePairs[currentBit]);
                    }
                    catch
                    {
                        outputStringBuilder.Append(FormatAs.Hex(Destruct.Word(currentBit), false));
                    }
                }
            }
            if (outputStringBuilder.Length == 0)
            {
                return noneValue;
            }
            return outputStringBuilder.ToString();
        }
        public static string Flags32(uint value, Dictionary<uint, string> keyValuePairs, string noneValue)
        {
            StringBuilder outputStringBuilder = new StringBuilder();
            for (int i = 0; i < 32; i++)
            {
                uint currentBit = 1u << i;
                if ((currentBit & value) != 0u)
                {
                    if (outputStringBuilder.Length != 0)
                    {
                        outputStringBuilder.Append(" | ");
                    }
                    try
                    {
                        outputStringBuilder.Append(keyValuePairs[currentBit]);
                    }
                    catch
                    {
                        outputStringBuilder.Append(FormatAs.Hex(Destruct.DWord(currentBit), false));
                    }
                }
            }
            if (outputStringBuilder.Length == 0)
            {
                return noneValue;
            }
            return outputStringBuilder.ToString();
        }
        public static string Flags64(ulong value, Dictionary<ulong, string> keyValuePairs, string noneValue)
        {
            StringBuilder outputStringBuilder = new StringBuilder();
            for (int i = 0; i < 64; i++)
            {
                ulong currentBit = 1uL << i;
                if ((currentBit & value) != 0uL)
                {
                    if (outputStringBuilder.Length != 0)
                    {
                        outputStringBuilder.Append(" | ");
                    }
                    try
                    {
                        outputStringBuilder.Append(keyValuePairs[currentBit]);
                    }
                    catch
                    {
                        outputStringBuilder.Append(FormatAs.Hex(Destruct.QWord(currentBit), false));
                    }
                }
            }
            if (outputStringBuilder.Length == 0)
            {
                return noneValue;
            }
            return outputStringBuilder.ToString();
        }
    }
}