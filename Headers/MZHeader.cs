using ExeSpy.Helpers;
using System;
using System.IO;

namespace ExeSpy
{
    // Taken from winnt.h
    // typedef struct _IMAGE_DOS_HEADER { // DOS .EXE header
    // } IMAGE_DOS_HEADER, *PIMAGE_DOS_HEADER;
    public sealed class MZHeader
    {
        // C++ MZHeader from winnt.h
        /* 


           WORD   e_cblp;                      // Bytes on last page of file
           WORD   e_cp;                        // Pages in file
           WORD   e_crlc;                      // Relocations
           WORD   e_cparhdr;                   // Size of header in paragraphs
           WORD   e_minalloc;                  // Minimum extra paragraphs needed
           WORD   e_maxalloc;                  // Maximum extra paragraphs needed
           WORD   e_ss;                        // Initial (relative) SS value
           WORD   e_sp;                        // Initial SP value
           WORD   e_csum;                      // Checksum
           WORD   e_ip;                        // Initial IP value
           WORD   e_cs;                        // Initial (relative) CS value
           WORD   e_lfarlc;                    // File address of relocation table
           WORD   e_ovno;                      // Overlay number
           WORD   e_res[4];                    // Reserved words
           WORD   e_oemid;                     // OEM identifier (for e_oeminfo)
           WORD   e_oeminfo;                   // OEM information; e_oemid specific
           WORD   e_res2[10];                  // Reserved words
           LONG   e_lfanew;                    // File address of new exe header
        
        */

        // WORD   e_magic; // Magic number
        // Magic numbers 0x5A4D aka "MZ"
        public string Signature = "MZ";
        // Word e_cblp aka LastPageLength
        // The length of the last page in bytes.
        public ushort LastPageLength = 0; // Byte[2]
        public ushort Pages = 0; // Word
        public ushort RelocationItems = 0; // Word
        public ushort HeaderSize = 0; // Word
        public ushort MinimumAllocation = 0; // Word
        public ushort MaximumAllocation = 0; // Word
        public ushort InitialSS = 0; // Word
        public ushort InitialSP = 0; // Word
        public ushort Checksum = 0; // Word
        public ushort InitialIP = 0; // Word
        public ushort InitialCS = 0; // Word
        public ushort RelocationTable = 0; // Word
        public ushort Overlay = 0; // Word
        public ushort OverlayInformation = 0; // Word
        public void PrintMe()
        {
            Print.Line("MZHeader:");
            Print.Pair("Magic Bytes", Signature);
            Print.Pair("Extra Bytes", FormatAs.Hex(ExtraBytes));
            Print.Pair("Pages", Pages.ToString());
            Print.Pair("Relocation Items", RelocationItems.ToString());
            Print.Pair("Header Size", HeaderSize.ToString());
            Print.Pair("Minimum Allocation", MinimumAllocation.ToString());
            Print.Pair("Maximum Allocation", MaximumAllocation.ToString());
            Print.Pair("Initial SS", InitialSS.ToString());
            Print.Pair("Initial SP", InitialSP.ToString());
            Print.Pair("Checksum", FormatAs.Hex(Destruct.Word(Checksum)));
            Print.Pair("Initial IP", InitialIP.ToString());
            Print.Pair("Initial CS", InitialCS.ToString());
            Print.Pair("Relocation Table", RelocationTable.ToString());
            Print.Pair("Overlay", Overlay.ToString());
            Print.Pair("Overlay Information", OverlayInformation.ToString());
            Print.NewLine();
        }
        public static MZHeader ReadMe(Stream stream)
        {
            MZHeader mzHeader = new MZHeader();
            mzHeader.Signature = Read.ASCII(stream, 2);
            mzHeader.ExtraBytes = Read.Bytes(stream, 2);
            mzHeader.Pages = Read.Word(stream);
            mzHeader.RelocationItems = Read.Word(stream);
            mzHeader.HeaderSize = Read.Word(stream);
            mzHeader.MinimumAllocation = Read.Word(stream);
            mzHeader.MaximumAllocation = Read.Word(stream);
            mzHeader.InitialSS = Read.Word(stream);
            mzHeader.InitialSP = Read.Word(stream);
            mzHeader.Checksum = Read.Word(stream);
            mzHeader.InitialIP = Read.Word(stream);
            mzHeader.InitialCS = Read.Word(stream);
            mzHeader.RelocationTable = Read.Word(stream);
            mzHeader.Overlay = Read.Word(stream);
            mzHeader.OverlayInformation = Read.Word(stream);

            if (mzHeader.Signature != "MZ")
            {
                throw new Exception("MZHeader.MagicBytes must be MZ.");
            }

            return mzHeader;
        }
    }
}