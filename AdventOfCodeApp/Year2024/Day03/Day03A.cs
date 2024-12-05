using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode.Year2024.Day03;

public class Day03A
{
    public static string Solve(string[] lines)
    {
        string memory = string.Join("", lines);
        int sum = 0;
        
        string pattern = @"mul\((\d{1,3}),(\d{1,3})\)";
        Regex regex = new Regex(pattern);
        
        MatchCollection matches = regex.Matches(memory);

        foreach (Match match in matches)
        {
            int x = int.Parse(match.Groups[1].Value);
            int y = int.Parse(match.Groups[2].Value);
            
            sum += x * y;
        }

        return sum.ToString();
    }
}