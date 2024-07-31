using System.Collections.Generic;
namespace ExeSpy
{
    // Modified from winnt.h
    // typedef struct _IMAGE_SECTION_HEADER {
    // } IMAGE_SECTION_HEADER, *PIMAGE_SECTION_HEADER;
    public sealed class PESectionHeader
    {
        // (BYTE * 8) + (DWORD * 7) + (WORD * 2)
        public const int Size = 40;
        public static readonly Dictionary<uint, string> CharacteristicsFlagValues = new Dictionary<uint, string>() {
            { 0x00000001, "Reserved1" }, // Reserved1 = 0x00000001; // Reserved.
            { 0x00000002, "Reserved2" }, // Reserved2 = 0x00000002; // Reserved.
            { 0x00000004, "Reserved3" }, // Reserved3 = 0x00000004; // Reserved.
            { 0x00000008, "NoPadding" }, // IMAGE_SCN_TYPE_NO_PAD = 0x00000008; // The section should not be padded to the next boundary. This flag is obsolete and is replaced by IMAGE_SCN_ALIGN_1BYTES.
            { 0x00000010, "Reserved4" }, // Reserved4 = 0x00000010; // Reserved.
            { 0x00000020, "HasCode" }, // IMAGE_SCN_CNT_CODE = 0x00000020; // The section contains executable code.
            { 0x00000040, "HasInitializedData" }, // IMAGE_SCN_CNT_INITIALIZED_DATA = 0x00000040; // The section contains initialized data.
            { 0x00000080, "HasUninitializedData" }, // IMAGE_SCN_CNT_UNINITIALIZED_DATA = 0x00000080; // The section contains uninitialized data.
            { 0x00000100, "Reserved5" }, // IMAGE_SCN_LNK_OTHER = 0x00000100; // Reserved.
            { 0x00000200, "LinkComments" }, // IMAGE_SCN_LNK_INFO = 0x00000200; // The section contains comments or other information. This is valid only for object files.
            { 0x00000400, "Reserved6" }, // Reserved6 = 0x00000400; // Reserved.
            { 0x00000800, "LinkIgnore" }, // IMAGE_SCN_LNK_REMOVE = 0x00000800; // The section will not become part of the image. This is valid only for object files.
            { 0x00001000, "LinkCOMData" }, // IMAGE_SCN_LNK_COMDAT = 0x00001000; // The section contains COMDAT data. This is valid only for object files.
            { 0x00002000, "Reserved7" }, // Reserved7 = 0x00002000; // Reserved.
            { 0x00004000, "NoDeferSpecExc" }, // IMAGE_SCN_NO_DEFER_SPEC_EXC = 0x00004000; // Reset speculative exceptions handling bits in the TLB entries for this section.
            { 0x00008000, "GlobalRefrences" }, // IMAGE_SCN_GPREL = 0x00008000; // The section contains data referenced through the global pointer.
            { 0x00010000, "Reserved8" }, // Reserved8 = 0x00010000; // Reserved.
            { 0x00020000, "Reserved9" }, // IMAGE_SCN_MEM_PURGEABLE = 0x00020000; // Reserved.
            { 0x00040000, "Reserved10" }, // IMAGE_SCN_MEM_LOCKED = 0x00040000; // Reserved.
            { 0x00080000, "Reserved11" }, // IMAGE_SCN_MEM_PRELOAD = 0x00080000; // Reserved.
            { 0x01000000, "ExtendedRelocations" }, // IMAGE_SCN_LNK_NRELOC_OVFL = 0x01000000; // The section contains extended relocations. The count of relocations for the section exceeds the 16 bits that is reserved for it in the section header.If the NumberOfRelocations field in the section header is 0xffff, the actual relocation count is stored in the VirtualAddress field of the first relocation.It is an error if IMAGE_SCN_LNK_NRELOC_OVFL is set and there are fewer than 0xffff relocations in the section.
            { 0x02000000, "Discardable" }, // IMAGE_SCN_MEM_DISCARDABLE = 0x02000000; // The section can be discarded as needed.
            { 0x04000000, "DoNotCache" }, // IMAGE_SCN_MEM_NOT_CACHED = 0x04000000; // The section cannot be cached.
            { 0x08000000, "DoNotPage" }, // IMAGE_SCN_MEM_NOT_PAGED = 0x08000000; // The section cannot be paged.
            { 0x10000000, "Sharable" }, // IMAGE_SCN_MEM_SHARED = 0x10000000; // The section can be shared in memory.
            { 0x20000000, "Executable" }, // IMAGE_SCN_MEM_EXECUTE = 0x20000000; // The section can be executed as code.
            { 0x40000000, "Readable" }, // IMAGE_SCN_MEM_READ = 0x40000000; // The section can be read.
            { 0x80000000, "Writeable" }, // IMAGE_SCN_MEM_WRITE = 0x80000000; // The section can be written to.
        };
        public static readonly Dictionary<uint, string> CharacteristicsEnumValues = new Dictionary<uint, string>() {
            { 0x00100000, "Align1" }, // IMAGE_SCN_ALIGN_1BYTES = 0x00100000; // Align data on a 1-byte boundary. This is valid only for object files.
            { 0x00200000, "Align2" }, // IMAGE_SCN_ALIGN_2BYTES = 0x00200000; // Align data on a 2-byte boundary. This is valid only for object files.
            { 0x00300000, "Align4" }, // IMAGE_SCN_ALIGN_4BYTES = 0x00300000; // Align data on a 4-byte boundary. This is valid only for object files.
            { 0x00400000, "Align8" }, // IMAGE_SCN_ALIGN_8BYTES = 0x00400000; // Align data on a 8-byte boundary. This is valid only for object files.
            { 0x00500000, "Align16" }, // IMAGE_SCN_ALIGN_16BYTES = 0x00500000; // Align data on a 16-byte boundary. This is valid only for object files.
            { 0x00600000, "Align32" }, // IMAGE_SCN_ALIGN_32BYTES = 0x00600000; // Align data on a 32-byte boundary. This is valid only for object files.
            { 0x00700000, "Align64" }, // IMAGE_SCN_ALIGN_64BYTES = 0x00700000; // Align data on a 64-byte boundary. This is valid only for object files.
            { 0x00800000, "Align128" }, // IMAGE_SCN_ALIGN_128BYTES = 0x00800000; // Align data on a 128-byte boundary. This is valid only for object files.
            { 0x00900000, "Align256" }, // IMAGE_SCN_ALIGN_256BYTES = 0x00900000; // Align data on a 256-byte boundary. This is valid only for object files.
            { 0x00A00000, "Align512" }, // IMAGE_SCN_ALIGN_512BYTES = 0x00A00000; // Align data on a 512-byte boundary. This is valid only for object files.
            { 0x00B00000, "Align1024" }, // IMAGE_SCN_ALIGN_1024BYTES = 0x00B00000; // Align data on a 1024-byte boundary. This is valid only for object files.
            { 0x00C00000, "Align2048" }, // IMAGE_SCN_ALIGN_2048BYTES = 0x00C00000; // Align data on a 2048-byte boundary. This is valid only for object files.
            { 0x00D00000, "Align4096" }, // IMAGE_SCN_ALIGN_4096BYTES = 0x00D00000; // Align data on a 4096-byte boundary. This is valid only for object files.
            { 0x00E00000, "Align8192" }, // IMAGE_SCN_ALIGN_8192BYTES = 0x00E00000; // Align data on a 8192-byte boundary. This is valid only for object files.
        };

        // BYTE Name[8];
        // N/A
        // An 8-byte, null-padded UTF-8 string. There is no terminating null character if the string is exactly eight characters long. For longer names, this member contains a forward slash (/) followed by an ASCII representation of a decimal number that is an offset into the string table. Executable images do not use a string table and do not support section names longer than eight characters.
        public ulong Name;
        // union { DWORD PhysicalAddress; DWORD VirtualSize; } Misc;
        // N/A
        // The total size of the section when loaded into memory, in bytes. If this value is greater than the SizeOfRawData member, the section is filled with zeroes. This field is valid only for executable images and should be set to 0 for object files.
        public uint VirtualSize;
        // DWORD VirtualAddress;
        // N/A
        // The address of the first byte of the section when loaded into memory, relative to the image base. For object files, this is the address of the first byte before relocation is applied.
        public uint VirtualAddress;
        // DWORD SizeOfRawData;
        // N/A
        // The size of the initialized data on disk, in bytes. This value must be a multiple of the FileAlignment member of the IMAGE_OPTIONAL_HEADER structure. If this value is less than the VirtualSize member, the remainder of the section is filled with zeroes. If the section contains only uninitialized data, the member is zero.
        public uint SizeOfRawData;
        // DWORD PointerToRawData;
        // N/A
        // A file pointer to the first page within the COFF file. This value must be a multiple of the FileAlignment member of the IMAGE_OPTIONAL_HEADER structure. If a section contains only uninitialized data, set this member is zero.
        public uint PointerToRawData;
        // DWORD PointerToRelocations;
        // N/A
        // A file pointer to the beginning of the relocation entries for the section. If there are no relocations, this value is zero.
        public uint PointerToRelocations;
        // DWORD PointerToLinenumbers;
        // N/A
        // A file pointer to the beginning of the line-number entries for the section. If there are no COFF line numbers, this value is zero.
        public uint PointerToLinenumbers;
        // WORD NumberOfRelocations;
        // N/A
        // The number of relocation entries for the section. This value is zero for executable images.
        public ushort NumberOfRelocations;
        // WORD NumberOfLinenumbers;
        // N/A
        // The number of line-number entries for the section.
        public ushort NumberOfLinenumbers;
        // DWORD Characteristics;
        // N/A
        // The characteristics of the image. The following values are defined.
        public uint Characteristics;
    }
}
/* Field Names:
Name
VirtualSize
VirtualAddress
SizeOfRawData
PointerToRawData
PointerToRelocations
PointerToLinenumbers
NumberOfRelocations
NumberOfLinenumbers
Characteristics
*/
/* Documentation:
winnt.h
https://wiki.osdev.org/PE
https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-image_section_header
*/