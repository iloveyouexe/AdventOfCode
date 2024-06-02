using System.Text.RegularExpressions;

namespace AdventOfCode.Year2016.Day07
{ 
    public class Day07A : IAdventOfCodeProblem 
    {
        public string Solve(string[] puzzleInput)
        {
            int count = 0;
            foreach (var ip in puzzleInput)
            {
                if (SupportsTLS(ip))
                {
                    count++;
                }
            }

            return count.ToString();
        }
        private bool SupportsTLS(string ip)
        {
            var parts = Regex.Split(ip, @"(\[.*?\])");
            bool hasAbbaOutsideBrackets = false;
            bool hasAbbaInsideBrackets = false;
            foreach (var part in parts)
            {
                if (part.StartsWith("[") && part.EndsWith("]"))
                {
                    if (ContainsAbba(part.Trim('[', ']')))
                    {
                        hasAbbaInsideBrackets = true;
                    }
                }
                else
                {
                    if (ContainsAbba(part))
                    {
                        hasAbbaOutsideBrackets = true;
                    }
                }
            }
            return hasAbbaOutsideBrackets && !hasAbbaInsideBrackets;
        }
        private bool ContainsAbba(string segment)
        {
            for (int i = 0; i < segment.Length - 3; i++)
            {
                if (segment[i] != segment[i + 1] &&
                    segment[i] == segment[i + 3] &&
                    segment[i + 1] == segment[i + 2])
                {
                    return true;
                }
            }
            return false;
        }
    }
}

