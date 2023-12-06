namespace AdventOfCode.Year2023;

public class Day1
{
    public static string Solve(string[] lines)
    {
        var sum = 0;

        foreach (var line in lines)
            // Check if the line is not empty
            if (!string.IsNullOrWhiteSpace(line))
            {
                // Extracting the first and last characters as digits
                var firstChar = line[0];
                var lastChar = line[line.Length - 1];

                // Convert characters to integers
                var firstDigit = firstChar - '0';
                var lastDigit = lastChar - '0';

                // Calculate the calibration value and add it to the sum
                var calibrationValue = firstDigit * 10 + lastDigit;
                sum += calibrationValue;
            }

        return sum.ToString();
    }
}