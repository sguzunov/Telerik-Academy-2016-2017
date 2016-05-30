/*
    Write a program that reads a number and calculates and prints its square root.
        If the number is invalid or negative, print Invalid number.
        In all cases finally print Good bye. Use try-catch-finally block.  
 */

using System;
using System.Globalization;
using System.Threading;

class Program
{
    private static double CalculateSqrt(double number)
    {
        if (number < 0)
        {
            throw new ArgumentException("Invalid number");
        }

        double sqrt = Math.Sqrt(number);
        return sqrt;
    }

    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        try
        {
            double number = double.Parse(Console.ReadLine());
            double sqrt = CalculateSqrt(number);
            Console.WriteLine("{0:F3}", sqrt);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid number");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("Good bye");
        }
    }
}
