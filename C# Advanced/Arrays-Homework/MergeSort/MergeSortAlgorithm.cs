// Write a program that sorts an array of integers using the Merge sort algorithm.

using System;

class MergeSortAlgorithm
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[] numbers = new int[n];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        MergeSort(numbers, 0, n - 1);
        PrintArray(numbers);
    }

    // Top-down merge sort.
    private static void MergeSort(int[] numbers, int startIndex, int endIndex)
    {
        if ((endIndex - startIndex) < 1)
        {
            return;
        }

        int midIndex = (startIndex + endIndex) / 2;

        // Left past.
        MergeSort(numbers, startIndex, midIndex);

        // Right part.
        MergeSort(numbers, midIndex + 1, endIndex);

        // Merge two halfs.
        Merge(numbers, startIndex, midIndex, endIndex);
    }

    private static void Merge(int[] numbers, int startIndex, int midIndex, int endIndex)
    {
        int leftIndex = startIndex;
        int leftEnd = midIndex;
        int rightIndex = midIndex + 1;
        int rightEnd = endIndex;
        int position = startIndex;
        int[] merged = new int[numbers.Length];

        while (leftIndex <= leftEnd && rightIndex <= rightEnd)
        {
            if (numbers[leftIndex] <= numbers[rightIndex])
            {
                merged[position] = numbers[leftIndex];
                leftIndex++;
            }
            else
            {
                merged[position] = numbers[rightIndex];
                rightIndex++;
            }

            position++;
        }

        while (leftIndex <= leftEnd)
        {
            merged[position] = numbers[leftIndex];
            leftIndex++;
            position++;
        }

        while (rightIndex <= rightEnd)
        {
            merged[position] = numbers[rightIndex];
            rightIndex++;
            position++;
        }

        for (int i = startIndex; i <= endIndex; i++)
        {
            numbers[i] = merged[i];
        }
    }

    private static void PrintArray(int[] elements)
    {
        for (int i = 0; i < elements.Length; i++)
        {
            Console.WriteLine(elements[i]);
        }
    }
}
