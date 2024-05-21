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

            var columnFrequencies = new Dictionary<char, int>[length];
            for (int i = 0; i < length; i++)
            {
                columnFrequencies[i] = new Dictionary<char, int>();
            }

            foreach (var message in transmissionStrings)
            {
                for (int i = 0; i < length; i++)
                {
                    char currentChar = message[i];
                    if (!columnFrequencies[i].ContainsKey(currentChar))
                    {
                        columnFrequencies[i][currentChar] = 0;
                    }
                    columnFrequencies[i][currentChar]++;
                }
            }

            for (int i = 0; i < length; i++)
            {
                frequencyCounters[i] = columnFrequencies[i]
                    .OrderByDescending(kv => kv.Value)
                    .First().Key;
            }

            return new string(frequencyCounters);
        }
    }
}