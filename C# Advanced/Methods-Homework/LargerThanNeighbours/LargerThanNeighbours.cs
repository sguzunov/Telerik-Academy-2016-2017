// Write a method that checks if the element at given position in given array of integers is larger than its two neighbours (when such exist). 
// Write program that reads an array of numbers and prints how many of them are larger than their neighbours.

using System;
using System.Linq;

class LargerThanNeighbours
{
    private static int CountNumbersLargerThanNeighbours(int[] numbers)
    {
        int count = 0;
        for (int i = 1; i < numbers.Length - 1; i++)
        {
            int currentNumber = numbers[i];
            int prevNumber = numbers[i - 1];
            int nextNumber = numbers[i + 1];
            if (currentNumber >= prevNumber && currentNumber >= nextNumber)
            {
                count++;
            }
        }

        return count;
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[] numbers = new int[n];
        numbers = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

        int count = CountNumbersLargerThanNeighbours(numbers);
        Console.WriteLine(count);
    }
}
