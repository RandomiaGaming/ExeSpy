using System;
using System.IO;

namespace ExeSpy
{
    public static class Write
    {
        public static void Bytes(Stream stream, byte[] bytes)
        {
            stream.Write(bytes, 0, bytes.Length);
        }
        public static void Byte(Stream stream, byte value)
        {
            Bytes(stream, Destruct.Byte(value));
        }
        public static void SByte(Stream stream, sbyte value)
        {
            Bytes(stream, Destruct.SByte(value));
        }
        public static void Word(Stream stream, ushort value)
        {
            Bytes(stream, Destruct.Word(value));
        }
        public static void SWord(Stream stream, short value)
        {
            Bytes(stream, Destruct.SWord(value));
        }
        public static void DWord(Stream stream, uint value)
        {
            Bytes(stream, Destruct.DWord(value));
        }
        public static void SDWord(Stream stream, int value)
        {
            Bytes(stream, Destruct.SDWord(value));
        }
        public static void QWord(Stream stream, ulong value)
        {
            Bytes(stream, Destruct.QWord(value));
        }
        public static void SQWord(Stream stream, long value)
        {
            Bytes(stream, Destruct.SQWord(value));
        }
        public static void Real4(Stream stream, float value)
        {
            Bytes(stream, Destruct.Real4(value));
        }
        public static void Real8(Stream stream, double value)
        {
            Bytes(stream, Destruct.Real8(value));
        }
        public static void ASCII(Stream stream, string value)
        {
            Bytes(stream, Destruct.ASCII(value));
        }
        public static void UTF8(Stream stream, string value)
        {
            Bytes(stream, Destruct.UTF8(value));
        }
        public static void UTF16(Stream stream, string value)
        {
            Bytes(stream, Destruct.UTF16(value));
        }
        public static void UTF32(Stream stream, string value)
        {
            Bytes(stream, Destruct.UTF32(value));
        }
        public static void Epoch32(Stream stream, DateTime value)
        {
            Bytes(stream, Destruct.Epoch32(value));
        }
        public static void Epoch64(Stream stream, DateTime value)
        {
            Bytes(stream, Destruct.Epoch64(value));
        }
    }
}