/*  You are given N integers (given in a single line, separated by a space).
    Write a program that checks whether the product of the odd elements is equal to the product of the even elements.
    Elements are counted from 1 to N, so the first element is odd, the second is even, etc. */

using System;

class OddAndEvenProduct
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] numberAsString = Console.ReadLine().Split(' ');

        long productOfOddsPositions = 1;
        long productOfEvensPositions = 1;
        for (int i = 0; i < n; i++)
        {
            int number = int.Parse(numberAsString[i]);
            if ((i + 1) % 2 == 0)
            {
                productOfEvensPositions *= number;
            }
            else
            {
                productOfOddsPositions *= number;
            }
        }

        if (productOfEvensPositions == productOfOddsPositions)
        {
            Console.WriteLine("yes {0}", productOfOddsPositions);
        }
        else
        {
            Console.WriteLine("no {0} {1}", productOfOddsPositions, productOfEvensPositions);
        }
    }
}
