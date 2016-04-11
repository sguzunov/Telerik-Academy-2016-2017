using System;
using System.Globalization;
using System.Threading;

//Write a program that gets two numbers from the console and prints the greater of them.

class NumberComparer
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        double firstNumber = double.Parse(Console.ReadLine());
        double secondNumber = double.Parse(Console.ReadLine());

        double largerNumber = ((firstNumber + secondNumber) + Math.Abs(firstNumber - secondNumber
            )) / 2;
        Console.WriteLine(largerNumber);
    }
}
