// Write a method that adds two positive integer numbers represented as arrays of digits (each array element arr[i] contains a digit; the last digit is kept in arr[0]). 
// Write a program that reads two arrays representing positive integers and outputs their sum.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

class Program
{
    private static IEnumerable<int> SumArraiesOfNumbers(int[] firstNumber, int[] secondNumber)
    {
        int maxLenght = Math.Max(firstNumber.Length, secondNumber.Length);
        int minLenght = Math.Min(firstNumber.Length, secondNumber.Length);

        List<int> result = new List<int>();
        int remainder = 0;
        for (int i = 0; i < minLenght; i++)
        {
            int sum = firstNumber[i] + secondNumber[i] + remainder;
            result.Add(sum % 10);
            remainder = sum / 10;
        }

        int[] longestArray = firstNumber.Length > secondNumber.Length ? firstNumber : secondNumber;
        if (maxLenght != minLenght)
        {
            longestArray[minLenght] = longestArray[minLenght] + remainder;
            result.Add(longestArray[minLenght]);
            for (int i = minLenght + 1; i < maxLenght; i++)
            {
                result.Add(longestArray[i]);
            }
        }
        else
        {
            if (remainder != 0)
            {
                result.Add(remainder);
            }
        }

        return result;
    }

    static void Main()
    {
        int[] lenghtsOfNumbers = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

        int[] firstNumberAsArray = new int[lenghtsOfNumbers[0]];
        firstNumberAsArray = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

        int[] secondNumberAsArray = new int[lenghtsOfNumbers[1]];
        secondNumberAsArray = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

        IEnumerable<int> sumedArraies = SumArraiesOfNumbers(firstNumberAsArray, secondNumberAsArray);
        Console.WriteLine(string.Join(" ", sumedArraies));

        //BigInteger firstNumber = ConvertArrayToNumber(firstNumberAsArray);
        //BigInteger secondNumber = ConvertArrayToNumber(secondNumberAsArray);
        //BigInteger sum = firstNumber + secondNumber;
        //char[] reversedSum = ReverseNumbersDigits(sum);

        //Console.WriteLine(string.Join(" ", sum.ToString().ToArray().Reverse()));
    }
}
