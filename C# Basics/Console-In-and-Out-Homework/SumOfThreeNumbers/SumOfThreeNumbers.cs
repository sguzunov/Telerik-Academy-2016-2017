using System;
using System.Globalization;
using System.Threading;

// Write a program that reads 3 real numbers from the console and prints their sum.
class SumOfThreeNumbers
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        float a = float.Parse(Console.ReadLine());
        float b = float.Parse(Console.ReadLine());
        float c = float.Parse(Console.ReadLine());

        float sum = a + b + c;
        Console.WriteLine(sum);
    }
}

