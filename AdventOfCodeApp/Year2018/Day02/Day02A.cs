using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2018.Day02
{
    public class Day02A
    {
        public static string Solve(string[] lines)
        {
            int exactlyTwo = 0;
            int exactlyThree = 0;

            foreach (string boxID in lines)
            {
                if (HasExactlyTwoRepeatingCharacters(boxID))
                    exactlyTwo++;

                if (HasExactlyThreeRepeatingCharacters(boxID))
                    exactlyThree++;
            }

            // Calculate 
            int checksum = exactlyTwo * exactlyThree;
            return checksum.ToString();
        }
        // 
        static bool HasExactlyTwoRepeatingCharacters(string boxID)
        {
            Dictionary<char, int> charCount = new Dictionary<char, int>();

            foreach (char c in boxID)
            {
                if (charCount.ContainsKey(c))
                    charCount[c]++;
                else
                    charCount[c] = 1;
            }

            return charCount.ContainsValue(2);
        }

        static bool HasExactlyThreeRepeatingCharacters(string boxID)
        {
            Dictionary<char, int> charCount = new Dictionary<char, int>();

            foreach (char c in boxID)
            {
                if (charCount.ContainsKey(c))
                    charCount[c]++;
                else
                    charCount[c] = 1;
            }

            return charCount.ContainsValue(3);
        }
        
        
        //Way of doing it utilizing ascii
        static bool HasExactlyThreeRepeatingCharacters2(string boxID)
        {
            var charCount = new int[26];
            
            foreach (var c in boxID)
            {
                charCount[c-'a']++;
            }

            return charCount.Any(cnt => cnt == 3);
        }
    }
}