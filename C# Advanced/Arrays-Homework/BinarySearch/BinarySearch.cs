// Write a program that finds the index of given element X in a sorted array of N integers by using the Binary search algorithm.

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

        int searchedNumber = int.Parse(Console.ReadLine());

        int leftIndex = 0;
        int rightIndex = numbers.Length - 1;
        int foundOnIndex = -1;
        while (leftIndex <= rightIndex)
        {
            int midIndex = (rightIndex + leftIndex) / 2;
            if (searchedNumber > numbers[midIndex])
            {
                leftIndex = midIndex + 1;
            }
            else if (searchedNumber < numbers[midIndex])
            {
                rightIndex = midIndex - 1;
            }
            else
            {
                foundOnIndex = midIndex;
                break;
            }
        }

        Console.WriteLine(foundOnIndex);
    }
}
