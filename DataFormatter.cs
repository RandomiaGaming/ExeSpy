using System.Runtime.InteropServices;
using System.Text;
using System;

namespace EXESpy
{
    public static class DF
    {
        public static T Parse<T>(TinyStream stream) where T : struct
        {
            int TSize = Marshal.SizeOf<T>();
            if (stream.buffer is null || stream.buffer.Length == 0)
            {
                throw new Exception("Buffer cannot be null or empty.");
            }
            if (stream.buffer.Length < TSize)
            {
                throw new Exception("Buffer was too small to contain an instance of T.");
            }
            if (stream.offset < 0 || stream.offset > stream.buffer.Length - TSize)
            {
                throw new Exception("Invalid offset. Offset must leave enough room for an instance of T.");
            }
            GCHandle handle = GCHandle.Alloc(stream.buffer, GCHandleType.Pinned);
            IntPtr pointer = IntPtr.Add(handle.AddrOfPinnedObject(), stream.offset);
            T output = Marshal.PtrToStructure<T>(pointer);
            handle.Free();
            stream.offset += TSize;
            return output;
        }
        public static byte[] Bytes<T>(T value) where T : struct
        {
            int sizeOfVal = Marshal.SizeOf(value);
            byte[] valBytes = new byte[sizeOfVal];
            IntPtr ptrToVal = Marshal.AllocHGlobal(sizeOfVal);
            Marshal.StructureToPtr(value, ptrToVal, true);
            Marshal.Copy(ptrToVal, valBytes, 0, sizeOfVal);
            Marshal.FreeHGlobal(ptrToVal);
            return valBytes;
        }

        public static string AsASCII<T>(T value) where T : struct
        {
            byte[] bytes = Bytes(value);
            return AsASCII(bytes);
        }
        public static string AsBytes<T>(T value) where T : struct
        {
            byte[] bytes = Bytes(value);
            return AsBytes(bytes);
        }
        public static string AsHex<T>(T value) where T : struct
        {
            byte[] bytes = Bytes(value);
            return AsHex(bytes);
        }
        public static string AsInt<T>(T value) where T : struct
        {
            byte[] bytes = Bytes(value);
            return AsInt(bytes);
        }
        public static string AsUInt<T>(T value) where T : struct
        {
            byte[] bytes = Bytes(value);
            return AsUInt(bytes);
        }
        public static string AsIntBigEndian<T>(T value) where T : struct
        {
            byte[] bytes = Bytes(value);
            return AsIntBigEndian(bytes);
        }
        public static string AsUIntBigEndian<T>(T value) where T : struct
        {
            byte[] bytes = Bytes(value);
            return AsUIntBigEndian(bytes);
        }
        public static string AsEpochTime<T>(T value) where T : struct
        {
            byte[] bytes = Bytes(value);
            return AsEpochTime(bytes);
        }

        public static string AsASCII(byte[] bytes)
        {
            return Encoding.ASCII.GetString(bytes);
        }
        public static string AsBytes(byte[] bytes)
        {
            return string.Join(", ", Array.ConvertAll(bytes, b => b.ToString()));
        }
        public static string AsHex(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder("0x");
            for (int i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("X2"));
            }
            return sb.ToString();
        }
        public static string AsInt(byte[] bytes)
        {
            if (bytes.Length < 8)
            {
                byte[] newBytes = new byte[8];
                Array.Copy(bytes, 0, newBytes, 0, bytes.Length);
                bytes = newBytes;
            }
            return BitConverter.ToInt64(bytes, 0).ToString();
        }
        public static string AsUInt(byte[] bytes)
        {
            if (bytes.Length < 8)
            {
                byte[] newBytes = new byte[8];
                Array.Copy(bytes, 0, newBytes, 0, bytes.Length);
                bytes = newBytes;
            }
            return BitConverter.ToUInt64(bytes, 0).ToString();
        }
        public static string AsIntBigEndian(byte[] bytes)
        {
            if (bytes.Length < 8)
            {
                byte[] newBytes = new byte[8];
                Array.Copy(bytes, 0, newBytes, 0, bytes.Length);
                bytes = newBytes;
            }
            Array.Reverse(bytes);
            return BitConverter.ToInt64(bytes, 0).ToString();
        }
        public static string AsUIntBigEndian(byte[] bytes)
        {
            if (bytes.Length < 8)
            {
                byte[] newBytes = new byte[8];
                Array.Copy(bytes, 0, newBytes, 0, bytes.Length);
                bytes = newBytes;
            }
            Array.Reverse(bytes);
            return BitConverter.ToUInt64(bytes, 0).ToString();
        }
        public static string AsEpochTime(byte[] bytes)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(BitConverter.ToUInt32(bytes, 0));
            return dateTimeOffset.LocalDateTime.ToString("h:mmtt MM/dd/yyyy").ToLower();
        }
    }
}