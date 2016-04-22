/* Write a program that calculates the greatest common divisor (GCD) of given two integers A and B. */

using System;

class GCD
{
    static void Main()
    {
        string[] numbersAsString = Console.ReadLine().Split(' ');

        int a = Math.Abs(int.Parse(numbersAsString[0]));
        int b = Math.Abs(int.Parse(numbersAsString[1]));
        while (b > 0)
        {
            int swap = b;
            b = a % b;
            a = swap;
        }

        Console.WriteLine(a);
    }
}
