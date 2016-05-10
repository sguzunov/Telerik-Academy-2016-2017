// Write a program that finds in given array of integers a sequence of given sum S (if present).

using System;
using System.Linq;

class FindSumInArray
{
    static void Main()
    {
        string[] numbersAsString = Console.ReadLine().Split(new char[] { ',' });
        int sum = int.Parse(Console.ReadLine());

        int[] numbers = new int[numbersAsString.Length];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(numbersAsString[i]);
        }

        int currentSum = int.MinValue;
        int startIndex = 0;
        int endIndex = 0;
        bool isFound = false;
        for (int i = 0; i < numbersAsString.Length - 1; i++)
        {
            currentSum = numbers[i];
            startIndex = i;
            for (int j = i + 1; j < numbers.Length; j++)
            {
                endIndex = j;
                currentSum += numbers[j];
                if (currentSum == sum)
                {
                    isFound = true;
                    break;
                }
            }

            if (isFound)
            {
                break;
            }
        }

        if (isFound)
        {
            for (int i = startIndex; i <= endIndex; i++)
            {
                Console.Write("{0} ", numbers[i]);
            }
        }
        else
        {
            Console.WriteLine("Sum {0} is not found!", sum);
        }
    }
}
