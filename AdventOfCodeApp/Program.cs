using System;
using System.IO;
using System.Reflection;

namespace AdventOfCode
{
    public class Program
    {
        public static void Main()
        {
            ProblemSolver solver = new ProblemSolver();

            solver.SolveProblem("2016", "01", "A");
            solver.SolveProblem("2016", "01", "B");
            solver.SolveProblem("2016", "02", "A");
            solver.SolveProblem("2016", "03", "A");
            solver.SolveProblem("2016", "04", "A");
            solver.SolveProblem("2016", "12", "A");
            solver.SolveProblem("2017", "23", "A");
            solver.SolveProblem("2018", "01", "A");
            solver.SolveProblem("2023", "01", "A");
            solver.SolveProblem("2023", "01", "B");
            solver.SolveProblem("2023", "02", "A");
        }
    }

    public static class InputReader
    {
        public static string[] ReadInput(string year, string day, string variant)
        {
            string path = $"Year{year}/Day{day}/day{day}.txt";
            try
            {
                string input = File.ReadAllText(path).Trim(); 
                return input.Split(", "); 
            }
            catch (IOException e)
            {
                Console.WriteLine($"Failed to read {path}: {e.Message}");
                return new string[0];
            }
        }
    }

    public class ProblemSolver
    {
        public void SolveProblem(string year, string day, string variant)
        {
            string typeName = $"AdventOfCode.Year{year}.Day{day}.Day{day}{variant}";
            Console.WriteLine($"Attempting to load type: {typeName}");
    
            Type type = Type.GetType(typeName + ", " + Assembly.GetExecutingAssembly().FullName);
            if (type == null)
            {
                Console.WriteLine("Type not found. Ensure namespace and class are correct, and assembly is loaded.");
                return;
            }

            MethodInfo solveMethod = type.GetMethod("Solve"); 
            if (solveMethod == null)
            {
                Console.WriteLine("Solve method not found in the type specified.");
                return;
            }

            string[] input = InputReader.ReadInput(year, day, variant);
            object result = solveMethod.Invoke(null, new object[] { input });
            if (result == null)
            {
                Console.WriteLine("Result is null. There may have been an error during execution.");
                return;
            }
            Console.WriteLine($"Result for Year {year} Day {day}{variant}: {result.ToString()}");
        }
    }

    public interface IAdventOfCodeProblem
    {   
        string Solve(string[] input);
    }
}