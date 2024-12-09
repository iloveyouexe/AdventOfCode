namespace AdventOfCode.Year2024.Day04;

public class Day04A
{
    private static readonly (int, int)[] Directions = new[]
    {
        (0, 1),  // Right
        (0, -1), // Left
        (1, 0),  // Down
        (-1, 0), // Up
        (1, 1),  // Down-Right
        (1, -1), // Down-Left
        (-1, 1), // Up-Right
        (-1, -1) // Up-Left
    };

    public static string Solve(string[] lines)
    {
        char[,] grid = ParseGrid(lines);
        int rows = grid.GetLength(0);
        int cols = grid.GetLength(1);
        string target = "XMAS";
        int count = 0;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                foreach (var (dr, dc) in Directions)
                {
                    if (MatchesWord(grid, r, c, dr, dc, target))
                    {
                        count++;
                    }
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

    private static bool MatchesWord(char[,] grid, int r, int c, int dr, int dc, string word)
    {
        int rows = grid.GetLength(0);
        int cols = grid.GetLength(1);

        for (int i = 0; i < word.Length; i++)
        {
            int nr = r + i * dr;
            int nc = c + i * dc;

            if (nr < 0 || nr >= rows || nc < 0 || nc >= cols || grid[nr, nc] != word[i])
            {
                return false;
            }
        }

        return true;
    }
}