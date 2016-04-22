/* Write a program that reads from the console a sequence of N integer numbers and returns the minimal, the maximal number, the sum and the average of all numbers (displayed with 2 digits after the decimal point). */

using System;

class MMSAOfNNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        double min = double.MaxValue;
        double max = double.MinValue;
        double sum = 0.0;
        for (int i = 0; i < n; i++)
        {
            double number = double.Parse(Console.ReadLine());

            sum += number;
            if (min > number)
            {
                min = number;
            }

            if (max < number)
            {
                max = number;
            }
        }

        double average = sum / n;
        Console.WriteLine("min={0:F2}", min);
        Console.WriteLine("max={0:F2}", max);
        Console.WriteLine("sum={0:F2}", sum);
        Console.WriteLine("avg={0:F2}", average);
    }
}
