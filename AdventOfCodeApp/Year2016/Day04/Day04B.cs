using System.Text.RegularExpressions;

namespace AdventOfCode.Year2016.Day04;

public class Day04B
{
    public static string Solve(string[] instructions)
    {
        int sumOfSectorIds = 0;
        var validInstructions = new List<string>();
        
        instructions = instructions[0].Split("\n", StringSplitOptions.RemoveEmptyEntries);
            
        foreach (var instruction in instructions)
        {
            var match = Regex.Match(instruction, @"([a-z-]+)-(\d+)\[([a-z]+)\]");
            if (match.Success)
            {
                var encryptedName = match.Groups[1].Value;
                var sectorId = int.Parse(match.Groups[2].Value);
                var checksum = match.Groups[3].Value;

                if (IsRealRoom(encryptedName, checksum))
                {
                    sumOfSectorIds += sectorId;
                    validInstructions.Add(instruction);
                }
            }
        }
        return sumOfSectorIds.ToString();
    }
    
    private static bool IsRealRoom(string name, string checksum)
    {
        var nameWithoutDashes = name.Replace("-", "");
        var letterCounts = new Dictionary<char, int>();

        foreach (var c in nameWithoutDashes)
        {
            if (!letterCounts.ContainsKey(c))
            {
                letterCounts[c] = 0;
            }
            letterCounts[c]++;
        }

        var sortedLetters = letterCounts
            .OrderByDescending(kvp => kvp.Value)
            .ThenBy(kvp => kvp.Key)
            .Select(kvp => kvp.Key)
            .Take(5);

        var calculatedChecksum = new string(sortedLetters.ToArray());
        return calculatedChecksum == checksum;
    }
}