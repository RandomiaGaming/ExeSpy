using System;
using System.IO;
namespace ExeSpy
{
    // Reads C++ primative types and structures from streams.
    public static class Read
    {
        public static byte[] Bytes(Stream stream, int count)
        {
            if (stream is null || !stream.CanRead) { throw new Exception("Bad stream."); }
            if (count < 0) { throw new Exception("Bad count."); }

            byte[] output = new byte[count];
            int readBytes = stream.Read(output, 0, count);
            if (readBytes != count)
            {
                throw new Exception("Stream was too small.");
            }
            return output;
        }

        public static byte Byte(Stream stream)
        {
            if (stream is null || !stream.CanRead) { throw new Exception("Bad stream."); }

            return Construct.Byte(Bytes(stream, 1));
        }
        public static sbyte SByte(Stream stream)
        {
            if (stream is null || !stream.CanRead) { throw new Exception("Bad stream."); }

            return Construct.SByte(Bytes(stream, 1));
        }
        public static ushort Word(Stream stream)
        {
            if (stream is null || !stream.CanRead) { throw new Exception("Bad stream."); }

            return Construct.Word(Bytes(stream, 2));
        }
        public static short SWord(Stream stream)
        {
            if (stream is null || !stream.CanRead) { throw new Exception("Bad stream."); }

            return Construct.SWord(Bytes(stream, 2));
        }
        public static uint DWord(Stream stream)
        {
            if (stream is null || !stream.CanRead) { throw new Exception("Bad stream."); }

            return Construct.DWord(Bytes(stream, 4));
        }
        public static int SDWord(Stream stream)
        {
            if (stream is null || !stream.CanRead) { throw new Exception("Bad stream."); }

            return Construct.SDWord(Bytes(stream, 4));
        }
        public static ulong QWord(Stream stream)
        {
            if (stream is null || !stream.CanRead) { throw new Exception("Bad stream."); }

            return Construct.QWord(Bytes(stream, 8));
        }
        public static long SQWord(Stream stream)
        {
            if (stream is null || !stream.CanRead) { throw new Exception("Bad stream."); }

            return Construct.SQWord(Bytes(stream, 8));
        }
        public static float Real4(Stream stream)
        {
            if (stream is null || !stream.CanRead) { throw new Exception("Bad stream."); }

            return Construct.Real4(Bytes(stream, 4));
        }
        public static double Real8(Stream stream)
        {
            if (stream is null || !stream.CanRead) { throw new Exception("Bad stream."); }

            return Construct.Real8(Bytes(stream, 8));
        }

        public static sbyte[] SBytes(Stream stream, int count)
        {
            if (stream is null || !stream.CanRead) { throw new Exception("Bad stream."); }
            if (count < 0) { throw new Exception("Bad count."); }

            return Construct.SBytes(Bytes(stream, 1 * count), count);
        }
        public static ushort[] Words(Stream stream, int count)
        {
            if (stream is null || !stream.CanRead) { throw new Exception("Bad stream."); }
            if (count < 0) { throw new Exception("Bad count."); }

            return Construct.Words(Bytes(stream, 2 * count), count);
        }
        public static short[] SWords(Stream stream, int count)
        {
            if (stream is null || !stream.CanRead) { throw new Exception("Bad stream."); }
            if (count < 0) { throw new Exception("Bad count."); }

            return Construct.SWords(Bytes(stream, 2 * count), count);
        }
        public static uint[] DWords(Stream stream, int count)
        {
            if (stream is null || !stream.CanRead) { throw new Exception("Bad stream."); }
            if (count < 0) { throw new Exception("Bad count."); }

            return Construct.DWords(Bytes(stream, 4 * count), count);
        }
        public static int[] SDWords(Stream stream, int count)
        {
            if (stream is null || !stream.CanRead) { throw new Exception("Bad stream."); }
            if (count < 0) { throw new Exception("Bad count."); }

            return Construct.SDWords(Bytes(stream, 4 * count), count);
        }
        public static ulong[] QWords(Stream stream, int count)
        {
            if (stream is null || !stream.CanRead) { throw new Exception("Bad stream."); }
            if (count < 0) { throw new Exception("Bad count."); }

            return Construct.QWords(Bytes(stream, 8 * count), count);
        }
        public static long[] SQWords(Stream stream, int count)
        {
            if (stream is null || !stream.CanRead) { throw new Exception("Bad stream."); }
            if (count < 0) { throw new Exception("Bad count."); }

            return Construct.SQWords(Bytes(stream, 8 * count), count);
        }
        public static float[] Real4s(Stream stream, int count)
        {
            if (stream is null || !stream.CanRead) { throw new Exception("Bad stream."); }
            if (count < 0) { throw new Exception("Bad count."); }

            return Construct.Real4s(Bytes(stream, 4 * count), count);
        }
        public static double[] Real8s(Stream stream, int count)
        {
            if (stream is null || !stream.CanRead) { throw new Exception("Bad stream."); }
            if (count < 0) { throw new Exception("Bad count."); }

            return Construct.Real8s(Bytes(stream, 8 * count), count);
        }

        public static MZHeaderV1 MZHeaderV1(Stream stream)
        {
            if (stream is null || !stream.CanRead) { throw new Exception("Bad stream."); }

            MZHeaderV1 output = new MZHeaderV1();

            output.Magic = Word(stream);
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
            if (stream is null || !stream.CanRead) { throw new Exception("Bad stream."); }

            MZHeaderV2 output = new MZHeaderV2();

            output.Magic = Word(stream);
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
            output.NewHeaderFileAddress = DWord(stream);

            return output;
        }
        public static PEHeader PEHeader(Stream stream)
        {
            if (stream is null || !stream.CanRead) { throw new Exception("Bad stream."); }

            PEHeader output = new PEHeader();

            output.Magic = DWord(stream);
            output.Machine = Word(stream);
            output.NumberOfSections = Word(stream);
            output.DateTimeStamp = DWord(stream);
            output.PointerToSymbolTable = DWord(stream);
            output.NumberOfSymbols = DWord(stream);
            output.SizeOfOptionalHeader = Word(stream);
            output.Characteristics = Word(stream);

            return output;
        }
        public static PEOptionalHeader PEOptionalHeader(Stream stream)
        {
            if (stream is null || !stream.CanRead) { throw new Exception("Bad stream."); }

            PEOptionalHeader output = new PEOptionalHeader();

            output.Magic = Word(stream);
            output.MajorLinkerVersion = Byte(stream);
            output.MinorLinkerVersion = Byte(stream);
            output.SizeOfCode = DWord(stream);
            output.SizeOfInitializedData = DWord(stream);
            output.SizeOfUninitializedData = DWord(stream);
            output.AddressOfEntryPoint = DWord(stream);
            output.BaseOfCode = DWord(stream);
            output.BaseOfData = DWord(stream);
            output.ImageBase = DWord(stream);
            output.SectionAlignment = DWord(stream);
            output.FileAlignment = DWord(stream);
            output.MajorOperatingSystemVersion = Word(stream);
            output.MinorOperatingSystemVersion = Word(stream);
            output.MajorImageVersion = Word(stream);
            output.MinorImageVersion = Word(stream);
            output.MajorSubsystemVersion = Word(stream);
            output.MinorSubsystemVersion = Word(stream);
            output.Win32VersionValue = DWord(stream);
            output.SizeOfImage = DWord(stream);
            output.SizeOfHeaders = DWord(stream);
            output.CheckSum = DWord(stream);
            output.Subsystem = Word(stream);
            output.DllCharacteristics = Word(stream);
            output.SizeOfStackReserve = DWord(stream);
            output.SizeOfStackCommit = DWord(stream);
            output.SizeOfHeapReserve = DWord(stream);
            output.SizeOfHeapCommit = DWord(stream);
            output.LoaderFlags = DWord(stream);
            output.NumberOfRvaAndSizes = DWord(stream);

            return output;
        }
        public static PEDataDirectory PEDataDirectory(Stream stream)
        {
            if (stream is null || !stream.CanRead) { throw new Exception("Bad stream."); }

            PEDataDirectory output = new PEDataDirectory();

            output.VirtualSize = DWord(stream);
            output.VirtualAddress = DWord(stream);

            return output;
        }
        public static PESectionHeader PESectionHeader(Stream stream)
        {
            if (stream is null || !stream.CanRead) { throw new Exception("Bad stream."); }

            PESectionHeader output = new PESectionHeader();

            output.Name = QWord(stream);
            output.VirtualSize = DWord(stream);
            output.VirtualAddress = DWord(stream);
            output.SizeOfRawData = DWord(stream);
            output.PointerToRawData = DWord(stream);
            output.PointerToRelocations = DWord(stream);
            output.PointerToLinenumbers = DWord(stream);
            output.NumberOfRelocations = Word(stream);
            output.NumberOfLinenumbers = Word(stream);
            output.Characteristics = DWord(stream);

            return output;
        }
        public static byte[] PESection(Stream stream, PESectionHeader header)
        {
            if (stream is null || !stream.CanRead) { throw new Exception("Bad stream."); }
            if (header is null) { throw new Exception("Bad header."); }

            int payloadLength = (int)header.SizeOfRawData;
            if(payloadLength > header.VirtualSize)
            {
                payloadLength = (int)header.VirtualSize;
            }

            byte[] payload = Bytes(stream, payloadLength);

            return payload;
        }
    }
}