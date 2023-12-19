using AdventOfCode.Year2023;

namespace AdventOfCode;

internal class Program
{
    private static void Main()
    {
        // Load inputs for Days problems
        var input = LoadDayInput("Year2023/Day01/day2.txt");
        var result = Day1A.Solve(input);
        Console.WriteLine($"Day 1 Result: {result}");

        input = LoadDayInput("Year2023/Day02/day2.txt");
        result = Day2A.Solve(input);
        Console.WriteLine($"Day 2 Result: {result}");
        
        input = LoadDayInput("Year2018/Day02/day2.txt");
        result = Day2A.Solve(input);
        Console.WriteLine($"Day 2 Result: {result}");
    }

    // Load input file for a specific day (Example method)
    private static string[] LoadDayInput(string filename)
    {
        // Read input file and return as string array
        // Example code to read file contents
        var input = File.ReadAllLines(filename);
        return input;
    }
}