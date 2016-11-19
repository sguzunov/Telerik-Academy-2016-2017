// Write a program that finds in given array of integers(all belonging to the range[0..1000]) how many times each of them occurs.

using System;
using System.Linq;

namespace Occurances
{
    public class Startup
    {
        public static void Main()
        {
            var numbers = ReadNumbers();

            Array.Sort(numbers);

            int start = 0;
            int number = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (number != numbers[i])
                {
                    Console.WriteLine($"{number} -> {i - start} times");
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
