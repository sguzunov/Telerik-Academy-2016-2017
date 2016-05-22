// Write program that calculates the surface of a triangle by given two sides and an angle between them.

using System;
using System.Globalization;
using System.Threading;

class TriangleSurface
{
    private static double CalculateSurface(double sideA, double sideB, double angleInDegrees)
    {
        double angleInRadians = angleInDegrees * Math.PI / 180;
        double angleSin = Math.Sin(angleInRadians);
        double surface = (sideA * sideB * angleSin) / 2;
        return surface;
    }

    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        double sideA = double.Parse(Console.ReadLine());
        double sideB = double.Parse(Console.ReadLine());
        double angleInDegrees = double.Parse(Console.ReadLine());

        double surface = CalculateSurface(sideA, sideB, angleInDegrees);
        Console.WriteLine("{0:F2}", surface);
    }
}
