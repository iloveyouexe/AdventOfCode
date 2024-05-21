using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode.Year2016.Day05
{
    public class Day05B : IAdventOfCodeProblem
    {
        public string Solve(string[] doorIdArray)
        {
            string doorId = doorIdArray[0];
            char[] password = new char[8];
            int filledPositions = 0;
            int index = 0;

            using (MD5 md5 = MD5.Create())
            {
                while (filledPositions < 8)
                {
                    string input = doorId + index.ToString();
                    byte[] hashBytes = md5.ComputeHash(Encoding.ASCII.GetBytes(input));

                    if (hashBytes[0] == 0 && hashBytes[1] == 0 && (hashBytes[2] & 0xF0) == 0)
                    {
                        int position = hashBytes[2] & 0x0F;
                        if (position < 8 && password[position] == '\0') // \0 = C# null 
                        {
                            password[position] = hashBytes[3].ToString("x2")[0];
                            filledPositions++;
                        }
                    }
                    index++;
                }
            }
            return new string(password);
        }
    }
}