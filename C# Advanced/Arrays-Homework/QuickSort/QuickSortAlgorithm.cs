// Write a program that sorts an array of integers using the Quick sort algorithm.

using System;

class QuickSortAlgorithm
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[] numbers = new int[n];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        QuickSort(numbers, 0, numbers.Length - 1);
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(numbers[i]);
        }
    }

    private static void QuickSort(int[] numbers, int left, int right)
    {
        if (left < right)
        {
            int pivot = Partition(numbers, left, right);
            QuickSort(numbers, 0, pivot - 1);
            QuickSort(numbers, pivot + 1, right);
        }
    }

    private static int Partition(int[] numbers, int left, int right)
    {
        int q = 0;
        int pivotIndex = right;
        int pivot = numbers[pivotIndex];
        while (q < pivotIndex)
        {
            int currentNumber = numbers[q];
            if (currentNumber > pivot)
            {
                numbers[q] = numbers[pivotIndex - 1];
                numbers[pivotIndex - 1] = pivot;
                numbers[pivotIndex] = currentNumber;
                pivotIndex--;
                pivot = numbers[pivotIndex];
            }
            else
            {
                q++;
            }
        }

        return q;
    }
}
