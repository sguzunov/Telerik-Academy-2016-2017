// Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers. Use variable number of arguments. 
// Write a program that reads 5 elements and prints their minimum, maximum, average, sum and product.

using System;
using System.Linq;

class Program
{
    private static T GetMax<T>(params T[] numbers) where T : IComparable<T>
    {
        T max = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            if (max.CompareTo(numbers[i]) < 0)
            {
                max = numbers[i];
            }
        }

        return max;
    }

    private static T GetMin<T>(params T[] numbers) where T : IComparable<T>
    {
        T min = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            if (min.CompareTo(numbers[i]) > 0)
            {
                min = numbers[i];
            }
        }

        return min;
    }

    private static T SumNumbers<T>(params T[] numbers)
    {
        dynamic sum = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }

        return sum;
    }

    private static T MultiplyNumbers<T>(params T[] numbers)
    {
        dynamic product = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            product *= numbers[i];
        }

        return product;
    }

    private static double GetAverageOfnumbers<T>(params T[] numbers)
    {
        dynamic count = numbers.Length;
        T numbersSum = SumNumbers(numbers);
        double avr = numbersSum / count;
        return avr;
    }

    static void Main()
    {
        var numbers = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

        Console.WriteLine(GetMin(numbers));
        Console.WriteLine(GetMax(numbers));
        Console.WriteLine("{0:F2}", GetAverageOfnumbers(numbers));
        Console.WriteLine(SumNumbers(numbers));
        Console.WriteLine(MultiplyNumbers(numbers));
    }
}
