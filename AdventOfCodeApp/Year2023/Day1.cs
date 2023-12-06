namespace AdventOfCode.Year2023;

public class Day1
{
    public static string Solve(string[] lines)
    {
        var sum = 0;

        foreach (var line in lines)
        {
            // Find the first digit in the line
            var firstDigitIndex = -1;
            for (int i = 0; i < line.Length; i++)
            {
                if (char.IsDigit(line[i]))
                {
                    firstDigitIndex = i;
                    break;
                }
            }

            // Find the last digit in the line
            var lastDigitIndex = -1;
            for (int i = line.Length - 1; i >= 0; i--)
            {
                if (char.IsDigit(line[i]))
                {
                    lastDigitIndex = i;
                    break;
                }
            }

            // If both first and last digits are found, extract and calculate the value
            if (firstDigitIndex != -1 && lastDigitIndex != -1)
            {
                var firstDigit = line[firstDigitIndex] - '0';
                var lastDigit = line[lastDigitIndex] - '0';
                var calibrationValue = firstDigit * 10 + lastDigit;
                sum += calibrationValue;
            }
        }

        return sum.ToString();
    }
}
