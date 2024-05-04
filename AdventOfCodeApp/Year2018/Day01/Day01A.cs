namespace AdventOfCode.Year2018.Day01;

public class Day01A
{
    public static string Solve(string[] changes)
    {
        // current
        int resultFrequency = 0;

        foreach (string frequencyChange in changes)
        {
            int change = int.Parse(frequencyChange);

            resultFrequency += change;
        }
        return resultFrequency.ToString();
    }
}