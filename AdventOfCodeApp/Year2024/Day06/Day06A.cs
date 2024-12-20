using System;
using System.Collections.Generic;

namespace AdventOfCode.Year2024.Day06
{
    public class Day06A
    {
        public string Solve(string[] input)
        {
            char[,] map = ParseMap(input);
            (int x, int y, char dir) guard = FindGuard(map);
            HashSet<(int x, int y)> visited = SimulatePatrol(map, guard);
            return visited.Count.ToString();
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

            return map;
        }

        private (int x, int y, char dir) FindGuard(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == '^' || map[i, j] == 'v' || map[i, j] == '<' || map[i, j] == '>')
                    {
                        return (i, j, map[i, j]);
                    }
                }
            }

            throw new Exception("Guard not found on the map.");
        }

        private HashSet<(int x, int y)> SimulatePatrol(char[,] map, (int x, int y, char dir) guard)
        {
            HashSet<(int x, int y)> visited = new();
            (int x, int y, char dir) current = guard;

            while (true)
            {
                visited.Add((current.x, current.y));
                (int dx, int dy) = GetDirection(current.dir);

                int nx = current.x + dx;
                int ny = current.y + dy;

                if (nx < 0 || ny < 0 || nx >= map.GetLength(0) || ny >= map.GetLength(1))
                {
                    break;
                }

                if (map[nx, ny] == '#')
                {
                    current.dir = TurnRight(current.dir);
                }
                else
                {
                    current = (nx, ny, current.dir);
                }
            }

            return visited;
        }

        private (int dx, int dy) GetDirection(char dir)
        {
            return dir switch
            {
                '^' => (-1, 0),
                'v' => (1, 0),
                '<' => (0, -1),
                '>' => (0, 1),
                _ => throw new Exception("Invalid direction")
            };
        }

        private char TurnRight(char dir)
        {
            return dir switch
            {
                '^' => '>',
                '>' => 'v',
                'v' => '<',
                '<' => '^',
                _ => throw new Exception("Invalid direction")
            };
        }
    }
}
