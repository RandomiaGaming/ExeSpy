using System;
using System.IO;

namespace ExeSpy
{
    public static class Read
    {
        public static byte[] Bytes(Stream stream, int length)
        {
            byte[] output = new byte[length];
            stream.Read(output, 0, length);
            return output;
        }
        public static byte Byte(Stream stream)
        {
            return Construct.Byte(Bytes(stream, 1));
        }
        public static sbyte SByte(Stream stream)
        {
            return Construct.SByte(Bytes(stream, 1));
        }
        public static ushort Word(Stream stream)
        {
            return Construct.Word(Bytes(stream, 2));
        }
        public static short SWord(Stream stream)
        {
            return Construct.SWord(Bytes(stream, 2));
        }
        public static uint DWord(Stream stream)
        {
            return Construct.DWord(Bytes(stream, 4));
        }
        public static int SDWord(Stream stream)
        {
            return Construct.SDWord(Bytes(stream, 4));
        }
        public static ulong QWord(Stream stream)
        {
            return Construct.QWord(Bytes(stream, 8));
        }
        public static long SQWord(Stream stream)
        {
            return Construct.SQWord(Bytes(stream, 8));
        }
        public static float Real4(Stream stream)
        {
            return Construct.Real4(Bytes(stream, 4));
        }
        public static double Real8(Stream stream)
        {
            return Construct.Real8(Bytes(stream, 8));
        }
        public static string ASCII(Stream stream, int length)
        {
            return Construct.ASCII(Bytes(stream, length));
        }
        public static string UTF8(Stream stream, int length)
        {
            return Construct.UTF8(Bytes(stream, length));
        }
        public static string UTF16(Stream stream, int length)
        {
            return Construct.UTF16(Bytes(stream, length));
        }
        public static string UTF32(Stream stream, int length)
        {
            return Construct.UTF32(Bytes(stream, length));
        }
        public static DateTime Epoch32(Stream stream)
        {
            return Construct.Epoch32(Bytes(stream, 4));
        }
        public static DateTime Epoch64(Stream stream)
        {
            return Construct.Epoch32(Bytes(stream, 8));
        }
    }
}