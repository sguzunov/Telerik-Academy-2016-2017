/* Write a program that calculates N! / K! for given N and K. */

using System;
using System.Numerics;

class CalculateAgain
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        BigInteger factorialN = 1;
        BigInteger factorialK = 1;

        for (uint i = 1; i <= n; i++)
        {
            factorialN *= i;
            if (i <= k)
            {
                factorialK *= i;
            }
        }

        Console.WriteLine(factorialN / factorialK);
    }
}
