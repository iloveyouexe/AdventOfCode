namespace AdventOfCode.Year2016.Day03;

public class Day03A : IAdventOfCodeProblem
{
    public string Solve(string[] instructions)
    {
        int validTriangles = 0;

        instructions = instructions[0].Split("\n", StringSplitOptions.RemoveEmptyEntries);
        
        foreach (var instruction in instructions)
        {
            
            var parts = instruction.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int triangleSideOne = parts[0];
            int triangleSideTwo = parts[1];
            int triangleSideThree = parts[2];

            if (triangleSideOne + triangleSideTwo > triangleSideThree &&
                triangleSideOne + triangleSideThree > triangleSideTwo &&
                triangleSideTwo + triangleSideThree > triangleSideOne)
            {
                validTriangles++; 
            }
        }
        return validTriangles.ToString();
    }
}