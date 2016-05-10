// Write a program that finds the length of the maximal increasing sequence in an array of N integers.

using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[] numbers = new int[n];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        int bestLength = 0;
        int currentLength = 1;
        bool areIncreasing = true;
        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] > numbers[i - 1])
            {
                currentLength++;
                areIncreasing = true;
            }
            else
            {
                areIncreasing = false;
            }

            if (currentLength > bestLength)
            {
                bestLength = currentLength;
            }

            if (!areIncreasing)
            {
                currentLength = 1;
            }
        }

        Console.WriteLine(bestLength);
    }
}
