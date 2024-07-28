using System;
using System.IO;

namespace ExeSpy
{
    public static class Write
    {
        public static void Byte(Stream stream, byte value)
        {
            if (stream is null || !stream.CanWrite || stream.Position + 1 > stream.Length) { throw new Exception("Bad stream."); }

            Bytes(stream, Destruct.Byte(value));
        }
        public static void SByte(Stream stream, sbyte value)
        {
            if (stream is null || !stream.CanWrite || stream.Position + 1 > stream.Length) { throw new Exception("Bad stream."); }

            Bytes(stream, Destruct.SByte(value));
        }
        public static void Word(Stream stream, ushort value)
        {
            if (stream is null || !stream.CanWrite || stream.Position + 2 > stream.Length) { throw new Exception("Bad stream."); }

            Bytes(stream, Destruct.Word(value));
        }
        public static void SWord(Stream stream, short value)
        {
            if (stream is null || !stream.CanWrite || stream.Position + 2 > stream.Length) { throw new Exception("Bad stream."); }

            Bytes(stream, Destruct.SWord(value));
        }
        public static void DWord(Stream stream, uint value)
        {
            if (stream is null || !stream.CanWrite || stream.Position + 4 > stream.Length) { throw new Exception("Bad stream."); }

            Bytes(stream, Destruct.DWord(value));
        }
        public static void SDWord(Stream stream, int value)
        {
            if (stream is null || !stream.CanWrite || stream.Position + 4 > stream.Length) { throw new Exception("Bad stream."); }

            Bytes(stream, Destruct.SDWord(value));
        }
        public static void QWord(Stream stream, ulong value)
        {
            if (stream is null || !stream.CanWrite || stream.Position + 8 > stream.Length) { throw new Exception("Bad stream."); }

            Bytes(stream, Destruct.QWord(value));
        }
        public static void SQWord(Stream stream, long value)
        {
            if (stream is null || !stream.CanWrite || stream.Position + 8 > stream.Length) { throw new Exception("Bad stream."); }

            Bytes(stream, Destruct.SQWord(value));
        }
        public static void Real4(Stream stream, float value)
        {
            if (stream is null || !stream.CanWrite || stream.Position + 4 > stream.Length) { throw new Exception("Bad stream."); }

            Bytes(stream, Destruct.Real4(value));
        }
        public static void Real8(Stream stream, double value)
        {
            if (stream is null || !stream.CanWrite || stream.Position + 8 > stream.Length) { throw new Exception("Bad stream."); }

            Bytes(stream, Destruct.Real8(value));
        }
        public static void Epoch32(Stream stream, DateTime value)
        {
            if (stream is null || !stream.CanWrite || stream.Position + 4 > stream.Length) { throw new Exception("Bad stream."); }

            Bytes(stream, Destruct.Epoch32(value));
        }
        public static void Epoch64(Stream stream, DateTime value)
        {
            if (stream is null || !stream.CanWrite || stream.Position + 8 > stream.Length) { throw new Exception("Bad stream."); }

            Bytes(stream, Destruct.Epoch64(value));
        }

        public static void Bytes(Stream stream, byte[] values)
        {
            if (values is null) { throw new Exception("Bad values."); }
            if (stream is null || !stream.CanWrite || stream.Position + (1 * values.Length) > stream.Length) { throw new Exception("Bad stream."); }

            for (int i = 0; i < values.Length; i++)
            {
                Byte(stream, values[i]);
            }
        }
        public static void SBytes(Stream stream, sbyte[] values)
        {
            if (values is null) { throw new Exception("Bad values."); }
            if (stream is null || !stream.CanWrite || stream.Position + (1 * values.Length) > stream.Length) { throw new Exception("Bad stream."); }

            for (int i = 0; i < values.Length; i++)
            {
                SByte(stream, values[i]);
            }
        }
        public static void Words(Stream stream, ushort[] values)
        {
            if (values is null) { throw new Exception("Bad values."); }
            if (stream is null || !stream.CanWrite || stream.Position + (2 * values.Length) > stream.Length) { throw new Exception("Bad stream."); }

            for (int i = 0; i < values.Length; i++)
            {
                Word(stream, values[i]);
            }
        }
        public static void SWords(Stream stream, short[] values)
        {
            if (values is null) { throw new Exception("Bad values."); }
            if (stream is null || !stream.CanWrite || stream.Position + (2 * values.Length) > stream.Length) { throw new Exception("Bad stream."); }

            for (int i = 0; i < values.Length; i++)
            {
                SWord(stream, values[i]);
            }
        }
        public static void DWords(Stream stream, uint[] values)
        {
            if (values is null) { throw new Exception("Bad values."); }
            if (stream is null || !stream.CanWrite || stream.Position + (4 * values.Length) > stream.Length) { throw new Exception("Bad stream."); }

            for (int i = 0; i < values.Length; i++)
            {
                DWord(stream, values[i]);
            }
        }
        public static void SDWords(Stream stream, int[] values)
        {
            if (values is null) { throw new Exception("Bad values."); }
            if (stream is null || !stream.CanWrite || stream.Position + (4 * values.Length) > stream.Length) { throw new Exception("Bad stream."); }

            for (int i = 0; i < values.Length; i++)
            {
                SDWord(stream, values[i]);
            }
        }
        public static void QWords(Stream stream, ulong[] values)
        {
            if (values is null) { throw new Exception("Bad values."); }
            if (stream is null || !stream.CanWrite || stream.Position + (8 * values.Length) > stream.Length) { throw new Exception("Bad stream."); }

            for (int i = 0; i < values.Length; i++)
            {
                QWord(stream, values[i]);
            }
        }
        public static void SQWords(Stream stream, long[] values)
        {
            if (values is null) { throw new Exception("Bad values."); }
            if (stream is null || !stream.CanWrite || stream.Position + (8 * values.Length) > stream.Length) { throw new Exception("Bad stream."); }

            for (int i = 0; i < values.Length; i++)
            {
                SQWord(stream, values[i]);
            }
        }
        public static void Real4s(Stream stream, float[] values)
        {
            if (values is null) { throw new Exception("Bad values."); }
            if (stream is null || !stream.CanWrite || stream.Position + (4 * values.Length) > stream.Length) { throw new Exception("Bad stream."); }

            for (int i = 0; i < values.Length; i++)
            {
                Real4(stream, values[i]);
            }
        }
        public static void Real8s(Stream stream, double[] values)
        {
            if (values is null) { throw new Exception("Bad values."); }
            if (stream is null || !stream.CanWrite || stream.Position + (8 * values.Length) > stream.Length) { throw new Exception("Bad stream."); }

            for (int i = 0; i < values.Length; i++)
            {
                Real8(stream, values[i]);
            }
        }
        public static void Epoch32s(Stream stream, DateTime[] values)
        {
            if (values is null) { throw new Exception("Bad values."); }
            if (stream is null || !stream.CanWrite || stream.Position + (4 * values.Length) > stream.Length) { throw new Exception("Bad stream."); }

            for (int i = 0; i < values.Length; i++)
            {
                Epoch32(stream, values[i]);
            }
        }
        public static void Epoch64s(Stream stream, DateTime[] values)
        {
            if (values is null) { throw new Exception("Bad values."); }
            if (stream is null || !stream.CanWrite || stream.Position + (8 * values.Length) > stream.Length) { throw new Exception("Bad stream."); }

            for (int i = 0; i < values.Length; i++)
            {
                Epoch64(stream, values[i]);
            }
        }

        public static void ASCII(Stream stream, string value)
        {
            if (value is null) { throw new Exception("Bad value."); }
            if (stream is null || !stream.CanWrite || stream.Position + (1 * value.Length) > stream.Length) { throw new Exception("Bad stream."); }

            Bytes(stream, Destruct.ASCII(value));
        }
        public static void UTF8(Stream stream, string value)
        {
            if (value is null) { throw new Exception("Bad value."); }
            if (stream is null || !stream.CanWrite || stream.Position + (1 * value.Length) > stream.Length) { throw new Exception("Bad stream."); }

            Bytes(stream, Destruct.UTF8(value));
        }
        public static void UTF16(Stream stream, string value)
        {
            if (value is null) { throw new Exception("Bad value."); }
            if (stream is null || !stream.CanWrite || stream.Position + (2 * value.Length) > stream.Length) { throw new Exception("Bad stream."); }

            Bytes(stream, Destruct.UTF16(value));
        }
        public static void UTF32(Stream stream, string value)
        {
            if (value is null) { throw new Exception("Bad value."); }
            if (stream is null || !stream.CanWrite || stream.Position + (4 * value.Length) > stream.Length) { throw new Exception("Bad stream."); }

            Bytes(stream, Destruct.UTF32(value));
        }

        public static void MZHeaderV1(Stream stream, MZHeaderV1 value)
        {
            if (stream is null || !stream.CanWrite) { throw new Exception("Bad stream."); }
            if (stream.Position + ExeSpy.MZHeaderV1.Size >= stream.Length) { throw new Exception("Stream too small."); }

            ValidateSizeOf.MZHeaderV1(value);

            Word(stream, Construct.Word(Destruct.ASCII(value.MagicString)));
            Word(stream, value.LastPageLength);
            Word(stream, value.PageCount);
            Word(stream, value.RelocationEntiryCount);
            Word(stream, value.HeaderSize);
            Word(stream, value.MinimumAllocation);
            Word(stream, value.MaximumAllocation);
            Word(stream, value.InitialSS);
            Word(stream, value.InitialSP);
            Word(stream, value.Checksum);
            Word(stream, value.InitialIP);
            Word(stream, value.InitialCS);
            Word(stream, value.RelocationTableFileAddress);
            Word(stream, value.Overlay);
        }
        public static void MZHeaderV2(Stream stream, MZHeaderV2 value)
        {
            if (stream is null || !stream.CanWrite) { throw new Exception("Bad stream."); }
            if (stream.Position + ExeSpy.MZHeaderV2.Size >= stream.Length) { throw new Exception("Stream too small."); }

            ValidateSizeOf.MZHeaderV2(value);

            Word(stream, Construct.Word(Destruct.ASCII(value.MagicString)));
            Word(stream, value.LastPageLength);
            Word(stream, value.PageCount);
            Word(stream, value.RelocationEntiryCount);
            Word(stream, value.HeaderSize);
            Word(stream, value.MinimumAllocation);
            Word(stream, value.MaximumAllocation);
            Word(stream, value.InitialSS);
            Word(stream, value.InitialSP);
            Word(stream, value.Checksum);
            Word(stream, value.InitialIP);
            Word(stream, value.InitialCS);
            Word(stream, value.RelocationTableFileAddress);
            Word(stream, value.Overlay);
            Words(stream, value.Reserved1);
            Word(stream, value.OEMIdentifier);
            Word(stream, value.OEMInfo);
            Words(stream, value.Reserved2);
            SQWord(stream, value.NewHeaderFileAddress);
        }
    }
}