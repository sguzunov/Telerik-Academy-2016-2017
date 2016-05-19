// Write a program that converts a decimal number N to its hexadecimal representation.

using System;
using System.Linq;
using System.Text;

class DecimalToHexadecimal
{
    private static string ConvertDecimalToHex(ulong decimalNumber)
    {
        ulong numeralSystem = 16;
        StringBuilder hexNumber = new StringBuilder();
        while (decimalNumber > 0)
        {
            ulong digit = decimalNumber % numeralSystem;
            if (digit >= 0 && digit <= 9)
            {
                hexNumber.Append(digit);
            }
            else if (digit >= 10 && digit <= 15)
            {
                hexNumber.Append((char)(digit - 10 + 'A'));
            }

            decimalNumber /= numeralSystem;
        }

        string result = string.Join(string.Empty, hexNumber.ToString().ToArray().Reverse());
        return result;
    }

    public static void Main()
    {
        ulong decimalNumber = ulong.Parse(Console.ReadLine());
        string hexNumber = ConvertDecimalToHex(decimalNumber);
        Console.WriteLine(hexNumber);
    }
}
