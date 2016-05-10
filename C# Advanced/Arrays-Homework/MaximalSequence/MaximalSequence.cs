// Write a program that finds the length of the maximal sequence of equal elements in an array of N integers.

using System;

class MaximalSequence
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[] numbers = new int[n];
        for (int i = 0; i < n; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        int bestLength = 0;
        int currentLength = 1;
        bool areEqual = false;
        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] == numbers[i - 1])
            {
                currentLength++;
                areEqual = true;
            }
            else
            {
                areEqual = false;
            }

            if (currentLength > bestLength)
            {
                bestLength = currentLength;
            }

            if (!areEqual)
            {
                currentLength = 1;
            }
        }

        Console.WriteLine(bestLength);
    }
}
