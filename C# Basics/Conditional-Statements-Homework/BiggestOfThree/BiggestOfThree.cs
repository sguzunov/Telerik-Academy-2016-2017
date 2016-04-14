/* Write a program that finds the biggest of three numbers that are read from the console. */

using System;
using System.Globalization;
using System.Threading;

class BiggestOfThree
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        float firstNumber = float.Parse(Console.ReadLine());
        float secondNumber = float.Parse(Console.ReadLine());
        float thirdNumber = float.Parse(Console.ReadLine());

        float biggerNumber = firstNumber;
        if (firstNumber < secondNumber)
        {
            biggerNumber = secondNumber;
        }

        if (biggerNumber < thirdNumber)
        {
            biggerNumber = thirdNumber;
        }

        Console.WriteLine(biggerNumber);
    }
}
