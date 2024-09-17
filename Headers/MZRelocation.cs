namespace ExeSpy
{
    // No structure availible in win32 apis. Trusting osdev.org for accurate info.
    public sealed class MZRelocation
    {
        // (WORD * 2)
        public const int Size = 4;

        // WORD Offset;
        // Offset of the relocation within provided segment.
        public ushort Offset = 0;
        // WORD Segment;
        // Segment of the relocation, relative to the load segment address.
        public ushort Segment = 0;
    }
}
/* Field Names:
Offset
Segment
*/
/* Documentation:
https://wiki.osdev.org/MZ
*/