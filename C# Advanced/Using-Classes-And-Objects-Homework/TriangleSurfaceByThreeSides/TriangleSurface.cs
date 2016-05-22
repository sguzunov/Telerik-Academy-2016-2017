// Write program that calculates the surface of a triangle by given its three sides.

using System;
using System.Globalization;
using System.Threading;

class TriangleSurface
{
    private static double CalculatePerimeter(params double[] sides)
    {
        double perimeter = 0.0;
        foreach (var side in sides)
        {
            perimeter += side;
        }

        return perimeter;
    }

    private static double CalculateSurface(double sideA, double sideB, double sideC, double halfPerimeter)
    {
        double expression = halfPerimeter * (halfPerimeter - sideA) * (halfPerimeter - sideB) * (halfPerimeter - sideC);
        double surface = Math.Sqrt(expression);
        return surface;
    }

    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        double sideA = double.Parse(Console.ReadLine());
        double sideB = double.Parse(Console.ReadLine());
        double sideC = double.Parse(Console.ReadLine());

        double perimeter = CalculatePerimeter(sideA, sideB, sideC);
        double halfPerimeter = perimeter / 2;
        double surface = CalculateSurface(sideA, sideB, sideC, halfPerimeter);
        Console.WriteLine("{0:F2}", surface);
    }
}
