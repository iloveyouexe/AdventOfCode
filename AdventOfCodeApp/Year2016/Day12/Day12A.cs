namespace AdventOfCode.Year2016.Day12;

public static class Day12A
{
    public static string Solve(string[] opCodes)
    {
        var computer = new AssembunnyComputer();
        computer.Execute(opCodes);
        return computer.Registers['a'].ToString();
    }
}

public class AssembunnyComputer
{
    public IDictionary<char, int> Registers = new Dictionary<char, int>
    {
        { 'a', 0 },
        { 'b', 0 },
        { 'c', 0 },
        { 'd', 0 }
    };

    public void Execute(string[] opCodes)
    {
        int currentIndex = 0;

        while (currentIndex < opCodes.Length)
        {
            string opCode = opCodes[currentIndex];
            string[] parts = opCode.Split(' ');
            
            // Console.WriteLine($"currentIndex: {currentIndex}, opCode: {opCode}, parts: [{string.Join(", ", parts)}]");
            

            string command = parts[0];
            string param1 = parts[1];
            string param2 = parts.Length > 2 ? parts[2] : string.Empty;

            if (command == "jnz")
            {
                int jumpValue = GetValue(param1);
                if (jumpValue != 0)
                {
                    currentIndex += GetValue(param2);
                }
                else
                {
                    currentIndex++;
                }
            }
            else if (command == "inc")
            {
                var register = GetRegister(param1);
                IncrementRegister(register);
                currentIndex++;
            }
            else if (command == "dec")
            {
                var register = GetRegister(param1);
                DecrementRegister(register);
                currentIndex++;
            } else if (command == "cpy")
            {
                var value = GetValue(param1);
                var register = GetRegister(param2);

                Registers[register] = value;
                
                currentIndex++;
            }
            else
            {
                currentIndex++;
            }
        }
    }

    private int GetRegisterValue(char register)
    {
        return Registers[register];
    }

    private void IncrementRegister(char register)
    {
        Registers[register]++;
    }

    private void DecrementRegister(char register)
    {
        Registers[register]--;
    }

    private char GetRegister(string parameter)
    {
        return parameter[0];
    }

    private int GetValue(string parameter)
    {
        if (char.IsLetter(parameter[0]))
        {
            return GetRegisterValue(parameter[0]);
        }
        return int.Parse(parameter);
    }
}
