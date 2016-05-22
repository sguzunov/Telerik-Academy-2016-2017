/*
     You are given a sequence of positive integer values written into a string, separated by spaces. Write a function that reads these values from given string and calculates their sum. Write a program that reads a string of positive integers separated by spaces and prints their sum.
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

class SumIntegers
{
    private static List<string> SplitStringBy(string str, char separator)
    {
        str.Trim();
        var splitedString = new List<string>();
        StringBuilder subStr = new StringBuilder();
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] != separator)
            {
                subStr.Append(str[i]);
            }
            else
            {
                splitedString.Add(subStr.ToString());
                subStr.Clear();
            }

            if (i == str.Length - 1)
            {
                splitedString.Add(subStr.ToString());
            }
        }

        return splitedString;
    }

    private static int SumNumbers(IEnumerable<int> numbers)
    {
        int sum = 0;
        foreach (var number in numbers)
        {
            sum += number;
        }

        return sum;
    }

    static void Main()
    {
        string input = Console.ReadLine();

        var numbers = SplitStringBy(input, ' ').Select(x => int.Parse(x));
        int sum = SumNumbers(numbers);
        Console.WriteLine(sum);
    }
}
