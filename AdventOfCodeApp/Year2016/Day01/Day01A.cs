namespace AdventOfCode.Year2016.Day01;

public class Day01A : IAdventOfCodeProblem
{
    public string Solve(string[] directions)
    {
        int x = 0, y = 0;
        int directionIndex = 0;
        int[] dx = { 0, 1, 0, -1 };
        int[] dy = { 1, 0, -1, 0 };

        foreach (var move in directions)
        {
            var turn = move.Trim()[0];
            var blocks = int.Parse(move.Substring(1));  

            if (turn == 'R')
                directionIndex = (directionIndex + 1) % 4;
            else if (turn == 'L')
                directionIndex = (directionIndex + 3) % 4;

            x += dx[directionIndex] * blocks;
            y += dy[directionIndex] * blocks;
        }
        
        int distance = Math.Abs(x) + Math.Abs(y);
        return distance.ToString();
    }
}