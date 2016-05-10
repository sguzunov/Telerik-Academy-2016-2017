// Write a program that finds all prime numbers in the range[1...N]. 
// Use the Sieve of Eratosthenes algorithm.The program should print the biggest prime number which is <= N.

using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        bool[] sieve = new bool[n + 1];
        int i = 2;
        while (i <= n)
        {
            if (sieve[i] == false)
            {
                int j = i + i;
                while (j <= n)
                {
                    sieve[j] = true;
                    j += i;
                }
            }

            i++;
        }

        for (int j = sieve.Length - 1; j >= 0; j--)
        {
            if (sieve[j] == false)
            {
                Console.WriteLine(j);
                break;
            }
        }
    }
}
