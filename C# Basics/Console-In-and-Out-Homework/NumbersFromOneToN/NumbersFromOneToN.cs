using System;

/* Write a program that reads an integer number N from the console and prints all the numbers in the interval [1, n], each on a single line. */
class NumbersFromOneToN
{
    static void Main()
    {
        short n = short.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine(i);
        }
    }
}

