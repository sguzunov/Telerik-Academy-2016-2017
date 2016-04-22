/* Using loops write a program that converts an integer number to its binary representation. */

using System;

class DecimalToBinary
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        string numberInBinaryForm = string.Empty;
        if (number == 0)
        {
            numberInBinaryForm = "0";
        }
        else
        {
            while (number > 0)
            {
                int bit = number % 2;
                number /= 2;
                numberInBinaryForm = bit + numberInBinaryForm;
            }
        }

        Console.WriteLine(numberInBinaryForm);
    }
}
