using System;
using AdventOfCode.Days; // Import the namespace where DayOne class resides

namespace AdventOfCode
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Choose a day to run:");
            Console.WriteLine("1. Day One");
            // Add more options for other days

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    // Call DayOne logic here
                    string[] dayOneInput = LoadDayInput("day1.txt"); // Load input for Day One from a file
                    int dayOneResult = DayOne.CalculateCalibrationSum(dayOneInput);
                    Console.WriteLine($"Result for Day One: {dayOneResult}");
                    break;
                // Add cases for other days
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
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
