using System;
using System.Globalization;
using System.Threading;

class TriangleSurface
{
    private static double CalculateTriangleSurface(double side, double altitude)
    {
        double surface = (side * altitude) / 2;
        return surface;
    }

    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        double side = double.Parse(Console.ReadLine());
        double altitude = double.Parse(Console.ReadLine());

        double surface = CalculateTriangleSurface(side, altitude);
        Console.WriteLine("{0:F2}", surface);
    }
}
