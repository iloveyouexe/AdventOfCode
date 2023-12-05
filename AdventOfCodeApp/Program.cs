using AdventOfCode.Year2023;

namespace AdventOfCode
{
    class Program
    {
        static void Main()
        {

            // Load inputs for Days problems
            string[] input = LoadDayInput("Year2023/day1.txt"); 
            string result = Day1.Solve(input);
            Console.WriteLine($"Result: {result}");

            input = LoadDayInput("Year2023/day2.txt"); 
            result = Day2.Solve(input);
            Console.WriteLine($"Result: {result}");
        }

        // Load input file for a specific day (Example method)
        static string[] LoadDayInput(string filename)
        {
            // Read input file and return as string array
            // Example code to read file contents
            string[] input = System.IO.File.ReadAllLines(filename);
            return input;
        }
    }
}
