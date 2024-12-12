using System;
using System.Collections.Generic;
using System.Linq;
namespace AdventOfCode.Year2024.Day05;

public class Day05A
{
    public static string Solve(string[] lines)
    {
        string[] input = System.IO.File.ReadAllLines("input.txt");
        var (rules, updates) = ParseInput(input);
        int sum = SumMiddlePages(rules, updates);
        return sum.ToString();
    }

    static (Dictionary<int, HashSet<int>>, List<List<int>>) ParseInput(string[] input)
    {
        var rules = new Dictionary<int, HashSet<int>>();
        var updates = new List<List<int>>();
        bool parsingRules = true;

        foreach (var line in input)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                parsingRules = false;
                continue;
            }

            if (parsingRules)
            {
                var parts = line.Split('|');
                int before = int.Parse(parts[0]);
                int after = int.Parse(parts[1]);
                if (!rules.ContainsKey(before)) rules[before] = new HashSet<int>();
                rules[before].Add(after);
            }
            else
            {
                updates.Add(line.Split(',').Select(int.Parse).ToList());
            }
        }

        return (rules, updates);
    }

    static int SumMiddlePages(Dictionary<int, HashSet<int>> rules, List<List<int>> updates)
    {
        int sum = 0;

        foreach (var update in updates)
        {
            if (IsCorrectOrder(rules, update))
            {
                int middleIndex = update.Count / 2;
                sum += update[middleIndex];
            }
        }

        return sum;
    }

    static bool IsCorrectOrder(Dictionary<int, HashSet<int>> rules, List<int> update)
    {
        for (int i = 0; i < update.Count; i++)
        {
            for (int j = i + 1; j < update.Count; j++)
            {
                if (rules.ContainsKey(update[j]) && rules[update[j]].Contains(update[i]))
                {
                    return false;
                }
            }
        }
        return true;
    }
}
