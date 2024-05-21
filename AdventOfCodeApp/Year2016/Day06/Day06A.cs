using System;
using System.Linq;

namespace AdventOfCode.Year2016.Day06
{
    public class Day06A : IAdventOfCodeProblem
    {
        public string Solve(string[] transmissionStrings)
        {
            int length = transmissionStrings[0].Length;
            var frequencyCounters = new char[length];

            foreach (var message in transmissionStrings)
            {
                for (int i = 0; i < length; i++)
                {
                    frequencyCounters[i] = transmissionStrings.Select(t => t[i])
                        .GroupBy(c => c)
                        .OrderByDescending(g => g.Count())
                        .First()
                        .Key;
                }
            }

            return new string(frequencyCounters);
        }
    }
}