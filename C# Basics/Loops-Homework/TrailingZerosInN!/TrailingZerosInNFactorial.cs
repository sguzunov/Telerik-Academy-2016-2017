/* Write a program that calculates with how many zeroes the factorial of a given number N has at its end. */

using System;

class TrailingZerosInNFactorial
{
    static void Main()
    {
        uint number = uint.Parse(Console.ReadLine());

        uint sum = 0;
        uint deviderOnPower = 5;
        while (deviderOnPower < number)
        {
            sum += (number / deviderOnPower);
            deviderOnPower *= 5;
        }

        Console.WriteLine(sum);
    }
}
