/* Using loops write a program that converts a hexadecimal integer number to its decimal form. */

using System;

class Program
{
    static void Main()
    {
        string numberInHex = Console.ReadLine();

        long number = 0u;
        for (int i = 0; i < numberInHex.Length; i++)
        {
            char digit = numberInHex[i];
            int power = numberInHex.Length - i - 1;
            if ('0' <= digit && digit <= '9')
            {
                number += (long)((digit - '0') * Math.Pow(16, power));
            }
            else
            {
                number += (long)((digit - 'A' + 10) * Math.Pow(16, power));
            }
        }

        Console.WriteLine(number);
    }
}
