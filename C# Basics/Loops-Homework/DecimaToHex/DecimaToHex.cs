/* Using loops write a program that converts an integer number to its hexadecimal representation. */

using System;

class Program
{
    static void Main()
    {
        long number = long.Parse(Console.ReadLine());

        string numberInHexForm = string.Empty;
        if (number == 0)
        {
            numberInHexForm = "0";
        }
        else
        {
            while (number > 0)
            {
                long rest = number % 16;
                number /= 16;
                if (0 <= rest && rest <= 9)
                {
                    numberInHexForm = rest + numberInHexForm;
                }
                else
                {
                    numberInHexForm = (char)('A' + (rest % 10)) + numberInHexForm;
                }
            }
        }

        Console.WriteLine(numberInHexForm);
    }
}
