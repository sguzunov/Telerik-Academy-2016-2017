// Write a program that reads two integer arrays of size N from the console and compares them element by element.

using System;

class CompareArrays
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[] firstArray = new int[n];
        for (int i = 0; i < n; i++)
        {
            int number = int.Parse(Console.ReadLine());
            firstArray[i] = number;
        }

        int[] secondArray = new int[n];
        for (int i = 0; i < n; i++)
        {
            int number = int.Parse(Console.ReadLine());
            secondArray[i] = number;
        }

        bool areEqual = true;
        for (int i = 0; i < n; i++)
        {
            if (firstArray[i] != secondArray[i])
            {
                areEqual = false;
                break;
            }
        }

        Console.WriteLine(areEqual ? "Equal" : "Not equal");
    }
}
