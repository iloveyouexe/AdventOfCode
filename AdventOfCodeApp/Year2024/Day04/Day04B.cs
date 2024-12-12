namespace AdventOfCode.Year2024.Day04;

public class Day04B
{
    public static string Solve(string[] lines)
    {
        char[,] grid = ParseGrid(lines);
        int rows = grid.GetLength(0);
        int cols = grid.GetLength(1);
        int count = 0;

        for (int r = 1; r < rows - 1; r++)
        {
            for (int c = 1; c < cols - 1; c++)
            {
                if (IsXMASPattern(grid, r, c))
                {
                    count++;
                }
            }
        }

        return count.ToString();
    }

    private static char[,] ParseGrid(string[] lines)
    {
        int rows = lines.Length;
        int cols = lines[0].Length;
        char[,] grid = new char[rows, cols];

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                grid[r, c] = lines[r][c];
            }
        }

        return grid;
    }

    private static bool IsXMASPattern(char[,] grid, int r, int c)
    {
        // Check top-left, top-right, center, bottom-left, bottom-right
        char topLeft = grid[r - 1, c - 1];
        char topRight = grid[r - 1, c + 1];
        char center = grid[r, c];
        char bottomLeft = grid[r + 1, c - 1];
        char bottomRight = grid[r + 1, c + 1];

        // Check both MAS configurations
        bool mas1 = (topLeft == 'M' && topRight == 'S' && center == 'A' &&
                     bottomLeft == 'M' && bottomRight == 'S');
        bool mas2 = (topLeft == 'S' && topRight == 'M' && center == 'A' &&
                     bottomLeft == 'S' && bottomRight == 'M');

        return mas1 || mas2;
    }
}