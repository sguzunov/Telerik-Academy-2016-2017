/*
    Write a method ReadNumber(int start, int end) that enters an integer number in a given range ( start, end ).
    If an invalid number or non-number text is entered, the method should throw an exception. 
    Using this method write a program that enters 10 numbers: a1, a2, ..., a10, such that 1 < a1 < ... < a10 < 100
 */

using System;
using System.Collections.Generic;

class Program
{
    private static List<int> ReadNumbers(int from, int to)
    {
        List<int> numbers = new List<int>();
        numbers.Add(from);
        for (int i = 0; i < 10; i++)
        {
            int number = int.Parse(Console.ReadLine());
            int prevNumber = numbers[numbers.Count - 1];
            if (number <= prevNumber || number >= to)
            {
                throw new ArgumentOutOfRangeException();
            }

            numbers.Add(number);
        }

        numbers.Add(to);
        return numbers;
    }

    static void Main()
    {
        const string ExcptionMessage = "Exception";

        try
        {
            var numbers = ReadNumbers(1, 100);
            Console.WriteLine(string.Join(" < ", numbers));
        }
        catch (FormatException)
        {
            Console.WriteLine(ExcptionMessage);
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine(ExcptionMessage);
        }
    }
}
