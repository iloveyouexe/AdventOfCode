using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode.Year2016.Day07
{
    public class Day07B : IAdventOfCodeProblem
    {
        public string Solve(string[] puzzleInput)
        {
            int count = 0;
            foreach (var ip in puzzleInput)
            {
                if (SupportsSSL(ip))
                {
                    count++;
                }
            }

            return count.ToString();
        }

        private bool SupportsSSL(string ip)
        {
            var parts = Regex.Split(ip, @"(\[.*?\])");
            var abas = new List<string>();
            var babs = new List<string>();

            foreach (var part in parts)
            {
                if (part.StartsWith("[") && part.EndsWith("]"))
                {
                    babs.AddRange(ExtractBabs(part.Trim('[', ']')));
                }
                else
                {
                    abas.AddRange(ExtractAbas(part));
                }
            }

            foreach (var aba in abas)
            {
                var bab = $"{aba[1]}{aba[0]}{aba[1]}";
                if (babs.Contains(bab))
                {
                    return true;
                }
            }

            return false;
        }

        private IEnumerable<string> ExtractAbas(string segment)
        {
            var abas = new List<string>();
            for (int i = 0; i < segment.Length - 2; i++)
            {
                if (segment[i] == segment[i + 2] && segment[i] != segment[i + 1])
                {
                    abas.Add(segment.Substring(i, 3));
                }
            }
            return abas;
        }

        private IEnumerable<string> ExtractBabs(string segment)
        {
            var babs = new List<string>();
            for (int i = 0; i < segment.Length - 2; i++)
            {
                if (segment[i] == segment[i + 2] && segment[i] != segment[i + 1])
                {
                    babs.Add(segment.Substring(i, 3));
                }
            }
            return babs;
        }
    }
}
