using System.Collections.Generic;
namespace ExeSpy
{
    // Modified from winnt.h
    // typedef struct _IMAGE_OPTIONAL_HEADER {
    // } IMAGE_OPTIONAL_HEADER32, *PIMAGE_OPTIONAL_HEADER32;
    public sealed class PEOptionalHeader
    {
        // (WORD * 9) + (BYTE * 2) + (DWORD * 19)
        public const int Size = 96;
        public static readonly Dictionary<ushort, string> MagicValues = new Dictionary<ushort, string>() {
            { 0x010B, "PE32" }, // IMAGE_NT_OPTIONAL_HDR32_MAGIC = 0x010B; // The file is an executable image.
            { 0x020B, "PE64+" }, // IMAGE_NT_OPTIONAL_HDR64_MAGIC = 0x020B; // The file is an executable image.
            { 0x0107, "ROMImage" }, // IMAGE_ROM_OPTIONAL_HDR_MAGIC = 0x0107; // The file is a ROM image.
        };
        public static readonly Dictionary<ushort, string> SubsystemValues = new Dictionary<ushort, string>() {
            { 0, "Unknown" }, // IMAGE_SUBSYSTEM_UNKNOWN = 0; // Unknown subsystem.
            { 1, "None" }, // IMAGE_SUBSYSTEM_NATIVE = 1; // No subsystem required (device drivers and native system processes).
            { 2, "Win Gui" }, // IMAGE_SUBSYSTEM_WINDOWS_GUI = 2; // Windows graphical user interface (GUI) subsystem.
            { 3, "Win Console" }, // IMAGE_SUBSYSTEM_WINDOWS_CUI = 3; // Windows character-mode user interface (CUI) subsystem.
            { 5, "OS2 Console" }, // IMAGE_SUBSYSTEM_OS2_CUI = 5; // OS/2 CUI subsystem.
            { 7, "POSIX Console" }, // IMAGE_SUBSYSTEM_POSIX_CUI = 7; // POSIX CUI subsystem.
            { 9, "Win CE Gui" }, // IMAGE_SUBSYSTEM_WINDOWS_CE_GUI = 9; // Windows CE system.
            { 10, "EFI App" }, // IMAGE_SUBSYSTEM_EFI_APPLICATION = 10; // Extensible Firmware Interface (EFI) application.
            { 11, "EFI Boot Driver" }, // IMAGE_SUBSYSTEM_EFI_BOOT_SERVICE_DRIVER = 11; // EFI driver with boot services.
            { 12, "EFI Runtime Driver" }, // IMAGE_SUBSYSTEM_EFI_RUNTIME_DRIVER = 12; // EFI driver with run-time services.
            { 13, "EFI Rom" }, // IMAGE_SUBSYSTEM_EFI_ROM = 13; // EFI ROM image.
            { 14, "Xbox" }, // IMAGE_SUBSYSTEM_XBOX = 14; // Xbox system.
            { 16, "Win Boot App" }, // IMAGE_SUBSYSTEM_WINDOWS_BOOT_APPLICATION = 16; // Boot application.
        };
        public static readonly Dictionary<ushort, string> DLLCharacteristicsValues = new Dictionary<ushort, string>()
        {
            { 0x0001, "Reserved1" }, // Reserved1 = 0x0001; // Reserved.
            { 0x0002, "Reserved2" }, // Reserved2 = 0x0002; // Reserved.
            { 0x0004, "Reserved3" }, // Reserved3 = 0x0004; // Reserved.
            { 0x0008, "Reserved4" }, // Reserved4 = 0x0008; // Reserved.
            { 0x0010, "Reserved5" }, // Reserved5 = 0x0010; // Reserved.
            { 0x0020, "ASLR64" }, // IMAGE_DLL_CHARACTERISTICS_HIGH_ENTROPY_VA = 0x0020; // ASLR with 64 bit address space.
            { 0x0040, "DynamicBase" }, // IMAGE_DLLCHARACTERISTICS_DYNAMIC_BASE = 0x0040; // The DLL can be relocated at load time.
            { 0x0080, "ForceIntegrity" }, // IMAGE_DLLCHARACTERISTICS_FORCE_INTEGRITY = 0x0080; // Code integrity checks are forced. If you set this flag and a section contains only uninitialized data, set the PointerToRawData member of IMAGE_SECTION_HEADER for that section to zero; otherwise, the image will fail to load because the digital signature cannot be verified.
            { 0x0100, "NXCompat" }, // IMAGE_DLLCHARACTERISTICS_NX_COMPAT = 0x0100; // The image is compatible with data execution prevention (DEP).
            { 0x0200, "NoIsolation" }, // IMAGE_DLLCHARACTERISTICS_NO_ISOLATION = 0x0200; // The image is isolation aware, but should not be isolated.
            { 0x0400, "NoSEH" }, // IMAGE_DLLCHARACTERISTICS_NO_SEH = 0x0400; // The image does not use structured exception handling (SEH). No handlers can be called in this image.
            { 0x0800, "NoBind" }, // IMAGE_DLLCHARACTERISTICS_NO_BIND = 0x0800; // Do not bind the image.
            { 0x1000, "AppContainer" }, // IMAGE_DLL_CHARACTERISTICS_APPCONTAINER = 0x1000; // Image should execute in an AppContainer.
            { 0x2000, "WDMDriver" }, // IMAGE_DLLCHARACTERISTICS_WDM_DRIVER = 0x2000; // A WDM driver.
            { 0x4000, "ControlFlowGuard" }, // IMAGE_DLL_CHARACTERISTICS_GUARD_CF = 0x4000; // Image supports Control Flow Guard.
            { 0x8000, "TerminalServerAware" }, // IMAGE_DLLCHARACTERISTICS_TERMINAL_SERVER_AWARE = 0x8000; // The image is terminal server aware.
        };


        // WORD Magic;
        // 0x010b - PE32, 0x020b - PE32+ (64 bit)
        // The state of the image file. This member can be one of the following values.
        public ushort Magic;
        // BYTE MajorLinkerVersion;
        // N/A
        // The major version number of the linker.
        public byte MajorLinkerVersion;
        // BYTE MinorLinkerVersion;
        // N/A
        // The minor version number of the linker.
        public byte MinorLinkerVersion;
        // DWORD SizeOfCode;
        // N/A
        // The size of the code section, in bytes, or the sum of all such sections if there are multiple code sections.
        public uint SizeOfCode;
        // DWORD SizeOfInitializedData;
        // N/A
        // The size of the initialized data section, in bytes, or the sum of all such sections if there are multiple initialized data sections.
        public uint SizeOfInitializedData;
        // DWORD SizeOfUninitializedData;
        // N/A
        // The size of the uninitialized data section, in bytes, or the sum of all such sections if there are multiple uninitialized data sections.
        public uint SizeOfUninitializedData;
        // DWORD AddressOfEntryPoint;
        // N/A
        // A pointer to the entry point function, relative to the image base address. For executable files, this is the starting address. For device drivers, this is the address of the initialization function. The entry point function is optional for DLLs. When no entry point is present, this member is zero.
        public uint AddressOfEntryPoint;
        // DWORD BaseOfCode;
        // N/A
        // A pointer to the beginning of the code section, relative to the image base.
        public uint BaseOfCode;
        // DWORD BaseOfData;
        // N/A
        // A pointer to the beginning of the data section, relative to the image base.
        public uint BaseOfData;
        // DWORD ImageBase;
        // N/A
        // The preferred address of the first byte of the image when it is loaded in memory. This value is a multiple of 64K bytes. The default value for DLLs is 0x10000000. The default value for applications is 0x00400000, except on Windows CE where it is 0x00010000.
        public uint ImageBase;
        // DWORD SectionAlignment;
        // N/A
        // The alignment of sections loaded in memory, in bytes. This value must be greater than or equal to the FileAlignment member. The default value is the page size for the system.
        public uint SectionAlignment;
        // DWORD FileAlignment;
        // N/A
        // The alignment of the raw data of sections in the image file, in bytes. The value should be a power of 2 between 512 and 64K (inclusive). The default is 512. If the SectionAlignment member is less than the system page size, this member must be the same as SectionAlignment.
        public uint FileAlignment;
        // WORD MajorOperatingSystemVersion;
        // N/A
        // The major version number of the required operating system.
        public ushort MajorOperatingSystemVersion;
        // WORD MinorOperatingSystemVersion;
        // N/A
        // The minor version number of the required operating system.
        public ushort MinorOperatingSystemVersion;
        // WORD MajorImageVersion;
        // N/A
        // The major version number of the image.
        public ushort MajorImageVersion;
        // WORD MinorImageVersion;
        // N/A
        // The minor version number of the image.
        public ushort MinorImageVersion;
        // WORD MajorSubsystemVersion;
        // N/A
        // The major version number of the subsystem.
        public ushort MajorSubsystemVersion;
        // WORD MinorSubsystemVersion;
        // N/A
        // The minor version number of the subsystem.
        public ushort MinorSubsystemVersion;
        // DWORD Win32VersionValue;
        // N/A
        // This member is reserved and must be 0.
        public uint Win32VersionValue;
        // DWORD SizeOfImage;
        // N/A
        // The size of the image, in bytes, including all headers. Must be a multiple of SectionAlignment.
        public uint SizeOfImage;
        // DWORD SizeOfHeaders;
        // N/A
        // The combined size of the following items, rounded to a multiple of the value specified in the FileAlignment member.
        public uint SizeOfHeaders;
        // DWORD CheckSum;
        // N/A
        // The image file checksum. The following files are validated at load time: all drivers, any DLL loaded at boot time, and any DLL loaded into a critical system process.
        public uint CheckSum;
        // WORD Subsystem;
        // N/A
        public ushort Subsystem;
        // WORD DllCharacteristics;
        // N/A
        public ushort DllCharacteristics;
        // DWORD SizeOfStackReserve;
        // N/A
        // The number of bytes to reserve for the stack. Only the memory specified by the SizeOfStackCommit member is committed at load time; the rest is made available one page at a time until this reserve size is reached.
        public uint SizeOfStackReserve;
        // DWORD SizeOfStackCommit;
        // N/A
        // The number of bytes to commit for the stack.
        public uint SizeOfStackCommit;
        // DWORD SizeOfHeapReserve;
        // N/A
        // The number of bytes to reserve for the local heap. Only the memory specified by the SizeOfHeapCommit member is committed at load time; the rest is made available one page at a time until this reserve size is reached.
        public uint SizeOfHeapReserve;
        // DWORD SizeOfHeapCommit;
        // N/A
        // The number of bytes to commit for the local heap.
        public uint SizeOfHeapCommit;
        // DWORD LoaderFlags;
        // N/A
        // This member is obsolete.
        public uint LoaderFlags;
        // DWORD NumberOfRvaAndSizes;
        // N/A
        // The number of directory entries in the remainder of the optional header. Each entry describes a location and size.
        public uint NumberOfRvaAndSizes;
    }
}
/* Field Names:
Magic
MajorLinkerVersion
MinorLinkerVersion
SizeOfCode
SizeOfInitializedData
SizeOfUninitializedData
AddressOfEntryPoint
BaseOfCode
BaseOfData
ImageBase
SectionAlignment
FileAlignment
MajorOperatingSystemVersion
MinorOperatingSystemVersion
MajorImageVersion
MinorImageVersion
MajorSubsystemVersion
MinorSubsystemVersion
Win32VersionValue
SizeOfImage
SizeOfHeaders
CheckSum
Subsystem
DllCharacteristics
SizeOfStackReserve
SizeOfStackCommit
SizeOfHeapReserve
SizeOfHeapCommit
LoaderFlags
NumberOfRvaAndSizes
*/
/* Documentation:
winnt.h
https://wiki.osdev.org/PE
https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-image_optional_header32
*/