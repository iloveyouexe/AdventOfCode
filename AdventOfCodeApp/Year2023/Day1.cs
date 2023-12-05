namespace AdventOfCode.Year2023;

public class Day1
{
    public static string Solve(string[] lines)
    {
        int sum = 0;

        foreach (string line in lines)
        {
            // Check if the line is not empty
            if (!string.IsNullOrWhiteSpace(line))
            {
                // Extracting the first and last characters as digits
                char firstChar = line[0];
                char lastChar = line[line.Length - 1];

                // Convert characters to integers
                int firstDigit = firstChar - '0';
                int lastDigit = lastChar - '0';

                // Calculate the calibration value and add it to the sum
                int calibrationValue = (firstDigit * 10) + lastDigit;
                sum += calibrationValue;
            }
        }

        return sum.ToString();
    }
}
