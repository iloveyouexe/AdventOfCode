namespace AdventOfCode.Year2016.Day12;

public static class Day12A
{
    public static string Solve(string[] opCodes)
    {
        var computer = new AssembunnyComputer();
        
        return computer.A.ToString();
    }
}

public class AssembunnyComputer
{
    public int A { get; set; }
    public int B { get; set; }
    public int C { get; set; }
    public int D { get; set; }

    public void Execute(string opCode)
    {
        if (opCode.StartsWith("inc"))
        {
            if (opCode[4] == 'a')
            {
                A++;
            }

            if (opCode[4] == 'b')
            {
                B++;
            }
            
        }
    }
}