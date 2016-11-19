// Write a program that removes from given sequence all numbers that occur odd number of times.

using System;
using System.Collections.Generic;

namespace NumbersOddTimesOccuring
{
    public class Startup
    {
        public static void Main()
        {
            var numbers = ReadNumbers();

            var numbersOddNumberOfTimes = GetAllNumbersOccuringOddNumberOfTimes(numbers);
            foreach (var num in numbersOddNumberOfTimes)
            {
                while (numbers.Contains(num))
                {
                    numbers.Remove(num);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static IEnumerable<int> GetAllNumbersOccuringOddNumberOfTimes(IList<int> numbers)
        {
            var numbersOccuringOddTimes = new HashSet<int>();
            for (int i = 0; i < numbers.Count; ++i)
            {
                int checkedNumber = numbers[i];
                if (!numbersOccuringOddTimes.Contains(checkedNumber))
                {
                    int occurances = 1;
                    for (int j = 0; j < numbers.Count; ++j)
                    {
                        if (numbers[j] == checkedNumber && i != j)
                        {
                            occurances++;
                        }
                    }

                    if (occurances % 2 != 0)
                    {
                        numbersOccuringOddTimes.Add(checkedNumber);
                    }
                }
            }

            return numbersOccuringOddTimes;
        }

        private static IList<int> ReadNumbers()
        {
            var numbersAsString = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var numbers = new List<int>();
            foreach (var numString in numbersAsString)
            {
                int number = int.Parse(numString);
                numbers.Add(number);
            }

            return numbers;
        }
    }
}
