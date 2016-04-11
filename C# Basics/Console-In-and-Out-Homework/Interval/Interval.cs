using System;

/* Write a program that reads two positive integer numbers N and M and prints how many numbers exist between them such that the reminder of the division by 5 is 0. */
class Interval
{
    static void Main()
    {
        int lowerBound = int.Parse(Console.ReadLine());
        int upperBoud = int.Parse(Console.ReadLine());

        int count = 0;
        for (int i = lowerBound + 1; i < upperBoud; i++)
        {
            if (i % 5 == 0)
            {
                count++;
            }
        }

        Console.WriteLine(count);
    }
}
