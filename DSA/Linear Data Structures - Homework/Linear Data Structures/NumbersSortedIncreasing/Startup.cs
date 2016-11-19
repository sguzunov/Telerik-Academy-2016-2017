// Write a program that reads a sequence of integers(List<int>) ending with an empty line and sorts them in an increasing order.

using System;
using System.Collections.Generic;

namespace NumbersSortedIncreasing
{
    public class Startup
    {
        public static void Main()
        {
            var numbers = ReadNumbers();

            numbers.Sort((a, b) => a - b);
            Console.WriteLine($"Numbers sorted in increasing order: {string.Join(", ", numbers)}");
        }

        private static List<int> ReadNumbers()
        {
            string line = Console.ReadLine();
            var numbers = new List<int>();
            while (line != "")
            {
                int number;
                if (!int.TryParse(line, out number))
                {
                    Console.WriteLine("Enter positive integer numbers!");
                    break;
                }

                numbers.Add(number);

                line = Console.ReadLine();
            }

            return numbers;
        }
    }
}
