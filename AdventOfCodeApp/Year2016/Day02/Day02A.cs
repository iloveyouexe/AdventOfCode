namespace AdventOfCode.Year2016.Day02;

public class Day02A
{
    public static string Solve(string[] instructions)
    {
        int[,] keypad = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };

        int x = 1; 
        int y = 1;

        string code = "";

        foreach (string instruction in instructions)
        {
            foreach (char command in instruction)
            {
                int prevX = x, prevY = y; 
                switch (command)
                {
                    case 'U': if (x > 0) x -= 1; break;
                    case 'D': if (x < 2) x += 1; break;
                    case 'L': if (y > 0) y -= 1; break;
                    case 'R': if (y < 2) y += 1; break;
                }
                // Debugging output
                Console.WriteLine($"Moved {command}: Position now at ({x}, {y}) with key {keypad[x, y]}");
            }
            code += keypad[x, y].ToString(); 
            Console.WriteLine($"Current code: {code}"); 
        }
        return code;
    }
}