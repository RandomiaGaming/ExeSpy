using System;

namespace EXESpy
{
    public static class TextSegment
    {
        public static void ParseAndPrint(TinyStream stream, PESectionHeader header)
        {
            if(header.VirtualSize > header.SizeOfRawData)
            {
                throw new Exception(".text segment must have a VirtualSize less than or equal to its SizeOfRawData.");
            }

            Print.Log($"{header.Name} Section (Disassembly):");
            while (stream.offset < stream.buffer.Length)
            {
                string inst = ParseInstruction(stream);
                if (inst.Length > 0)
                {
                    Print.LogIn(inst);
                }
            }
            int paddingSize = (int)(header.SizeOfRawData - header.VirtualSize);
            byte[] padding = new byte[paddingSize];
            Array.Copy(stream.buffer, header.VirtualSize, padding, 0, padding.Length);
            Print.Log(Read.AsHex(padding));
            Print.NL();
        }
        public static string ParseInstruction(TinyStream stream)
        {
            byte instructionByte = stream.buffer[stream.offset];
            stream.offset++;
            switch (instructionByte)
            {
                case 0xB8:
                    return $"MOV EAX, {ParseImm32(stream)}";
                case 0xC3:
                    return "RET";
                default:
                    return "";
                    return $"Unknown instruction {Read.AsHex(new byte[1] { instructionByte })}!";
            }
        }
        public static string ParseImm32(TinyStream stream)
        {
            byte[] bytes = new byte[4];
            bytes[0] = stream.buffer[stream.offset];
            bytes[1] = stream.buffer[stream.offset + 1];
            bytes[2] = stream.buffer[stream.offset + 2];
            bytes[3] = stream.buffer[stream.offset + 3];
            stream.offset += 4;
            return BitConverter.ToInt32(bytes, 0).ToString();
        }
    }
}