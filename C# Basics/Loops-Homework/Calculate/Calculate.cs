/* Write a program that, for a given two integer numbers N and x, calculates the sum S = 1 + 1!/x + 2!/x2 + … + N!/xN. */

using System;

class Calculate
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        double x = double.Parse(Console.ReadLine());

        double sum = 1.0;
        int factorial = 1;
        double numberOnPower = 1;
        for (int i = 1; i <= n; i++)
        {
            factorial = factorial * i;
            numberOnPower *= x;
            sum += (factorial / numberOnPower);
        }

        Console.WriteLine("{0:F5}", sum);
    }
}
