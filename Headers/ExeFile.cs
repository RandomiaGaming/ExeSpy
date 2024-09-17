namespace ExeSpy
{
    public sealed class ExeFile
    {
        public MZHeaderV1 MZHeaderV1;
        public MZHeaderV2 MZHeaderV2;
        public MZRelocation[] MZRelocations;
        public byte[] MZDosStub;

        public PEHeader PEHeader;
        public PEOptionalHeader PEOptionalHeader;
        public PEDataDirectory[] PEDataDirectories;
        public PESectionHeader[] PESectionHeaders;
        public PESection[] PESections;
        // Note that PECoffSymbolTables are depricated and so we can worry about them later.
    }
}
