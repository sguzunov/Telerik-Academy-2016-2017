// Write a program that finds the maximal sum of consecutive elements in a given array of N numbers.

using System;

class MaximalSum
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[] numbers = new int[n];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        int maxSum = int.MinValue;
        int currentSum = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            currentSum += numbers[i];
            if (currentSum > maxSum)
            {
                maxSum = currentSum;
            }
            else
            {
                if (currentSum < 0)
                {
                    currentSum = 0;
                }
            }
        }

        Console.WriteLine(maxSum);
    }
}
