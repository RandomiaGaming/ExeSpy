using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;

namespace ExeSpy
{
    public static class Disassemble
    {
        /*
        public sealed class InstMeta
        {
            BYTE Prefix;
            BYTE? ZeroFPrefix;
            BYTE PrimaryOpCode;
            BYTE? SecondaryOpCode;
            // 00 = No displacement.
            // 01 = 8 bit displacement.
            // 10 = 32 bit displacement.
            // 11 = Register mode. Displacement N/A.
            BIT[2] Mod;
            // When a register is needed:
            // 000 = EAX
            // 001 = ECX
            // 010 = EDX
            // 011 = EBX
            // 100 = ESP
            // 101 = EBP
            // 110 = ESI
            // 111 = EDI
            // Otherwise specifies 8 options for custom settings for this opCode.
            BIT[3] Reg;
            // When Mod == 11
            // 000 = EAX
            // 001 = ECX
            // 010 = EDX
            // 011 = EBX
            // 100 = ESP
            // 101 = EBP
            // 110 = ESI
            // 111 = EDI
            // When Mod == 00 || Mod == 01 || Mod == 10
            // 000 = Address stored in EAX
            // 000 = Address stored in ECX
            // 000 = Address stored in EDX
            // 000 = Address stored in EBX
            // 000 = SIB byte follows (Scale-Index-Base addressing)
            // 000 = Displacement only (32-bit address if mod = 00, [EBP] if mod = 01 or 10)
            // 000 = Address stored in ESI
            // 000 = Address stored in EDI
            BIT[3] R/M;
            BIT[2] Scale;
            BIT[3] Index;
            BIT[3] Base;
            DWORD Displacement;
            DWORD Immediate;
            DWORD JumpTargetAddress;

        }
        */
        private class Instruction
        {
            public string Prefix;
            public string ZeroFPrefix;
            public string PrimaryOpCode;
            public string SecondaryOpCode;
            public string RegisterOrOpCodeFields;
            public string IntroducedWithProcessor;
            public string DocumentationStatus;
            public string ModeOfOperation;
            public string RingLevel;
            public string LockPrefixOrFPUPushPop;
            public string Mnemonic;
            public string OperandOne;
            public string OperandTwo;
            public string OperandThree;
            public string OperandFour;
            public string InstructionExtensionGroup;
            public string TestedFlags;
            public string ModifiedFlags;
            public string DefinedFlags;
            public string UndefinedFlags;
            public string FlagValues;
            public string Description;

            public byte[] Value;
            public string Text;

            public override string ToString()
            {
                return Text;
            }
        }
        private static Instruction[] _instructions;
        public static void Init()
        {
            List<Instruction> instructions = new List<Instruction>();
            string[] lines = File.ReadAllLines("D:\\Coding\\C#\\ExeSpy\\x86.csv");
            for (int i = 0; i < lines.Length; i++)
            {
                Instruction instruction = new Instruction();
                instruction.Text = lines[i];
                string[] sections = instruction.Text.Split(',');
                instruction.Prefix = sections[0];
                instruction.ZeroFPrefix = sections[1];
                instruction.PrimaryOpCode = sections[2];
                instruction.SecondaryOpCode = sections[3];
                instruction.RegisterOrOpCodeFields = sections[4];
                instruction.IntroducedWithProcessor = sections[5];
                instruction.DocumentationStatus = sections[6];
                instruction.ModeOfOperation = sections[7];
                instruction.RingLevel = sections[8];
                instruction.LockPrefixOrFPUPushPop = sections[9];
                instruction.Mnemonic = sections[10];
                instruction.OperandOne = sections[11];
                instruction.OperandTwo = sections[12];
                instruction.OperandThree = sections[13];
                instruction.OperandFour = sections[14];
                instruction.InstructionExtensionGroup = sections[15];
                instruction.TestedFlags = sections[16];
                instruction.ModifiedFlags = sections[17];
                instruction.DefinedFlags = sections[18];
                instruction.UndefinedFlags = sections[19];
                instruction.FlagValues = sections[20];
                instruction.Description = sections[21];

                bool plusROpCode = false;
                if (instruction.PrimaryOpCode.EndsWith("+r"))
                {
                    plusROpCode = true;
                    instruction.PrimaryOpCode = instruction.PrimaryOpCode.Substring(0, instruction.PrimaryOpCode.Length - 2);
                }

                if(instruction.ZeroFPrefix.Length == 0)
                {
                    if(instruction.PrimaryOpCode.Length == 0 || instruction.SecondaryOpCode.Length > 0 || instruction.Prefix.Length > 0)
                    {

                    }
                    Console.WriteLine($"{instruction.Prefix} {instruction.PrimaryOpCode} {instruction.SecondaryOpCode} - {instruction.Mnemonic} - {instruction.Description}");
                }

                int valueLength = 0;
                instruction.Value = new byte[4];
                if (instruction.Prefix.Length > 0)
                {
                    instruction.Value[valueLength] = byte.Parse(instruction.Prefix, System.Globalization.NumberStyles.HexNumber);
                    valueLength++;
                }
                if (instruction.ZeroFPrefix.Length > 0)
                {
                    instruction.Value[valueLength] = byte.Parse(instruction.ZeroFPrefix, System.Globalization.NumberStyles.HexNumber);
                    valueLength++;
                }
                if (instruction.PrimaryOpCode.Length > 0)
                {
                    instruction.Value[valueLength] = byte.Parse(instruction.PrimaryOpCode, System.Globalization.NumberStyles.HexNumber);
                    valueLength++;
                }
                if (instruction.SecondaryOpCode.Length > 0)
                {
                    instruction.Value[valueLength] = byte.Parse(instruction.SecondaryOpCode, System.Globalization.NumberStyles.HexNumber);
                    valueLength++;
                }

                byte[] valueCropped = new byte[valueLength];
                Array.Copy(instruction.Value, valueCropped, valueLength);
                instruction.Value = valueCropped;

                instructions.Add(instruction);
            }

            _instructions = instructions.ToArray();
        }
        private static int CmpInst(byte[] bytesFromFile, Instruction instruction)
        {
            if (bytesFromFile is null || instruction is null || bytesFromFile.Length < instruction.Value.Length)
            {
                return 0;
            }
            for (int i = 0; i < instruction.Value.Length; i++)
            {
                if (bytesFromFile[i] != instruction.Value[i])
                {
                    return 0;
                }
            }
            return instruction.Value.Length;
        }
        public static string x86(Stream stream)
        {
            if (stream is null || !stream.CanRead) { throw new Exception("Bad stream."); }

            byte[] bytesFromFile;
            if (stream.Position + 4 > stream.Length)
            {
                bytesFromFile = Read.Bytes(stream, (int)(stream.Length - stream.Position));
            }
            else
            {
                bytesFromFile = Read.Bytes(stream, 4);
            }

            int bestMatchScore = 0;
            Instruction bestMatch = null;
            for (int i = 0; i < _instructions.Length; i++)
            {
                int score = CmpInst(bytesFromFile, _instructions[i]);
                if (score > bestMatchScore)
                {
                    bestMatch = _instructions[i];
                }
            }

            return bestMatch.Text;
        }
    }
}
