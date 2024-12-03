namespace AdventOfCode.Year2024.Day01;

public class Day01B
{
    public static string Solve(string[] lines)
    {
        var leftList = new List<int>();
        var rightList = new List<int>();
        
        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            var splitLine = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            leftList.Add(int.Parse(splitLine[0].Trim()));
            rightList.Add(int.Parse(splitLine[1].Trim()));
        }
        
        var rightFrequency = new Dictionary<int, int>();
        foreach (var number in rightList)
        {
            if (!rightFrequency.ContainsKey(number))
            {
                rightFrequency[number] = 0;
            }
            rightFrequency[number]++;
        }
        
        int similarityScore = 0;
        foreach (var number in leftList)
        {
            if (rightFrequency.ContainsKey(number))
            {
                similarityScore += number * rightFrequency[number];
            }
        }

        return similarityScore.ToString();
    }
}