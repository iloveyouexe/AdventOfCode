using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode.Year2024.Day03;

public class Day03B
{
    public static string Solve(string[] lines)
    {
        string memory = string.Join("", lines);
        int sum = 0;
        bool isEnabled = true;
        
        string pattern = @"mul\((\d{1,3}),(\d{1,3})\)|do\(\)|don't\(\)";
        Regex regex = new Regex(pattern);
        
        MatchCollection matches = regex.Matches(memory);

        foreach (Match match in matches)
        {
            if (match.Value == "do()")
            {
                isEnabled = true;
            }
            else if (match.Value == "don't()")
            {
                isEnabled = false;
            }
            else if (isEnabled && match.Value.StartsWith("mul"))
            {
                int x = int.Parse(match.Groups[1].Value);
                int y = int.Parse(match.Groups[2].Value);
                
                sum += x * y;
            }
        }

        return sum.ToString();
    }
}