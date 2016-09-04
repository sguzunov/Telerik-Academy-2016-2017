namespace RefactoringLoop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var numbers = ReadNumbers();

            Console.Write("Enter expected number: ");
            int expectedNumber = int.Parse(Console.ReadLine());

            Console.WriteLine();

            bool found = false;
            for (int i = 0; i < numbers.Count; i++)
            {
                Console.WriteLine(numbers[i]);
                if (i % 10 == 0 && numbers[i] == expectedNumber)
                {
                    found = true;
                    break;
                }
            }

            if (found)
            {
                Console.WriteLine("Expected value is found!");
            }
        }

        private static IList<int> ReadNumbers()
        {
            Console.Write("Enter integer numbers separate by space:");
            string input = Console.ReadLine();
            var numbers = new List<int>();
            try
            {
                numbers = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            }
            catch (Exception)
            {
                Console.WriteLine("Ivalid input of numbers!");
            }

            return numbers;
        }
    }
}
