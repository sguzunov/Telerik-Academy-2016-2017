// Write a program that reads three integer numbers N, K and S and an array of N elements from the console.
// Find in the array a subset of K elements that have sum S or indicate about its absence.

using System;

class SubsetKWithSumS
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        int sum = int.Parse(Console.ReadLine());

        int[] numbers = new int[n];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        bool hasSum = HasSum(0, 0, 0, sum, k, numbers);
        Console.WriteLine(hasSum);
    }

    private static bool HasSum(int index, int subsetLength, int currentSum, int sum, int k, int[] numbers)
    {
        subsetLength++;
        bool hasSum = false;
        currentSum += numbers[index];
        if ((currentSum == sum) && (subsetLength == k))
        {
            hasSum = true;
        }
        else
        {
            for (int i = index + 1; i < numbers.Length; i++)
            {
                hasSum = HasSum(i, subsetLength, currentSum, sum, k, numbers);
                if (!hasSum)
                {
                    hasSum = HasSum(i, 0, 0, sum, k, numbers);
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
