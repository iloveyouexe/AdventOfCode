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
            for (int i = 0; i < instruction.Length; i++)
            {
                try
                {
                    switch (instruction[i])
                    {
                        case 'U':
                            x = (x > 0) ? x - 1 : throw new IndexOutOfRangeException();
                            break;
                        case 'D':
                            x = (x < 2) ? x + 1 : throw new IndexOutOfRangeException();
                            break;
                        case 'L':
                            y = (y > 0) ? y - 1 : throw new IndexOutOfRangeException();
                            break;
                        case 'R':
                            y = (y < 2) ? y + 1 : throw new IndexOutOfRangeException();
                            break;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    // Swallow the exception and continue with the last valid x or y
                }
            }
            code += keypad[x, y].ToString();
        }
        return code;
    }
}