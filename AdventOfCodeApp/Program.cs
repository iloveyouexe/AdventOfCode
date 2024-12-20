using System.Reflection;

namespace AdventOfCode
{
    public class Program
    {
        public static void Main()
        {
            ProblemSolver solver = new ProblemSolver();
            
            solver.RegisterInputReader("comma", new CommaSeparatedInputReader());
            solver.RegisterInputReader("line", new LineSeparatedInputReader());
            
            // solver.SolveProblem("2016", "01", "A", "comma");
            // solver.SolveProblem("2016", "01", "B", "comma");
            // solver.SolveProblem("2016", "02", "A", "line");
            // solver.SolveProblem("2016", "02", "B", "line");
            // solver.SolveProblem("2016", "03", "A", "line");
            // solver.SolveProblem("2016", "04", "A", "line");
            // solver.SolveProblem("2016", "04", "B", "line");
            // solver.SolveProblem("2016", "05", "A", "line");
            // solver.SolveProblem("2016", "05", "B", "line");
            // solver.SolveProblem("2016", "06", "A", "line");
            // solver.SolveProblem("2016", "07", "A", "line");
            // solver.SolveProblem("2016", "07", "B", "line");
            // solver.SolveProblem("2016", "12", "A", "line");
            // solver.SolveProblem("2016", "23", "A", "line");
            // solver.SolveProblem("2017", "23", "A", "line");
            // solver.SolveProblem("2018", "01", "A", "line");
            // solver.SolveProblem("2023", "01", "A", "line");
            // solver.SolveProblem("2023", "01", "B", "line");
            // solver.SolveProblem("2023", "02", "A", "line");
            // solver.SolveProblem("2024", "01", "A", "line");
            // solver.SolveProblem("2024", "01", "B", "line");
            // solver.SolveProblem("2024", "02", "A", "line");
            // solver.SolveProblem("2024", "02", "B", "line");
            // solver.SolveProblem("2024", "03", "A", "line");
            // solver.SolveProblem("2024", "03", "B", "line");
            // solver.SolveProblem("2024", "04", "A", "line");
            // solver.SolveProblem("2024", "04", "B", "line");
            // solver.SolveProblem("2024", "05", "A", "line");
            // solver.SolveProblem("2024", "06", "A", "line");
            solver.SolveProblem("2024", "07", "A", "line");
        }
    }

    public interface IInputReader
    {
        string[] ReadInput(string path);
    }

    public class CommaSeparatedInputReader : IInputReader
    {
        public string[] ReadInput(string path)
        {
            string input = File.ReadAllText(path).Trim();
            return input.Split(", ").Select(s => s.Trim()).ToArray();
        }
    }

    public class LineSeparatedInputReader : IInputReader
    {
        public string[] ReadInput(string path)
        {
            string input = File.ReadAllText(path).Trim();
            return input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(line => line.Trim())
                        .ToArray();
        }
    }

    public class ProblemSolver
    {
        private readonly Dictionary<string, IInputReader?> _inputReaders = new Dictionary<string, IInputReader?>();

        public void RegisterInputReader(string key, IInputReader? reader)
        {
            _inputReaders[key] = reader;
        }

        public void SolveProblem(string year, string day, string variant, string inputReaderKey)
        {
            string typeName = $"AdventOfCode.Year{year}.Day{day}.Day{day}{variant}";
            Console.WriteLine($"Loading {year}/{day}/{variant}...");

            Type? type = Type.GetType(typeName + ", " + Assembly.GetExecutingAssembly().FullName);
            if (type == null)
            {
                Console.WriteLine("Type not found. Ensure namespace and class are correct, and assembly is loaded.");
                return;
            }

            MethodInfo solveMethod = type.GetMethod("Solve") ?? throw new InvalidOperationException();

            string path = $"Year{year}/Day{day}/day{day}.txt";
            if (!_inputReaders.TryGetValue(inputReaderKey, out IInputReader? inputReader))
            {
                Console.WriteLine("Input reader not found for the specified key.");
                return;
            }

            string[] input = inputReader!.ReadInput(path);
            object? problemInstance = Activator.CreateInstance(type);
            if (problemInstance == null)
            {
                Console.WriteLine("Failed to create an instance of the specified type.");
                return;
            }

            object? result = solveMethod.Invoke(problemInstance, new object[] { input });
            if (result == null)
            {
                Console.WriteLine("Result is null. There may have been an error during execution.");
                return;
            }
            Console.WriteLine($"Result: {result}");
        }
    }

    public interface IAdventOfCodeProblem
    {
        string Solve(string[] input);
    }
}
