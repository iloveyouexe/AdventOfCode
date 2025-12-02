using System;
using System.Collections.Generic;

namespace AdventOfCode.Year2024.Day08
{
    public class Day08A
    {
        public string Solve(string[] input)
        {
            char[,] map = ParseMap(input);
            HashSet<(int x, int y)> antinodes = FindAntinodes(map);
            Console.WriteLine($"Total antinodes found: {antinodes.Count}");
            return antinodes.Count.ToString();
        }

        private char[,] ParseMap(string[] input)
        {
            int rows = input.Length;
            int cols = input[0].Length;
            char[,] map = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    map[i, j] = input[i][j];
                }
            }

            // Log the parsed map
            Console.WriteLine("Parsed Map:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }

            return map;
        }

        private HashSet<(int x, int y)> FindAntinodes(char[,] map)
        {
            HashSet<(int x, int y)> antinodes = new();
            Dictionary<char, List<(int x, int y)>> antennas = new();

            // Collect all antenna positions
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    char c = map[i, j];
                    if (char.IsLetterOrDigit(c))
                    {
                        if (!antennas.ContainsKey(c))
                            antennas[c] = new List<(int x, int y)>();
                        antennas[c].Add((i, j));
                    }
                }
            }

            // Log detected antennas
            foreach (var entry in antennas)
            {
                Console.WriteLine($"Frequency {entry.Key}: {string.Join(", ", entry.Value)}");
            }

            // Calculate antinodes for each frequency
            foreach (var entry in antennas)
            {
                var positions = entry.Value;
                Console.WriteLine($"Processing frequency: {entry.Key}");

                for (int i = 0; i < positions.Count; i++)
                {
                    for (int j = i + 1; j < positions.Count; j++)
                    {
                        var p1 = positions[i];
                        var p2 = positions[j];
                        Console.WriteLine($"Pair: ({p1.x}, {p1.y}) and ({p2.x}, {p2.y})");

                        if (IsDoubleDistance(p1, p2, out var midpoint))
                        {
                            Console.WriteLine($"Antinode found at midpoint: ({midpoint.x}, {midpoint.y})");

                            // Add midpoint
                            if (IsWithinBounds(midpoint, map))
                            {
                                antinodes.Add(midpoint);
                                Console.WriteLine($"Midpoint added: ({midpoint.x}, {midpoint.y})");
                            }

                            // Reflect midpoint
                            (int x, int y) reflection = (2 * p1.x - midpoint.x, 2 * p1.y - midpoint.y);
                            if (IsWithinBounds(reflection, map))
                            {
                                antinodes.Add(reflection);
                                Console.WriteLine($"Reflection added: ({reflection.x}, {reflection.y})");
                            }
                        }
                    }
                }
            }

            return antinodes;
        }

        private bool IsDoubleDistance((int x, int y) p1, (int x, int y) p2, out (int x, int y) midpoint)
        {
            int dx = p2.x - p1.x;
            int dy = p2.y - p1.y;

            if (dx % 2 != 0 || dy % 2 != 0)
            {
                midpoint = (0, 0);
                return false;
            }

            midpoint = (p1.x + dx / 2, p1.y + dy / 2);
            Console.WriteLine($"Checking midpoint for ({p1.x}, {p1.y}) and ({p2.x}, {p2.y}): ({midpoint.x}, {midpoint.y})");

            return true;
        }

        private bool IsWithinBounds((int x, int y) point, char[,] map)
        {
            bool inBounds = point.x >= 0 && point.y >= 0 && point.x < map.GetLength(0) && point.y < map.GetLength(1);
            Console.WriteLine($"Point ({point.x}, {point.y}) is within bounds: {inBounds}");
            return inBounds;
        }
    }
}
