using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ExeSpy
{
    public static class Tests
    {
        public static void AssertBytesEqual(byte[] a, byte[] b)
        {
            if(a is null && b is null)
            {
                return;
            }
            if (a is null || b is null)
            {
                throw new Exception("Assertation Failed.");
            }
            if(a.Length != b.Length)
            {
                throw new Exception("Assertation Failed.");
            }
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    throw new Exception("Assertation Failed.");
                }
            }
        }
        public static void MZHeaderV1()
        {
            Random RNG = new Random((int)DateTime.Now.Ticks);
            byte[] source = new byte[ExeSpy.MZHeaderV1.Size];
            RNG.NextBytes(source);
            source[0] &= 0x7F;
            source[1] &= 0x7F;
            MemoryStream sourceStream = new MemoryStream(source);
            ExeSpy.MZHeaderV1 mzHeaderV1 = Read.MZHeaderV1(sourceStream);
            if(sourceStream.Position != ExeSpy.MZHeaderV1.Size)
            {
                throw new Exception("Assertation Failed.");
            }
            MemoryStream destinationStream = new MemoryStream(ExeSpy.MZHeaderV1.Size);
            Write.MZHeaderV1(destinationStream, mzHeaderV1);
            byte[] destination = destinationStream.ToArray();
            AssertBytesEqual(source, destination);
            sourceStream.Dispose();
            destinationStream.Dispose();
        }
        public static void MZHeaderV2()
        {
            Random RNG = new Random((int)DateTime.Now.Ticks);
            byte[] source = new byte[ExeSpy.MZHeaderV2.Size];
            RNG.NextBytes(source);
            source[0] &= 0x7F;
            source[1] &= 0x7F;
            MemoryStream sourceStream = new MemoryStream(source);
            ExeSpy.MZHeaderV2 mzHeaderV2 = Read.MZHeaderV2(sourceStream);
            if (sourceStream.Position != ExeSpy.MZHeaderV2.Size)
            {
                throw new Exception("Assertation Failed.");
            }
            MemoryStream destinationStream = new MemoryStream(ExeSpy.MZHeaderV2.Size);
            Write.MZHeaderV2(destinationStream, mzHeaderV2);
            byte[] destination = destinationStream.ToArray();
            AssertBytesEqual(source, destination);
            sourceStream.Dispose();
            destinationStream.Dispose();
        }
        public static void PEHeader()
        {
            Random RNG = new Random((int)DateTime.Now.Ticks);
            byte[] source = new byte[ExeSpy.PEHeader.Size];
            RNG.NextBytes(source);
            source[0] &= 0x7F;
            source[1] &= 0x7F;
            source[2] &= 0x7F;
            source[3] &= 0x7F;
            MemoryStream sourceStream = new MemoryStream(source);
            ExeSpy.PEHeader peHeader = Read.PEHeader(sourceStream);
            if (sourceStream.Position != ExeSpy.PEHeader.Size)
            {
                throw new Exception("Assertation Failed.");
            }
            MemoryStream destinationStream = new MemoryStream(ExeSpy.PEHeader.Size);
            Write.PEHeader(destinationStream, peHeader);
            byte[] destination = destinationStream.ToArray();
            AssertBytesEqual(source, destination);
            sourceStream.Dispose();
            destinationStream.Dispose();
        }
        public static void PEOptionalHeader()
        {
            Random RNG = new Random((int)DateTime.Now.Ticks);
            byte[] source = new byte[ExeSpy.PEOptionalHeader.Size];
            RNG.NextBytes(source);
            MemoryStream sourceStream = new MemoryStream(source);
            ExeSpy.PEOptionalHeader peOptionalHeader = Read.PEOptionalHeader(sourceStream);
            if (sourceStream.Position != ExeSpy.PEOptionalHeader.Size)
            {
                throw new Exception("Assertation Failed.");
            }
            MemoryStream destinationStream = new MemoryStream(ExeSpy.PEOptionalHeader.Size);
            Write.PEOptionalHeader(destinationStream, peOptionalHeader);
            byte[] destination = destinationStream.ToArray();            
            AssertBytesEqual(source, destination);
            sourceStream.Dispose();
            destinationStream.Dispose();
        }
        public static void All()
        {
            for (int i = 0; i < 100; i++)
            {
                MZHeaderV1();
                MZHeaderV2();
                PEHeader();
                PEOptionalHeader();
            }
        }
    }
}