// Write a method that adds two positive integer numbers represented as arrays of digits (each array element arr[i] contains a digit; the last digit is kept in arr[0]). 
// Write a program that reads two arrays representing positive integers and outputs their sum.

using System;
using System.Collections.Generic;
using System.Linq;

class NumberAsArray
{
    private static IEnumerable<int> SumArraysOfNumbers(int[] firstNumber, int[] secondNumber)
    {
        int maxLenght = Math.Max(firstNumber.Length, secondNumber.Length);
        int minLenght = Math.Min(firstNumber.Length, secondNumber.Length);
        List<int> summedArrays = new List<int>();
        int saved = 0;
        int sum = 0;
        for (int i = 0; i < minLenght; i++)
        {
            sum = firstNumber[i] + secondNumber[i] + saved;
            summedArrays.Add(sum % 10);
            saved = sum / 10;
        }

        int[] longestNumber = firstNumber.Length > secondNumber.Length ? firstNumber : secondNumber;
        if (maxLenght != minLenght)
        {
            for (int i = minLenght; i < maxLenght; i++)
            {
                sum = longestNumber[i] + saved;
                summedArrays.Add(sum % 10);
                saved = sum / 10;
            }
        }
        else
        {
            if (saved != 0)
            {
                summedArrays.Add(saved);
            }
        }

        return summedArrays;
    }

    static void Main()
    {
        int[] lenghtsOfNumbers = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

        int[] firstNumber = new int[lenghtsOfNumbers[0]];
        firstNumber = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

        int[] secondNumber = new int[lenghtsOfNumbers[1]];
        secondNumber = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

        IEnumerable<int> sumedArraies = SumArraysOfNumbers(firstNumber, secondNumber);
        Console.WriteLine(string.Join(" ", sumedArraies));
    }
}
