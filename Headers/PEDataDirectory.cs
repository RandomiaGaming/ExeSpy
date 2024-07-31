using System.Collections.Generic;

namespace ExeSpy
{
    // Modified from winnt.h
    // typedef struct _IMAGE_DATA_DIRECTORY {
    // } IMAGE_DATA_DIRECTORY, *PIMAGE_DATA_DIRECTORY;
    public sealed class PEDataDirectory
    {
        // (DWORD * 2)
        public const int Size = 8;
        public static readonly Dictionary<uint, string> DataDirectoryNames = new Dictionary<uint, string>() {
            { 0, "Export" }, // IMAGE_DIRECTORY_ENTRY_EXPORT = 0; // Export directory
            { 1, "Import" }, // IMAGE_DIRECTORY_ENTRY_IMPORT = 1; // Import directory
            { 2, "Resource" }, // IMAGE_DIRECTORY_ENTRY_RESOURCE = 2; // Resource directory
            { 3, "Exception" }, // IMAGE_DIRECTORY_ENTRY_EXCEPTION = 3; // Exception directory
            { 4, "Security" }, // IMAGE_DIRECTORY_ENTRY_SECURITY = 4; // Security directory
            { 5, "BaseRelocationTable" }, // IMAGE_DIRECTORY_ENTRY_BASERELOC = 5; // Base relocation table
            { 6, "Debug" }, // IMAGE_DIRECTORY_ENTRY_DEBUG = 6; // Debug directory
            { 7, "ArchitectureSpecific" }, // IMAGE_DIRECTORY_ENTRY_ARCHITECTURE = 7; // Architecture-specific data
            { 8, "GlobalPointer" }, // IMAGE_DIRECTORY_ENTRY_GLOBALPTR = 8; // The relative virtual address of global pointer
            { 9, "ThreadLocalStorage" }, // IMAGE_DIRECTORY_ENTRY_TLS = 9; // Thread local storage directory
            { 10, "LoadConfig" }, // IMAGE_DIRECTORY_ENTRY_LOAD_CONFIG = 10; // Load configuration directory
            { 11, "BoundImport" }, // IMAGE_DIRECTORY_ENTRY_BOUND_IMPORT = 11; // Bound import directory
            { 12, "ImportAddressTable" }, // IMAGE_DIRECTORY_ENTRY_IAT = 12; // Import address table
            { 13, "DelayImportTable" }, // IMAGE_DIRECTORY_ENTRY_DELAY_IMPORT = 13; // Delay import table
            { 14, "COMDescriptorTable" }, // IMAGE_DIRECTORY_ENTRY_COM_DESCRIPTOR = 14; // COM descriptor table
            { 15, "Reserved" }, // Reserved1 = 14; // Reserved
        };

        // DWORD VirtualAddress;
        // N/A
        // The relative virtual address of the table.
        public uint VirtualAddress;
        // DWORD Size;
        // N/A
        // The size of the table, in bytes.
        public uint VirtualSize;
    }
}
/* Field Names:
VirtualAddress
Size
*/
/* Documentation:
winnt.h
https://wiki.osdev.org/PE
https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-image_data_directory
*/