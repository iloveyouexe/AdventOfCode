using System;
using System.Collections.Generic;

namespace AdventOfCode.Year2024.Day07
{
    public class Day07A
    {
        public string Solve(string[] input)
        {
            long totalCalibrationResult = 0;

            foreach (var line in input)
            {
                var (target, numbers) = ParseLine(line);
                if (CanProduceTarget(target, numbers))
                {
                    totalCalibrationResult += target;
                }
            }

            return totalCalibrationResult.ToString();
        }

        private (long target, long[] numbers) ParseLine(string line)
        {
            var parts = line.Split(':');
            long target = long.Parse(parts[0].Trim());
            long[] numbers = Array.ConvertAll(parts[1].Trim().Split(' '), long.Parse);
            return (target, numbers);
        }

        private bool CanProduceTarget(long target, long[] numbers)
        {
            return EvaluateCombinations(numbers, target, 0, numbers[0]);
        }

        private bool EvaluateCombinations(long[] numbers, long target, int index, long currentValue)
        {
            if (index == numbers.Length - 1)
            {
                return currentValue == target;
            }

            if (EvaluateCombinations(numbers, target, index + 1, currentValue + numbers[index + 1]))
            {
                return true;
            }

            if (EvaluateCombinations(numbers, target, index + 1, currentValue * numbers[index + 1]))
            {
                return true;
            }

            return false;
        }
    }
}