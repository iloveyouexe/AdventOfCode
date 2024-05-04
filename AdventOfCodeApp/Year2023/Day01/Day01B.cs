
namespace AdventOfCode.Year2023
{
    public class Day01B
    {
        private static readonly Dictionary<string, int> NumberWords = new Dictionary<string, int>
        {
            {"one", 1}, {"two", 2}, {"three", 3}, {"four", 4}, {"five", 5},
            {"six", 6}, {"seven", 7}, {"eight", 8}, {"nine", 9}
        };

        public static string Solve(string[] lines)
        {
            var results = new List<int>();

            foreach (var line in lines)
            {
                var combinedNumber = ExtractNumber(line);
                if (combinedNumber.HasValue)
                {
                    results.Add(combinedNumber.Value);
                }
            }

            var finalResult = results.Sum();
            return finalResult.ToString().PadLeft(3, '0');
        }

        private static int? ExtractNumber(string line)
        {
            var extractedNumbers = new List<int>();
            var currentNumber = 0;
            var hasNumber = false;

            for (var i = 0; i < line.Length; i++)
            {
                var character = line[i];

                if (char.IsDigit(character))
                {
                    currentNumber = currentNumber * 10 + (character - '0');
                    hasNumber = true;
                }
                else if (char.IsLetter(character))
                {
                    var word = "";
                    for (var j = i; j < line.Length && char.IsLetter(line[j]); j++)
                    {
                        word += line[j];
                        if (word.Length >= 3)
                        {
                            if (NumberWords.TryGetValue(word, out int num))
                            {
                                currentNumber = currentNumber * 10 + num;
                                hasNumber = true;
                                i = j;
                                break;
                            }
                        }
                    }
                }

                if (!char.IsLetterOrDigit(character) && hasNumber)
                {
                    extractedNumbers.Add(currentNumber);
                    currentNumber = 0;
                    hasNumber = false;
                }
            }

            return extractedNumbers.Count > 1 ? extractedNumbers.First() * 10 + extractedNumbers.Last() : (int?)null;
        }


    }
}