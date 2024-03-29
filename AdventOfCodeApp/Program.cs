﻿using System.IO;
using AdventOfCode.Year2016.Day12;
using AdventOfCode.Year2018;
using AdventOfCode.Year2023;

namespace AdventOfCode
{
    internal class Program
    {
        private static void Main()
        {
            var input = LoadDayInput("Year2016/Day12/day12.txt");
            var result = Day12A.Solve(input);
            Console.WriteLine($"Day 12A Result (Year 2016): {result}");
            
            input = LoadDayInput("../../../Year2017/Day23/day23.txt");
            result = Year2017.Day23A.Solve(input);
            Console.WriteLine($"Day 23A Result (Year2017): {result}");
            
            input = LoadDayInput("../../../Year2018/Day01/day1.txt");
            result = Year2018.Day01.Day1A.Solve(input);
            Console.WriteLine($"Day 1A Result (Year2018): {result}");
            
            input = LoadDayInput("../../../Year2018/Day02/day2.txt");
            result = Year2018.Day02.Day2A.Solve(input);
            Console.WriteLine($"Day 2A Result (Year2018): {result}");
            
            input = LoadDayInput("../../../Year2018/Day02/day2.txt"); 
            result = Year2018.Day02.Day2B.Solve(input);
            Console.WriteLine($"Day 2B Result (Year2018): {result}");
            
            input = LoadDayInput("Year2023/Day01/day1.txt");
            result = Day1A.Solve(input);
            Console.WriteLine($"Day 1A Result (Year 2023): {result}");

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
}