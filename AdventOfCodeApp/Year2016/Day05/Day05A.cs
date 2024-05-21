using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode.Year2016.Day05;

public class Day05A : IAdventOfCodeProblem
{
    public string Solve(string[] doorIdArray)
    {
        string doorId = doorIdArray[0];
        string password = "";
        int index = 0;

        using (MD5 md5 = MD5.Create())
        {
            while (password.Length < 8)
            {
                string input = doorId + index.ToString();
                byte[] hashBytes = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
                
                if (hashBytes[0] == 0 && hashBytes[1] == 0 && (hashBytes[2] & 0xF0) == 0)
                {
                    password += hashBytes[2].ToString("x1");
                }
                
                index++;
            }
        }
        return password;
    }
}