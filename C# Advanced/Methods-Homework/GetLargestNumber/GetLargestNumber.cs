// Write a method GetMax() with two parameters that returns the larger of two integers. 
// Write a program that reads 3 integers from the console and prints the largest of them using the method GetMax().

using System;
using System.Linq;

class GetLargestNumber
{
    private static int GetMax(int firstNumber, int secondNumber)
    {
        if (firstNumber > secondNumber)
        {
            return firstNumber;
        }

        return secondNumber;
    }

    private static int GetMax(int firstNumber, int secondNumber, Func<int, int, int> compare)
    {
        int max = compare(firstNumber, secondNumber);
        return max;
    }

    static void Main()
    {
        int[] numbers = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

        int maxNumber = GetMax(numbers[0], numbers[1]);
        maxNumber = GetMax(maxNumber, numbers[2]);
        Console.WriteLine(maxNumber);

        //Func<int, int, int> comparer = (x, y) => x > y ? x : y;
        //maxNumber = GetMax(1, 2, comparer);
        //Console.WriteLine(maxNumber);
    }
}
