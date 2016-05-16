// Write a method that returns the maximal element in a portion of array of integers starting at given index.
// Using it write another method that sorts an array in ascending / descending order. Write a program that sorts a given array.

using System;
using System.Linq;

class SortingArray
{
    private static int GetMaxElementIndex(int[] numbers, int from, int to)
    {
        if (from < 0 || from >= numbers.Length || to < from || to >= numbers.Length)
        {
            throw new IndexOutOfRangeException("Start index must be in the range of the count of elements!");
        }

        int maxElementIndex = from;
        for (int i = from + 1; i <= to; i++)
        {
            if (numbers[maxElementIndex] < numbers[i])
            {
                maxElementIndex = i;
            }
        }

        return maxElementIndex;
    }

    private static void SortArray(int[] elements, Func<int[], int, int, int> getMax, bool sortAscending = true)
    {
        int maxElementIndex = 0;
        for (int i = 0; i < elements.Length; i++)
        {
            int currentIndex;
            if (sortAscending)
            {
                currentIndex = elements.Length - 1 - i;
                maxElementIndex = getMax(elements, 0, currentIndex);
            }
            else
            {
                currentIndex = i;
                maxElementIndex = getMax(elements, i, elements.Length - 1);
            }

            if (maxElementIndex != currentIndex)
            {
                SwapNumbers(elements, maxElementIndex, currentIndex);
            }
        }
    }

    private static void SwapNumbers(int[] elements, int firstNumberIndex, int secondNumberIndex)
    {
        elements[firstNumberIndex] = elements[firstNumberIndex] ^ elements[secondNumberIndex];
        elements[secondNumberIndex] = elements[firstNumberIndex] ^ elements[secondNumberIndex];
        elements[firstNumberIndex] = elements[firstNumberIndex] ^ elements[secondNumberIndex];
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[] numbers = new int[n];
        numbers = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

        SortArray(numbers, GetMaxElementIndex, true);
        Console.WriteLine(string.Join(" ", numbers));
    }
}
