// Write a method that multiplies a number represented as an array of digits by a given integer number. Write a program to calculate N!.

using System;
using System.Numerics;

class NFactorial
{
    private static BigInteger Factorial(int n)
    {
        BigInteger nFactorial = new BigInteger();
        nFactorial = 1;
        for (int i = 2; i <= n; i++)
        {
            nFactorial *= i;
        }

        return nFactorial;
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine(Factorial(n));
    }
}
