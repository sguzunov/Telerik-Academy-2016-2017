/* Using loops write a program that converts a binary integer number to its decimal form. */

using System;

class BinaryToDecimal
{
    static void Main()
    {
        string numberAsBinary = Console.ReadLine();

        int decimalForm = 0;
        for (int i = 0; i < numberAsBinary.Length; i++)
        {
            char bitAsString = numberAsBinary[numberAsBinary.Length - i - 1];
            int bit = (bitAsString - '0');
            decimalForm += (int)(bit * Math.Pow(2, i));
        }

        Console.WriteLine(decimalForm);
    }
}
