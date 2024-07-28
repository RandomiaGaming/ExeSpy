using System;

namespace ExeSpy
{
    public static class Print
    {
        public static void Pair(string key, string value)
        {
            if (key is null) { key = ""; }
            if (value is null) { value = ""; }
            Indented($"{key}: {value}");
        }
        public static void Indented(string message)
        {
            if (message is null) { message = ""; }
            Line($"    {message}");
        }
        public static void NewLine()
        {
            Line("");
        }
        public static void Line(string message)
        {
            if (message is null) { message = ""; }
            Console.WriteLine(message);
        }

        public static void MZHeaderV1(MZHeaderV1 value)
        {
            ValidateSizeOf.MZHeaderV1(value);

            Line("MZHeaderV1:");
            Pair("Magic String", value.MagicString);
            Pair("Last Page Length", value.LastPageLength.ToString());
            Pair("Page Count", value.PageCount.ToString());
            Pair("Relocation Entiry Count", value.RelocationEntiryCount.ToString());
            Pair("Header Size", value.HeaderSize.ToString());
            Pair("Minimum Allocation", value.MinimumAllocation.ToString());
            Pair("Maximum Allocation", value.MaximumAllocation.ToString());
            Pair("Initial SS", value.InitialSS.ToString());
            Pair("Initial SP", value.InitialSP.ToString());
            Pair("Checksum", value.Checksum.ToString());
            Pair("Initial IP", value.InitialIP.ToString());
            Pair("Initial CS", value.InitialCS.ToString());
            Pair("Relocation Table FileAddress", value.RelocationTableFileAddress.ToString());
            Pair("Overlay", value.Overlay.ToString());
            NewLine();
        }
        public static void MZHeaderV2(MZHeaderV2 value)
        {
            ValidateSizeOf.MZHeaderV2(value);

            Line("MZHeaderV2:");
            Pair("Magic String", value.MagicString);
            Pair("Last Page Length", value.LastPageLength.ToString());
            Pair("Page Count", value.PageCount.ToString());
            Pair("Relocation Entiry Count", value.RelocationEntiryCount.ToString());
            Pair("Header Size", value.HeaderSize.ToString());
            Pair("Minimum Allocation", value.MinimumAllocation.ToString());
            Pair("Maximum Allocation", value.MaximumAllocation.ToString());
            Pair("Initial SS", value.InitialSS.ToString());
            Pair("Initial SP", value.InitialSP.ToString());
            Pair("Checksum", value.Checksum.ToString());
            Pair("Initial IP", value.InitialIP.ToString());
            Pair("Initial CS", value.InitialCS.ToString());
            Pair("Relocation Table FileAddress", value.RelocationTableFileAddress.ToString());
            Pair("Overlay", value.Overlay.ToString());
            Pair("Reserved1", FormatAs.Hex(Destruct. value.Reserved1));

            NewLine();
        }
    }
}