//* The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times.
// Write a program to find the majorant of given array(if exists)
// {2, 2, 3, 3, 2, 3, 4, 3, 3} → 3

using System;
using System.Linq;

namespace MajorantOfAnArray
{
    public class Startup
    {
        public static void Main()
        {
            var numbers = ReadNumbers();

            FindMajorant(numbers);
        }

        private static void FindMajorant(int[] numbers)
        {
            Array.Sort(numbers);

            int start = 0;
            int number = numbers[0];
            int majorantTimes = (numbers.Length / 2) + 1;
            for (int i = 1; i < numbers.Length; i++)
            {
                if (number != numbers[i])
                {
                    int times = i - start;
                    if (times >= majorantTimes)
                    {
                        Console.WriteLine(number);
                    }

                    number = numbers[i];
                    start = i;
                }
            }
        }

        private static int[] ReadNumbers()
        {
            var numbers = Console.ReadLine().Trim()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            return numbers;
        }
    }
}
