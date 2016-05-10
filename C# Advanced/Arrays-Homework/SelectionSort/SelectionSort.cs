// Sorting an array means to arrange its elements in increasing order. Write a program to sort an array. Use the Selection sort algorithm: Find the smallest element, move it at the first position, find the smallest from the rest, move it at the second position, etc.

using System;

class SelectionSort
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[] numbers = new int[n];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        // Sorting numbers with Selection sort.
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < numbers.Length; j++)
            {
                if (numbers[minIndex] > numbers[j])
                {
                    minIndex = j;
                }
            }

            if (minIndex != i)
            {
                numbers[i] ^= numbers[minIndex];
                numbers[minIndex] = numbers[i] ^ numbers[minIndex];
                numbers[i] = numbers[i] ^ numbers[minIndex];
            }
        }

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(numbers[i]);
        }
    }
}
