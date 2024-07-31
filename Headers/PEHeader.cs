using System.Collections.Generic;
namespace ExeSpy
{
    // Modified from winnt.h
    // typedef struct _IMAGE_FILE_HEADER {
    // } IMAGE_FILE_HEADER, *PIMAGE_FILE_HEADER;
    public sealed class PEHeader
    {
        // (DWORD * 4) + (WORD * 4)
        public const int Size = 24;
        public static readonly Dictionary<ushort, string> MachineValues = new Dictionary<ushort, string>() {
            { 0x014C, "x86" }, // IMAGE_FILE_MACHINE_I386 = 0x014C; // x86
            { 0x0200, "IntelItanium" }, // IMAGE_FILE_MACHINE_IA64 = 0x0200; // Intel Itanium
            { 0x8664, "x64" }, // IMAGE_FILE_MACHINE_AMD64 = 0x8664; // x64
        };
        public static readonly Dictionary<ushort, string> CharacteristicsValues = new Dictionary<ushort, string>() {
            { 0x0001, "RelocationsStripped" }, // IMAGE_FILE_RELOCS_STRIPPED = 0x0001; // Relocation information was stripped from the file. The file must be loaded at its preferred base address. If the base address is not available, the loader reports an error.
            { 0x0002, "ExecutableImage" }, // IMAGE_FILE_EXECUTABLE_IMAGE = 0x0002; // The file is executable (there are no unresolved external references).
            { 0x0004, "LineNumesStripped" }, // IMAGE_FILE_LINE_NUMS_STRIPPED = 0x0004; // COFF line numbers were stripped from the file.
            { 0x0008, "SymbolsStripped" }, // IMAGE_FILE_LOCAL_SYMS_STRIPPED = 0x0008; // COFF symbol table entries were stripped from file.
            { 0x0010, "AgressiveWorkingSetTrim" }, // IMAGE_FILE_AGGRESIVE_WS_TRIM = 0x0010; // Aggressively trim the working set. This value is obsolete.
            { 0x0020, "LargeAddressAware" }, // IMAGE_FILE_LARGE_ADDRESS_AWARE = 0x0020; // The application can handle addresses larger than 2 GB.
            { 0x0040, "Reserved" }, // IMAGE_FILE_RESERVED = 0x0040; // This value is reserved for future use.
            { 0x0080, "BytesReversedLO" }, // IMAGE_FILE_BYTES_REVERSED_LO = 0x0080; // The bytes of the word are reversed. This flag is obsolete.
            { 0x0100, "32BitMachine" }, // IMAGE_FILE_32BIT_MACHINE = 0x0100; // The computer supports 32-bit words.
            { 0x0200, "DebugStripped" }, // IMAGE_FILE_DEBUG_STRIPPED = 0x0200; // Debugging information was removed and stored separately in another file.
            { 0x0400, "RemovableRunFromSwap" }, // IMAGE_FILE_REMOVABLE_RUN_FROM_SWAP = 0x0400; // If the image is on removable media, copy it to and run it from the swap file.
            { 0x0800, "NetRunFromSwap" }, // IMAGE_FILE_NET_RUN_FROM_SWAP = 0x0800; // If the image is on the network, copy it to and run it from the swap file.
            { 0x1000, "System" }, // IMAGE_FILE_SYSTEM = 0x1000; // The image is a system file.
            { 0x2000, "DLL" }, // IMAGE_FILE_DLL = 0x2000; // The image is a DLL file. While it is an executable file, it cannot be run directly.
            { 0x4000, "UniprocessorSystemOnly" }, // IMAGE_FILE_UP_SYSTEM_ONLY = 0x4000; // The file should be run only on a uniprocessor computer.
            { 0x8000, "BytesReversedHI" }, // IMAGE_FILE_BYTES_REVERSED_HI = 0x8000; // The bytes of the word are reversed. This flag is obsolete.
        };

        // DWORD Signature;
        // PE\0\0 or 0x00004550
        // A 4-byte signature identifying the file as a PE image. The bytes are "PE\0\0".
        public uint Magic = 0x00004550;
        // WORD Machine;
        // N/A
        // The architecture type of the computer. An image file can only be run on the specified computer or a system that emulates the specified computer. This member can be one of the following values.
        public ushort Machine = 0;
        // WORD NumberOfSections;
        // N/A
        // The number of sections. This indicates the size of the section table, which immediately follows the headers. Note that the Windows loader limits the number of sections to 96.
        public ushort NumberOfSections = 0;
        // DWORD TimeDateStamp;
        // N/A
        // This represents the date and time the image was created by the linker. The value is represented in the number of seconds elapsed since midnight (00:00:00), January 1, 1970, Universal Coordinated Time, according to the system clock.
        public uint DateTimeStamp = 0;
        // DWORD PointerToSymbolTable;
        // N/A
        // The offset of the symbol table, in bytes, or zero if no COFF symbol table exists.
        public uint PointerToSymbolTable = 0;
        // DWORD NumberOfSymbols;
        // N/A
        // The number of symbols in the symbol table.
        public uint NumberOfSymbols = 0;
        // WORD SizeOfOptionalHeader;
        // N/A
        // The size of the optional header, in bytes. This value should be 0 for object files.
        public ushort SizeOfOptionalHeader = 0;
        // WORD Characteristics;
        // N/A
        // The characteristics of the image. This member can be one or more of the following values.
        public ushort Characteristics = 0;
    }
}
/* Field Names:
Magic
Machine
NumberOfSections
DateTimeStamp
PointerToSymbolTable
NumberOfSymbols
SizeOfOptionalHeader
Characteristics
*/
/* Documentation:
winnt.h
https://wiki.osdev.org/PE
https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-image_file_header
https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-image_nt_headers32
*/