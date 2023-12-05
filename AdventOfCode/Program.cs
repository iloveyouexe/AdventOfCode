using System;

namespace AdventOfCode
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Choose a day to run:");
            Console.WriteLine("1. Day One");
            //Console.WriteLine("2. Day Two");
            // Add more options for other days

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    // Call DayOne logic here
                    break;
                case 2:
                    // Call DayTwo logic here
                    break;
                // Add cases for other days
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}
