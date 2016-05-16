// Write a method that returns the index of the first element in array that is larger than its neighbours, or -1, if there is no such element.

using System;
using System.Linq;

class FirstLargerThanNeighbours
{
    private static int GetIndexOfFirstNumberLargerThanNeighbours(int[] numbers)
    {
        for (int i = 1; i < numbers.Length - 1; i++)
        {
            int currentNumber = numbers[i];
            int prevNumber = numbers[i - 1];
            int nextNumber = numbers[i + 1];
            if (currentNumber >= prevNumber && currentNumber >= nextNumber)
            {
                return i;
            }
        }

        return -1;
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[] numbers = new int[n];
        numbers = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

        int indexOfLargerThanNeighbours = GetIndexOfFirstNumberLargerThanNeighbours(numbers);
        Console.WriteLine(indexOfLargerThanNeighbours);
    }
}
