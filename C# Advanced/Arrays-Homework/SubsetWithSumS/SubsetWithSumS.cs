// We are given an array of integers and a number S. Write a program to find if there exists a subset of the elements of the array that has a sum S.

using System;

class SubsetWithSumS
{
    static void Main()
    {
        string[] numbersAsString = Console.ReadLine().Trim().Split(',');
        int sum = int.Parse(Console.ReadLine());

        int[] numbers = new int[numbersAsString.Length];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(numbersAsString[i]);
        }

        bool hasSum = HasSum(0, 0, 0, sum, numbers);
        Console.WriteLine(hasSum);
    }

    private static bool HasSum(int index, int subsetLength, int currentSum, int sum, int[] numbers)
    {
        subsetLength++;
        bool hasSum = false;
        currentSum += numbers[index];
        if ((currentSum == sum) && (subsetLength > 1))
        {
            hasSum = true;
        }
        else
        {
            for (int i = index + 1; i < numbers.Length; i++)
            {
                hasSum = HasSum(i, subsetLength, currentSum, sum, numbers);
                if (!hasSum)
                {
                    hasSum = HasSum(i, 0, 0, sum, numbers);
                }
                else
                {
                    break;
                }
            }
        }

        return hasSum;
    }
}
