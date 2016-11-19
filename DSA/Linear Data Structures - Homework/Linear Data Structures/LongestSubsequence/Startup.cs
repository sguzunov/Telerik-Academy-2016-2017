// Write a method that finds the longest subsequence of equal numbers in given List and returns the result as new List<int>.

using System;
using System.Collections.Generic;

namespace LongestSubsequence
{
    public class Startup
    {
        public static void Main()
        {
            var numbers = ReadNumbers();

            var longestSubseqOfEqualNumebrs = FindLongestSubsequenceOfEqualNumbers(numbers);
            Console.WriteLine(string.Join(" ", longestSubseqOfEqualNumebrs));
        }

        private static IList<int> ReadNumbers()
        {
            var numbersAsString = Console.ReadLine().Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var numbers = new List<int>();
            foreach (var numString in numbersAsString)
            {
                int number = int.Parse(numString);
                numbers.Add(number);
            }

            return numbers;
        }

        private static IEnumerable<int> FindLongestSubsequenceOfEqualNumbers(IList<int> numbers)
        {
            int currentSubsequnce = 1;
            int bestSubsequnce = 1;
            int endIndex = 1;
            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] == numbers[i - 1])
                {
                    currentSubsequnce++;
                }
                else
                {
                    if (currentSubsequnce > bestSubsequnce)
                    {
                        bestSubsequnce = currentSubsequnce;
                        endIndex = i;
                    }

                    currentSubsequnce = 1;
                }
            }

            if (currentSubsequnce > bestSubsequnce)
            {
                bestSubsequnce = currentSubsequnce;
                endIndex = numbers.Count;
            }

            var subsequence = new List<int>();
            for (int i = endIndex - 1; i >= endIndex - bestSubsequnce; i--)
            {
                subsequence.Add(numbers[i]);
            }

            return subsequence;
        }
    }
}
