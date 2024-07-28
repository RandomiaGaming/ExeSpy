using System;
using System.IO;

namespace ExeSpy
{
    public static class Read
    {
        public static byte Byte(Stream stream)
        {
            if (stream is null || !stream.CanRead || stream.Position + 1 > stream.Length) { throw new Exception("Bad stream."); }

            return Construct.Byte(Bytes(stream, 1));
        }
        public static sbyte SByte(Stream stream)
        {
            if (stream is null || !stream.CanRead || stream.Position + 1 > stream.Length) { throw new Exception("Bad stream."); }

            return Construct.SByte(Bytes(stream, 1));
        }
        public static ushort Word(Stream stream)
        {
            if (stream is null || !stream.CanRead || stream.Position + 2 > stream.Length) { throw new Exception("Bad stream."); }

            return Construct.Word(Bytes(stream, 2));
        }
        public static short SWord(Stream stream)
        {
            if (stream is null || !stream.CanRead || stream.Position + 2 > stream.Length) { throw new Exception("Bad stream."); }

            return Construct.SWord(Bytes(stream, 2));
        }
        public static uint DWord(Stream stream)
        {
            if (stream is null || !stream.CanRead || stream.Position + 4 > stream.Length) { throw new Exception("Bad stream."); }

            return Construct.DWord(Bytes(stream, 4));
        }
        public static int SDWord(Stream stream)
        {
            if (stream is null || !stream.CanRead || stream.Position + 4 > stream.Length) { throw new Exception("Bad stream."); }

            return Construct.SDWord(Bytes(stream, 4));
        }
        public static ulong QWord(Stream stream)
        {
            if (stream is null || !stream.CanRead || stream.Position + 8 > stream.Length) { throw new Exception("Bad stream."); }

            return Construct.QWord(Bytes(stream, 8));
        }
        public static long SQWord(Stream stream)
        {
            if (stream is null || !stream.CanRead || stream.Position + 8 > stream.Length) { throw new Exception("Bad stream."); }

            return Construct.SQWord(Bytes(stream, 8));
        }
        public static float Real4(Stream stream)
        {
            if (stream is null || !stream.CanRead || stream.Position + 4 > stream.Length) { throw new Exception("Bad stream."); }

            return Construct.Real4(Bytes(stream, 4));
        }
        public static double Real8(Stream stream)
        {
            if (stream is null || !stream.CanRead || stream.Position + 8 > stream.Length) { throw new Exception("Bad stream."); }

            return Construct.Real8(Bytes(stream, 8));
        }
        public static DateTime Epoch32(Stream stream)
        {
            if (stream is null || !stream.CanRead || stream.Position + 4 > stream.Length) { throw new Exception("Bad stream."); }

            return Construct.Epoch32(Bytes(stream, 4));
        }
        public static DateTime Epoch64(Stream stream)
        {
            if (stream is null || !stream.CanRead || stream.Position + 8 > stream.Length) { throw new Exception("Bad stream."); }

            return Construct.Epoch32(Bytes(stream, 8));
        }

        public static byte[] Bytes(Stream stream, int count)
        {
            if (stream is null || !stream.CanRead || stream.Position + (1 * count) > stream.Length) { throw new Exception("Bad stream."); }
            if (count < 0) { throw new Exception("Bad count."); }

            byte[] output = new byte[count];
            stream.Read(output, 0, count);
            return output;
        }
        public static sbyte[] SBytes(Stream stream, int count)
        {
            if (stream is null || !stream.CanRead || stream.Position + (1 * count) > stream.Length) { throw new Exception("Bad stream."); }

            sbyte[] output = new sbyte[count];
            for (int i = 0; i < count; i++)
            {
                output[i] = SByte(stream);
            }
            return output;
        }
        public static ushort[] Words(Stream stream, int count)
        {
            if (stream is null || !stream.CanRead || stream.Position + (2 * count) > stream.Length) { throw new Exception("Bad stream."); }

            ushort[] output = new ushort[count];
            for (int i = 0; i < count; i++)
            {
                output[i] = Word(stream);
            }
            return output;
        }
        public static short[] SWords(Stream stream, int count)
        {
            if (stream is null || !stream.CanRead || stream.Position + (2 * count) > stream.Length) { throw new Exception("Bad stream."); }

            short[] output = new short[count];
            for (int i = 0; i < count; i++)
            {
                output[i] = SWord(stream);
            }
            return output;
        }
        public static uint[] DWords(Stream stream, int count)
        {
            if (stream is null || !stream.CanRead || stream.Position + (4 * count) > stream.Length) { throw new Exception("Bad stream."); }

            uint[] output = new uint[count];
            for (int i = 0; i < count; i++)
            {
                output[i] = DWord(stream);
            }
            return output;
        }
        public static int[] SDWords(Stream stream, int count)
        {
            if (stream is null || !stream.CanRead || stream.Position + (4 * count) > stream.Length) { throw new Exception("Bad stream."); }

            int[] output = new int[count];
            for (int i = 0; i < count; i++)
            {
                output[i] = SDWord(stream);
            }
            return output;
        }
        public static ulong[] QWords(Stream stream, int count)
        {
            if (stream is null || !stream.CanRead || stream.Position + (8 * count) > stream.Length) { throw new Exception("Bad stream."); }

            ulong[] output = new ulong[count];
            for (int i = 0; i < count; i++)
            {
                output[i] = QWord(stream);
            }
            return output;
        }
        public static long[] SQWords(Stream stream, int count)
        {
            if (stream is null || !stream.CanRead || stream.Position + (8 * count) > stream.Length) { throw new Exception("Bad stream."); }

            long[] output = new long[count];
            for (int i = 0; i < count; i++)
            {
                output[i] = SQWord(stream);
            }
            return output;
        }
        public static float[] Real4s(Stream stream, int count)
        {
            if (stream is null || !stream.CanRead || stream.Position + (4 * count) > stream.Length) { throw new Exception("Bad stream."); }

            float[] output = new float[count];
            for (int i = 0; i < count; i++)
            {
                output[i] = Real4(stream);
            }
            return output;
        }
        public static double[] Real8s(Stream stream, int count)
        {
            if (stream is null || !stream.CanRead || stream.Position + (8 * count) > stream.Length) { throw new Exception("Bad stream."); }

            double[] output = new double[count];
            for (int i = 0; i < count; i++)
            {
                output[i] = Real8(stream);
            }
            return output;
        }
        public static DateTime[] Epoch32s(Stream stream, int count)
        {
            if (stream is null || !stream.CanRead || stream.Position + (4 * count) > stream.Length) { throw new Exception("Bad stream."); }

            DateTime[] output = new DateTime[count];
            for (int i = 0; i < count; i++)
            {
                output[i] = Epoch32(stream);
            }
            return output;
        }
        public static DateTime[] Epoch64s(Stream stream, int count)
        {
            if (stream is null || !stream.CanRead || stream.Position + (8 * count) > stream.Length) { throw new Exception("Bad stream."); }

            DateTime[] output = new DateTime[count];
            for (int i = 0; i < count; i++)
            {
                output[i] = Epoch64(stream);
            }
            return output;
        }

        public static string ASCII(Stream stream, int count)
        {
            if (stream is null || !stream.CanRead || stream.Position + (1 * count) > stream.Length) { throw new Exception("Bad stream."); }
            if (count < 0) { throw new Exception("Bad count."); }

            return Construct.ASCII(Bytes(stream, count));
        }
        public static string UTF8(Stream stream, int count)
        {
            if (stream is null || !stream.CanRead || stream.Position + (1 * count) > stream.Length) { throw new Exception("Bad stream."); }
            if (count < 0) { throw new Exception("Bad count."); }

            return Construct.UTF8(Bytes(stream, count));
        }
        public static string UTF16(Stream stream, int count)
        {
            if (stream is null || !stream.CanRead || stream.Position + (2 * count) > stream.Length) { throw new Exception("Bad stream."); }
            if (count < 0) { throw new Exception("Bad count."); }

            return Construct.UTF16(Bytes(stream, count));
        }
        public static string UTF32(Stream stream, int count)
        {
            if (stream is null || !stream.CanRead || stream.Position + (4 * count) > stream.Length) { throw new Exception("Bad stream."); }
            if (count < 0) { throw new Exception("Bad count."); }

            return Construct.UTF32(Bytes(stream, count));
        }

        public static MZHeaderV1 MZHeaderV1(Stream stream)
        {
            if (stream is null || !stream.CanRead || stream.Position + ExeSpy.MZHeaderV1.Size > stream.Length) { throw new Exception("Bad stream."); }

            MZHeaderV1 output = new MZHeaderV1();

            output.MagicString = ASCII(stream, 2);
            output.LastPageLength = Word(stream);
            output.PageCount = Word(stream);
            output.RelocationEntiryCount = Word(stream);
            output.HeaderSize = Word(stream);
            output.MinimumAllocation = Word(stream);
            output.MaximumAllocation = Word(stream);
            output.InitialSS = Word(stream);
            output.InitialSP = Word(stream);
            output.Checksum = Word(stream);
            output.InitialIP = Word(stream);
            output.InitialCS = Word(stream);
            output.RelocationTableFileAddress = Word(stream);
            output.Overlay = Word(stream);

            return output;
        }
        public static MZHeaderV2 MZHeaderV2(Stream stream)
        {
            if (stream is null || !stream.CanRead || stream.Position + ExeSpy.MZHeaderV2.Size > stream.Length) { throw new Exception("Bad stream."); }

            MZHeaderV2 output = new MZHeaderV2();

            output.MagicString = ASCII(stream, 2);
            output.LastPageLength = Word(stream);
            output.PageCount = Word(stream);
            output.RelocationEntiryCount = Word(stream);
            output.HeaderSize = Word(stream);
            output.MinimumAllocation = Word(stream);
            output.MaximumAllocation = Word(stream);
            output.InitialSS = Word(stream);
            output.InitialSP = Word(stream);
            output.Checksum = Word(stream);
            output.InitialIP = Word(stream);
            output.InitialCS = Word(stream);
            output.RelocationTableFileAddress = Word(stream);
            output.Overlay = Word(stream);
            output.Reserved1 = Words(stream, 4);
            output.OEMIdentifier = Word(stream);
            output.OEMInfo = Word(stream);
            output.Reserved2 = Words(stream, 10);
            output.NewHeaderFileAddress = SQWord(stream);

            return output;
        }
    }
}