// Write a program that removes from given sequence all negative numbers.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemovingNegativeNumbers
{
    public class Startup
    {
        public static void Main()
        {
            var numbers = ReadNumbers();

            RemoveNegativeNumbers(numbers);

            Console.WriteLine($"Left numbers: {string.Join(", ", numbers)}");
        }

        private static void RemoveNegativeNumbers(IList<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                int number = numbers[i];
                if (number < 0)
                {
                    numbers.RemoveAt(i);
                    --i;
                }
            }
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
                    Console.WriteLine("Enter integer numbers!");
                    break;
                }

                numbers.Add(number);

                line = Console.ReadLine();
            }

            return numbers;
        }
    }
}
