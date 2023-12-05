using AdventOfCode.Days;

namespace AdventOfCode
{
    class Program
    {
        static void Main()
        {
           
            string[] input = LoadDayInput("Year2023/day1.txt"); // Load input for Day One from a file
            string result = DayOne.Solve(input);
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
