namespace AdventOfCode.Year2018.Day02;

public class Day2B
{
    public static string Solve(string[] lines)
    {
        for (int i = 0; i < lines.Length; i++)
        {
            for (int j = i + 1; j < lines.Length; j++)
            {
                string boxID1 = lines[i];
                string boxID2 = lines[j];

                if (AreClose(boxID1, boxID2))
                {
                    return GetCommonLetters(boxID1, boxID2);
                }
            }
        }

        return "No matching IDs found.";
    }

    static bool AreClose(string boxID1, string boxID2)
    {
        int differences = 0;

        for (int i = 0; i < boxID1.Length; i++)
        {
            if (boxID1[i] != boxID2[i])
            {
                differences++;

                if (differences > 1)
                {
                    return false;
                }
            }
        }

        return differences == 1;
    }

    static string GetCommonLetters(string boxID1, string boxID2)
    {
        return new string(boxID1.Where((c, i) => c == boxID2[i]).ToArray());
    }
}