using System;
using System.Collections.Generic;

namespace AdventOfCode.Year2016.Day23
{
    public class Day23A : IAdventOfCodeProblem
    {
        public string Solve(string[] opCodes)
        {
            Dictionary<char, int> registers = new Dictionary<char, int>
            {
                { 'a', 7 }, 
                { 'b', 0 },
                { 'c', 0 },
                { 'd', 0 }
            };

            ExecuteInstructions(opCodes, registers);

            return registers['a'].ToString();
        }

        private static void ExecuteInstructions(string[] instructions, Dictionary<char, int> registers)
        {
            int i = 0;
            while (i < instructions.Length)
            {
                var parts = instructions[i].Split(' ');
                // Console.WriteLine($"Executing {string.Join(" ", parts)} at index {i}");
                switch (parts[0])
                {
                    case "cpy":
                        Cpy(parts[1], parts[2], registers);
                        i++;
                        break;
                    case "inc":
                        Inc(parts[1], registers);
                        i++;
                        break;
                    case "dec":
                        Dec(parts[1], registers);
                        i++;
                        break;
                    case "jnz":
                        i += Jnz(parts[1], parts[2], registers);
                        break;
                    case "tgl":
                        Tgl(parts[1], instructions, i, registers);
                        i++;
                        break;
                    default:
                        i++;
                        break;
                }
            }
        }

        private static void Cpy(string x, string y, Dictionary<char, int> registers)
        {
            if (!char.IsLetter(y[0])) return; // Skip invalid cpy instruction
            registers[y[0]] = GetValue(x, registers);
        }

        private static void Inc(string x, Dictionary<char, int> registers)
        {
            if (!char.IsLetter(x[0])) return; // Skip invalid inc instruction
            registers[x[0]]++;
        }

        private static void Dec(string x, Dictionary<char, int> registers)
        {
            if (!char.IsLetter(x[0])) return; // Skip invalid dec instruction
            registers[x[0]]--;
        }

        private static int Jnz(string x, string y, Dictionary<char, int> registers)
        {
            int valueX = GetValue(x, registers);
            if (valueX != 0)
            {
                return GetValue(y, registers);
            }
            return 1; 
        }

        private static void Tgl(string x, string[] instructions, int currentIndex, Dictionary<char, int> registers)
        {
            int targetIndex = currentIndex + GetValue(x, registers);
            if (targetIndex < 0 || targetIndex >= instructions.Length) return;

            var targetInstruction = instructions[targetIndex];
            var parts = targetInstruction.Split(' ');
            if (parts.Length == 2) 
            {
                instructions[targetIndex] = parts[0] == "inc" ? "dec " + parts[1] : "inc " + parts[1];
            }
            else if (parts.Length == 3) 
            {
                instructions[targetIndex] = parts[0] == "jnz" ? "cpy " + parts[1] + " " + parts[2] : "jnz " + parts[1] + " " + parts[2];
            }

            // Console.WriteLine($"Toggled instruction at index {targetIndex}: {instructions[targetIndex]}");
        }

        private static int GetValue(string operand, Dictionary<char, int> registers)
        {
            if (int.TryParse(operand, out int value))
            {
                return value;
            }
            return registers[operand[0]];
        }
    }
}
