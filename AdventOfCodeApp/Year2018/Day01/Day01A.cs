namespace AdventOfCode.Year2018.Day01
{
    public class Day01A
    {
        public static string Solve(string[] changes)
        {
            int resultFrequency = 0;

            foreach (string frequencyChange in changes)
            {
                try
                {
                    string cleanedChange = frequencyChange.Trim('\'');
                    int change = int.Parse(cleanedChange);

                    resultFrequency += change;
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Invalid format: ");
                }
            }
            return resultFrequency.ToString();
        }
    }
}