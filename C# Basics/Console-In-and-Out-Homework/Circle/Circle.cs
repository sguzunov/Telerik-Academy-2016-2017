using System;
using System.Globalization;
using System.Threading;

// Write a program that reads from the console the radius r of a circle and prints its perimeter and area, rounded and formatted with 2 digits after the decimal point.
class Circle
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        double circleRadius = double.Parse(Console.ReadLine());

        double circleArea = Math.PI * Math.Pow(circleRadius, 2);
        double circlePerimeter = 2 * Math.PI * circleRadius;
        Console.WriteLine("{0:0.00} {1:0.00}", circlePerimeter, circleArea);
    }
}

