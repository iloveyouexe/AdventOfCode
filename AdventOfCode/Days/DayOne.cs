using System;
using System.IO;

namespace AdventOfCode.Days
{
    public class DayOne
    {
        static void Main()
        {
            //Read the puzzle input from a file
            string[] lines = File.ReadAllLines("input.txt");

            int sum = 0;

            foreach (string line in lines)
            {
                //Check if the line is not empty
                if (!string.IsNullOrWhiteSpace(line))
                {
                    //Extracting the first and last characters as digits
                    char firstChar = line[0];
                    char lastChar = line[line.Length - 1];

                    //Convert characters to integers
                    int firstDigit = int.Parse(firstChar.ToString());
                    int lastDigit = int.Parse(lastChar.ToString());

                    //Calculate the the calibration value and add it to the sum
                    int calibrationValue = (firstDigit * 10) + lastDigit;
                    sum += calibrationValue;
                }
            }
            Console.WriteLine($"Sum of calibration values: {sum}");
        }
    }
}