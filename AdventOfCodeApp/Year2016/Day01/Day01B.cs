namespace AdventOfCode.Year2016.Day01;

public static class Day01B
{
    public static string Solve(string[] directions)
    {
        int x = 0, y = 0;
        int directionIndex = 0;
        int[] dx = { 0, 1, 0, -1 };
        int[] dy = { 1, 0, -1, 0 };
        var visited = new HashSet<(int, int)>();

        visited.Add((x, y));

        foreach (var move in directions)
        {
            var turn = move.Trim()[0];
            var blocks = int.Parse(move.Substring(1));  

            if (turn == 'R')
                directionIndex = (directionIndex + 1) % 4;
            else if (turn == 'L')
                directionIndex = (directionIndex + 3) % 4;

            for (int i = 0; i < blocks; i++)
            {
                x += dx[directionIndex];
                y += dy[directionIndex];
                
                if (visited.Contains((x, y)))
                {
                    return Math.Abs(x) + Math.Abs(y) + "";
                }
                visited.Add((x, y)); 
            }
        }
        return "No repeated location found.";
    }
}