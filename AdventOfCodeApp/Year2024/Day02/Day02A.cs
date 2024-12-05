namespace AdventOfCode.Year2024.Day02;

public class Day02A
{
    public static string Solve(string[] lines)
    {
        int safeReportCount = 0;

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            
            var levels = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            if (IsSafeReport(levels))
            {
                safeReportCount++;
            }
        }

        return safeReportCount.ToString();
    }

    private static bool IsSafeReport(List<int> levels)
    {
        if (levels.Count < 2) return false;

        bool isIncreasing = levels[1] > levels[0];
        bool isConsistent = true;

        for (int i = 1; i < levels.Count; i++)
        {
            int diff = levels[i] - levels[i - 1];
            
            if (Math.Abs(diff) < 1 || Math.Abs(diff) > 3)
            {
                isConsistent = false;
                break;
            }
            
            if ((isIncreasing && diff < 0) || (!isIncreasing && diff > 0))
            {
                isConsistent = false;
                break;
            }
        }

        return isConsistent;
    }
}