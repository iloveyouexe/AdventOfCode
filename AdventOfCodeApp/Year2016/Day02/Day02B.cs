using System;
using System.Collections.Generic;

namespace AdventOfCode.Year2016.Day02
{
    public class Day02B
    {
        public static string Solve(string[] instructions)
        {
            char[,] keypad = {
                { ' ', ' ', '1', ' ', ' ' },
                { ' ', '2', '3', '4', ' ' },
                { '5', '6', '7', '8', '9' },
                { ' ', 'A', 'B', 'C', ' ' },
                { ' ', ' ', 'D', ' ', ' ' }
            };

            int x = 2; 
            int y = 0;

            string code = "";

            foreach (string instruction in instructions)
            {
                foreach (char command in instruction)
                {
                    switch (command)
                    {
                        case 'U': if (x > 0 && keypad[x - 1, y] != ' ') x -= 1; break;
                        case 'D': if (x < 4 && keypad[x + 1, y] != ' ') x += 1; break;
                        case 'L': if (y > 0 && keypad[x, y - 1] != ' ') y -= 1; break;
                        case 'R': if (y < 4 && keypad[x, y + 1] != ' ') y += 1; break;
                    }
                }
                code += keypad[x, y]; 
                Console.WriteLine($"Current code: {code}"); 
            }
            return code;
        }
    }
}