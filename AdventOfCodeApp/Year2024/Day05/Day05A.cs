using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2024.Day05
{
    public class Day05A 
    {
        public string Solve(string[] lines)
        {
            var (rules, updates) = ParseInput(lines);
            int sum = SumMiddlePages(rules, updates);
            return sum.ToString();
        }

        private static (Dictionary<int, HashSet<int>>, List<List<int>>) ParseInput(string[] input)
        {
            var rules = new Dictionary<int, HashSet<int>>();
            var updates = new List<List<int>>();
            bool parsingRules = true;

            foreach (var line in input)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                if (parsingRules)
                {
                    if (line.Contains('|'))
                    {
                        var parts = line.Split('|');
                        if (parts.Length != 2)
                            throw new FormatException($"Invalid rule format: {line}");

                        int before = int.Parse(parts[0].Trim());
                        int after = int.Parse(parts[1].Trim());

                        if (!rules.ContainsKey(before)) rules[before] = new HashSet<int>();
                        rules[before].Add(after);
                    }
                    else
                    {
                        parsingRules = false;
                    }
                }

                if (!parsingRules)
                {
                    if (line.Contains(','))
                    {
                        updates.Add(line.Split(',')
                            .Select(x => int.Parse(x.Trim()))
                            .ToList());
                    }
                    else
                    {
                        throw new FormatException($"Invalid update format: {line}");
                    }
                }
            }
            return (rules, updates);
        }
        
        private static int SumMiddlePages(Dictionary<int, HashSet<int>> rules, List<List<int>> updates)
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

        private static bool IsCorrectOrder(Dictionary<int, HashSet<int>> rules, List<int> update)
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
}
