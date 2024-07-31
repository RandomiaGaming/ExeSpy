namespace ExeSpy
{
    // Modified from winnt.h
    // typedef struct _IMAGE_DOS_HEADER { // DOS .EXE header
    // } IMAGE_DOS_HEADER, *PIMAGE_DOS_HEADER;
    // This version of MZHeader is used by classic MS DOS applications however apps using the WinNE or WinPE formats have an extended version of the MZHeader (MZHeaderV2). A spec compliant MZ loader should read the MZHeaderV1 first then only load the larger MZHeaderV2 if HeaderSize contains enough bytes for the larger structure. 
    public sealed class MZHeaderV1
    {
        // (WORD * 14)
        public const int Size = 28;

        // WORD e_magic; // Magic number
        // 0x5A4D (ASCII for 'M' and 'Z')
        public ushort Magic = 0x5A4D;
        // WORD e_cblp; // Bytes on last page of file
        // Number of bytes in the last page.
        public ushort LastPageLength = 0;
        // WORD e_cp; // Pages in file
        // Number of whole/partial pages.
        public ushort PageCount = 0;
        // WORD e_crlc; // Relocations
        // Number of entries in the relocation table.
        public ushort RelocationEntiryCount = 0;
        // WORD e_cparhdr; // Size of header in paragraphs
        // The number of paragraphs taken up by the header. It can be any value, as the loader just uses it to find where the actual executable data starts. It may be larger than what the "standard" fields take up, and you may use it if you want to include your own header metadata, or put the relocation table there, or use it for any other purpose.
        public ushort HeaderSize = 0;
        // WORD e_minalloc; // Minimum extra paragraphs needed
        // The number of paragraphs required by the program, excluding the PSP and program image. If no free block is big enough, the loading stops.
        public ushort MinimumAllocation = 0;
        // WORD e_maxalloc; // Maximum extra paragraphs needed
        // The number of paragraphs requested by the program. If no free block is big enough, the biggest one possible is allocated.
        public ushort MaximumAllocation = 0;
        // WORD e_ss; // Initial (relative) SS value
        // Relocatable segment address for SS.
        public ushort InitialSS = 0;
        // WORD e_sp; // Initial SP value
        // Initial value for SP.
        public ushort InitialSP = 0;
        // WORD e_csum; // Checksum
        // When added to the sum of all other words in the file, the result should be zero.
        public ushort Checksum = 0;
        // WORD e_ip; // Initial IP value
        // Initial value for IP.
        public ushort InitialIP = 0;
        // WORD e_cs; // Initial (relative) CS value
        // Relocatable segment address for CS.
        public ushort InitialCS = 0;
        // WORD e_lfarlc; // File address of relocation table
        // The (absolute) offset to the relocation table.
        public ushort RelocationTableFileAddress = 0;
        // WORD e_ovno; // Overlay number
        // Value used for overlay management. If zero, this is the main executable.
        public ushort Overlay = 0;
    }
}
/* Field Names:
Magic
LastPageLength
PageCount
RelocationEntiryCount
HeaderSize
MinimumAllocation
MaximumAllocation
InitialSS
InitialSP
Checksum
InitialIP
InitialCS
RelocationTableFileAddress
Overlay
*/
/* Documentation:
winnt.h
https://wiki.osdev.org/MZ
*/