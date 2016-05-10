// Write a program that compares two char arrays lexicographically (letter by letter).

using System;

class Program
{
    static void Main()
    {
        char[] firstArray = Console.ReadLine().ToCharArray();
        char[] secondArray = Console.ReadLine().ToCharArray();

        char sign = '=';
        int length = Math.Min(firstArray.Length, secondArray.Length);
        for (int i = 0; i < length; i++)
        {
            if (firstArray[i] > secondArray[i])
            {
                sign = '>';
                break;
            }

            if (secondArray[i] > firstArray[i])
            {
                sign = '<';
                break;
            }
        }

        if ((sign == '=') && secondArray.Length > firstArray.Length)
        {
            sign = '<';
        }

        if ((sign == '=') && firstArray.Length > secondArray.Length)
        {
            sign = '>';
        }

        Console.WriteLine(sign);
    }
}
