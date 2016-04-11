using System;
using System.Globalization;
using System.Threading;
/* Write a program that reads the coefficients a, b and c of a quadratic equation ax2 + bx + c = 0 and solves it (prints its real roots). */
class Program
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());

        double d = Math.Pow(b, 2) - (4 * a * c);
        if (d > 0)
        {
            double firstRoot = (-b - Math.Sqrt(d)) / (2 * a);
            double secondRoot = (-b + Math.Sqrt(d)) / (2 * a);
            if (firstRoot > secondRoot)
            {
                firstRoot += secondRoot;
                secondRoot = firstRoot - secondRoot;
                firstRoot = firstRoot - secondRoot;
            }

            Console.WriteLine("{0:0.00}", firstRoot);
            Console.WriteLine("{0:0.00}", secondRoot);
        }
        else if (d == 0)
        {
            double root = -b / (2 * a);
            Console.WriteLine("{0:0.00}", root);
        }
        else
        {
            Console.WriteLine("no real roots");
        }
    }
}

