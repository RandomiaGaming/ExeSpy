# Learning
The windows PE format used for EXE files is complicated to say the least
but with perservierance you can learn to understand them (or die trying).

# Resources
Anyhoo here are some resources that helped me create this utility:

Official Microsoft documentation for the Win32 PE format:
https://learn.microsoft.com/en-us/windows/win32/debug/pe-format

Information about the MZ header used by MS-DOS and as the base for the modern EXE header:
https://wiki.osdev.org/MZ

Information about the NE header used by Windows 3.x:
https://wiki.osdev.org/NE

Information about the PE header used by current Windows versions:
https://wiki.osdev.org/PE

Disassembly table for all x86-32 CPU instructions:
http://ref.x86asm.net/coder32.html

Disassembly table for all x86-64 CPU instructions:
http://ref.x86asm.net/coder64.html

Information about the PE loader and COM files:
https://devblogs.microsoft.com/oldnewthing/20080324-00/?p=23033

General information about the tables above and the x86 ISA:
http://ref.x86asm.net/

# Stuff I Know
COM files are raw 16 bit executables with no header. They are executed by copy/pasting the
contents of the file into memory then jumping to the address of the start of the file's contents.
These files are not supported on modern windows but can be run with the DosBox emulator.

# Types
1 BYTE = 8 BITs
1 WORD = 2 BYTEs or 16 BITs
1 PARAGRAPH = 8 WORDs or 16 BYTEs or 128 BITs
1 PAGE = 256 PARAGRAPHs or 2048 WORDs or 4096 BYTEs or 32768 BITs