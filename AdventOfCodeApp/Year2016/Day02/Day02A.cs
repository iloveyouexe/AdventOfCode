using System;

namespace AdventOfCode.Year2016.Day02
{
    public class Day02A : IAdventOfCodeProblem
    {
        public string Solve(string[] instructions)
        {
            int[,] keypad = {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

            int x = 1; 
            int y = 1;

            string code = "";
            
            string[] lines = string.Join(Environment.NewLine, instructions)
                .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string instruction in lines)
            {
                foreach (char command in instruction)
                {
                    switch (command)
                    {
                        case 'U': if (x > 0) x -= 1; break;
                        case 'D': if (x < 2) x += 1; break;
                        case 'L': if (y > 0) y -= 1; break;
                        case 'R': if (y < 2) y += 1; break;
                    }
                }
                code += keypad[x, y].ToString(); 
            }
            return code;
        }
    }
}