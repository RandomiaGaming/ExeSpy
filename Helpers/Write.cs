using System;
using System.IO;
namespace ExeSpy
{
    // Writes C++ primative types and structures to streams.
    public static class Write
    {
        public static void Bytes(Stream stream, byte[] values)
        {
            if (values is null) { throw new Exception("Bad values."); }
            if (stream is null || !stream.CanWrite) { throw new Exception("Bad stream."); }

            stream.Write(values, 0, values.Length);
        }

        public static void Byte(Stream stream, byte value)
        {
            if (stream is null || !stream.CanWrite) { throw new Exception("Bad stream."); }

            Bytes(stream, Destruct.Byte(value));
        }
        public static void SByte(Stream stream, sbyte value)
        {
            if (stream is null || !stream.CanWrite) { throw new Exception("Bad stream."); }

            Bytes(stream, Destruct.SByte(value));
        }
        public static void Word(Stream stream, ushort value)
        {
            if (stream is null || !stream.CanWrite) { throw new Exception("Bad stream."); }

            Bytes(stream, Destruct.Word(value));
        }
        public static void SWord(Stream stream, short value)
        {
            if (stream is null || !stream.CanWrite) { throw new Exception("Bad stream."); }

            Bytes(stream, Destruct.SWord(value));
        }
        public static void DWord(Stream stream, uint value)
        {
            if (stream is null || !stream.CanWrite) { throw new Exception("Bad stream."); }

            Bytes(stream, Destruct.DWord(value));
        }
        public static void SDWord(Stream stream, int value)
        {
            if (stream is null || !stream.CanWrite) { throw new Exception("Bad stream."); }

            Bytes(stream, Destruct.SDWord(value));
        }
        public static void QWord(Stream stream, ulong value)
        {
            if (stream is null || !stream.CanWrite) { throw new Exception("Bad stream."); }

            Bytes(stream, Destruct.QWord(value));
        }
        public static void SQWord(Stream stream, long value)
        {
            if (stream is null || !stream.CanWrite) { throw new Exception("Bad stream."); }

            Bytes(stream, Destruct.SQWord(value));
        }
        public static void Real4(Stream stream, float value)
        {
            if (stream is null || !stream.CanWrite) { throw new Exception("Bad stream."); }

            Bytes(stream, Destruct.Real4(value));
        }
        public static void Real8(Stream stream, double value)
        {
            if (stream is null || !stream.CanWrite) { throw new Exception("Bad stream."); }

            Bytes(stream, Destruct.Real8(value));
        }

        public static void SBytes(Stream stream, sbyte[] values)
        {
            if (values is null) { throw new Exception("Bad values."); }
            if (stream is null || !stream.CanWrite) { throw new Exception("Bad stream."); }

            Bytes(stream, Destruct.SBytes(values));
        }
        public static void Words(Stream stream, ushort[] values)
        {
            if (values is null) { throw new Exception("Bad values."); }
            if (stream is null || !stream.CanWrite) { throw new Exception("Bad stream."); }

            Bytes(stream, Destruct.Words(values));
        }
        public static void SWords(Stream stream, short[] values)
        {
            if (values is null) { throw new Exception("Bad values."); }
            if (stream is null || !stream.CanWrite) { throw new Exception("Bad stream."); }

            Bytes(stream, Destruct.SWords(values));
        }
        public static void DWords(Stream stream, uint[] values)
        {
            if (values is null) { throw new Exception("Bad values."); }
            if (stream is null || !stream.CanWrite) { throw new Exception("Bad stream."); }

            Bytes(stream, Destruct.DWords(values));
        }
        public static void SDWords(Stream stream, int[] values)
        {
            if (values is null) { throw new Exception("Bad values."); }
            if (stream is null || !stream.CanWrite) { throw new Exception("Bad stream."); }

            Bytes(stream, Destruct.SDWords(values));
        }
        public static void QWords(Stream stream, ulong[] values)
        {
            if (values is null) { throw new Exception("Bad values."); }
            if (stream is null || !stream.CanWrite) { throw new Exception("Bad stream."); }

            Bytes(stream, Destruct.QWords(values));
        }
        public static void SQWords(Stream stream, long[] values)
        {
            if (values is null) { throw new Exception("Bad values."); }
            if (stream is null || !stream.CanWrite) { throw new Exception("Bad stream."); }

            Bytes(stream, Destruct.SQWords(values));
        }
        public static void Real4s(Stream stream, float[] values)
        {
            if (values is null) { throw new Exception("Bad values."); }
            if (stream is null || !stream.CanWrite) { throw new Exception("Bad stream."); }

            Bytes(stream, Destruct.Real4s(values));
        }
        public static void Real8s(Stream stream, double[] values)
        {
            if (values is null) { throw new Exception("Bad values."); }
            if (stream is null || !stream.CanWrite) { throw new Exception("Bad stream."); }

            Bytes(stream, Destruct.Real8s(values));
        }

        public static void MZHeaderV1(Stream stream, MZHeaderV1 value)
        {
            if (value is null) { throw new Exception("Bad value."); }
            if (stream is null || !stream.CanWrite) { throw new Exception("Bad stream."); }

            Word(stream, value.Magic);
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
            if (value is null) { throw new Exception("Bad value."); }
            if (stream is null || !stream.CanWrite) { throw new Exception("Bad stream."); }

            Word(stream, value.Magic);
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
            DWord(stream, value.NewHeaderFileAddress);
        }
        public static void PEHeader(Stream stream, PEHeader value)
        {
            if (value is null) { throw new Exception("Bad value."); }
            if (stream is null || !stream.CanWrite) { throw new Exception("Bad stream."); }

            DWord(stream, value.Magic);
            Word(stream, value.Machine);
            Word(stream, value.NumberOfSections);
            DWord(stream, value.DateTimeStamp);
            DWord(stream, value.PointerToSymbolTable);
            DWord(stream, value.NumberOfSymbols);
            Word(stream, value.SizeOfOptionalHeader);
            Word(stream, value.Characteristics);
        }
        public static void PEOptionalHeader(Stream stream, PEOptionalHeader value)
        {
            if (value is null) { throw new Exception("Bad value."); }
            if (stream is null || !stream.CanWrite) { throw new Exception("Bad stream."); }

            Word(stream, value.Magic);
            Byte(stream, value.MajorLinkerVersion);
            Byte(stream, value.MinorLinkerVersion);
            DWord(stream, value.SizeOfCode);
            DWord(stream, value.SizeOfInitializedData);
            DWord(stream, value.SizeOfUninitializedData);
            DWord(stream, value.AddressOfEntryPoint);
            DWord(stream, value.BaseOfCode);
            DWord(stream, value.BaseOfData);
            DWord(stream, value.ImageBase);
            DWord(stream, value.SectionAlignment);
            DWord(stream, value.FileAlignment);
            Word(stream, value.MajorOperatingSystemVersion);
            Word(stream, value.MinorOperatingSystemVersion);
            Word(stream, value.MajorImageVersion);
            Word(stream, value.MinorImageVersion);
            Word(stream, value.MajorSubsystemVersion);
            Word(stream, value.MinorSubsystemVersion);
            DWord(stream, value.Win32VersionValue);
            DWord(stream, value.SizeOfImage);
            DWord(stream, value.SizeOfHeaders);
            DWord(stream, value.CheckSum);
            Word(stream, value.Subsystem);
            Word(stream, value.DllCharacteristics);
            DWord(stream, value.SizeOfStackReserve);
            DWord(stream, value.SizeOfStackCommit);
            DWord(stream, value.SizeOfHeapReserve);
            DWord(stream, value.SizeOfHeapCommit);
            DWord(stream, value.LoaderFlags);
            DWord(stream, value.NumberOfRvaAndSizes);
        }
        public static void PEDataDirectory(Stream stream, PEDataDirectory value)
        {
            if (value is null) { throw new Exception("Bad value."); }
            if (stream is null || !stream.CanWrite) { throw new Exception("Bad stream."); }

            DWord(stream, value.VirtualSize);
            DWord(stream, value.VirtualAddress);
        }
        public static void PESectionHeader(Stream stream, PESectionHeader value)
        {
            if (value is null) { throw new Exception("Bad value."); }
            if (stream is null || !stream.CanWrite) { throw new Exception("Bad stream."); }

            QWord(stream, value.Name);
            DWord(stream, value.VirtualSize);
            DWord(stream, value.VirtualAddress);
            DWord(stream, value.SizeOfRawData);
            DWord(stream, value.PointerToRawData);
            DWord(stream, value.PointerToRelocations);
            DWord(stream, value.PointerToLinenumbers);
            Word(stream, value.NumberOfRelocations);
            Word(stream, value.NumberOfLinenumbers);
            DWord(stream, value.Characteristics);
        }
    }
}