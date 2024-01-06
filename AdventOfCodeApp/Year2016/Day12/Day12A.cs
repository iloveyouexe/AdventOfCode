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
    public int A { get; private set; }
    public int B { get; private set; }
    public int C { get; private set; }
    public int D { get; private set; }

    public void Execute(string[] opCodes)
    {
        int currentIndex = 0;

        while (currentIndex < opCodes.Length)
        {
            string opCode = opCodes[currentIndex];
            string[] parts = opCode.Split(' ');

            string command = parts[0];
            char register = parts[1][0]; // Assuming the register is always a single character
            int value = 0;

            if (parts.Length > 2)
            {
                // Try parsing the third part as a number
                int.TryParse(parts[2], out value);
            }

            if (command == "jnz")
            {
                int jumpValue = (register >= 'a' && register <= 'd') ? GetRegisterValue(register) : value;
                if (jumpValue != 0)
                {
                    // Perform the jump
                    currentIndex += value;
                }
                else
                {
                    // If jump condition is not met, move to the next instruction
                    currentIndex++;
                }
            }
            else if (command == "inc")
            {
                // Handle the increment command
                IncrementRegister(register);
                currentIndex++;
            }
            else if (command == "dec")
            {
                // Handle the decrement command
                DecrementRegister(register);
                currentIndex++;
            }
            // Increment the index if not a jump command
            else
            {
                currentIndex++;
            }
        }
    }

    private int GetRegisterValue(char register)
    {
        switch (register)
        {
            case 'a':
                return A;
            case 'b':
                return B;
            case 'c':
                return C;
            case 'd':
                return D;
            default:
                return 0; // If an invalid register is passed
        }
    }

    private void IncrementRegister(char register)
    {
        switch (register)
        {
            case 'a':
                A++;
                break;
            case 'b':
                B++;
                break;
            case 'c':
                C++;
                break;
            case 'd':
                D++;
                break;
        }
    }

    private void DecrementRegister(char register)
    {
        switch (register)
        {
            case 'a':
                A--;
                break;
            case 'b':
                B--;
                break;
            case 'c':
                C--;
                break;
            case 'd':
                D--;
                break;
        }
    }
}
