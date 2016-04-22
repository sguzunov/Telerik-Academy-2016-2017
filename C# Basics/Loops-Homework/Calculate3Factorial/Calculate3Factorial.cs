/* In combinatorics, the number of ways to choose N different members out of a group of N different elements (also known as the number of combinations) is calculated by the following formula: formula For example, there are 2598960 ways to withdraw 5 cards out of a standard deck of 52 cards. Your task is to write a program that calculates N! / (K! * (N - K)!) for given N and K. */

using System;
using System.Numerics;

class Calculate3Factorial
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        int difference = n - k;
        BigInteger factorialOfDifference = 1;
        BigInteger factorialN = 1;
        BigInteger factorialK = 1;
        for (int i = 1; i <= n; i++)
        {
            factorialN *= i;
            if (i <= k)
            {
                factorialK *= i;
            }

            if (i <= difference)
            {
                factorialOfDifference *= i;
            }
        }

        BigInteger combinations = factorialN / (factorialK * (factorialOfDifference));
        Console.WriteLine(combinations);
    }
}
