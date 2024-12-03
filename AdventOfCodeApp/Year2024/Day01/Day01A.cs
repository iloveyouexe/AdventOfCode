namespace AdventOfCode.Year2024.Day01;

public class Day01A
{
    public static string Solve(string[] lines)
    {
        var leftList = new List<int>();
        var rightList = new List<int>();
        
        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            
            var splitLine = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            if (splitLine.Length != 2)
            {
                throw new FormatException($"Line '{line}' is not in the correct format (expected two numbers).");
            }
            
            leftList.Add(int.Parse(splitLine[0].Trim()));
            rightList.Add(int.Parse(splitLine[1].Trim()));
        }
        
        leftList.Sort();
        rightList.Sort();
        
        int totalDistance = 0;
        for (int i = 0; i < leftList.Count; i++)
        {
            totalDistance += Math.Abs(leftList[i] - rightList[i]);
        }
        
        return totalDistance.ToString();
    }
}