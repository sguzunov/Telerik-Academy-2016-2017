// Write a program that reads from the console a sequence of positive integer numbers.
// The sequence ends when empty line is entered.
// Calculate and print the sum and average of the elements of the sequence.
// Keep the sequence in List<int>.

using System;
using System.Collections.Generic;

namespace Numbers
{
    public class Startup
    {
        public static void Main()
        {
            var numbers = ReadNumbers();

            long sum = 0;
            foreach (var number in numbers)
            {
                sum += number;
            }

            Console.WriteLine($"Sum: {sum}");

            double average = (double)sum / numbers.Count;

            Console.WriteLine($"Avg: {average}");
        }

        private static IList<int> ReadNumbers()
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
