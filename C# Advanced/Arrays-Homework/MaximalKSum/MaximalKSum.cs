// Write a program that reads two integer numbers N and K and an array of N elements from the console. Find the maximal sum of K elements in the array.

using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        int[] numbers = new int[n];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        Array.Sort(numbers);
        int bestSum = 0;
        for (int i = numbers.Length - 1; i >= numbers.Length - k; i--)
        {
            bestSum += numbers[i];
        }

        Console.WriteLine(bestSum);
    }
}
