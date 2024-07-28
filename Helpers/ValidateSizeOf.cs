using System;

namespace ExeSpy
{
    // Used to validate that classes are the correct size to be stored in their C Style type.
    // WILL NOT CHECK VALUES!

    // Checks the following:
    // That values are the same size in bytes as their C Style type.
    // That strings and arrays are the same size as their C Style buffers.
    // That the class instance itself is not null.
    // That nullable fields in the structure are not null.

    // For more advanced validation use the Validate class.
    public static class ValidateSizeOf
    {
        public static void MZHeaderV1(MZHeaderV1 value)
        {
            if (value is null || value.MagicString is null || value.MagicString.Length != 2)
            {
                throw new Exception("Bad value");
            }
        }
        public static void MZHeaderV2(MZHeaderV2 value)
        {
            if (value is null || value.MagicString is null || value.MagicString.Length != 2 || value.Reserved1 is null || value.Reserved1.Length != 4 || value.Reserved2 is null || value.Reserved2.Length != 10)
            {
                throw new Exception("Bad value");
            }
        }
    }
}
