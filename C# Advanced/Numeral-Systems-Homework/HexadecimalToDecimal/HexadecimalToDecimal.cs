// Write a program that converts a hexadecimal number N to its decimal representation.

using System;
using System.Linq;
using System.Text;

public class HexadecimalToDecimal
{
    private static ulong ConvertHexToDecimal(string hex)
    {
        ulong numeralSystem = 16;
        ulong power = 1;
        ulong decimalNumber = 0;
        for (int i = hex.Length - 1; i >= 0; i--)
        {
            char digit = hex[i];
            if (digit >= '0' && digit <= '9')
            {
                decimalNumber += (ulong)(digit - '0') * power;
            }
            else if (digit >= 'A' && digit <= 'F')
            {
                decimalNumber += (ulong)(digit - 'A' + 10) * power;
            }

            power *= numeralSystem;
        }

        return decimalNumber;
    }

    private static void Main()
    {
        string hexNumber = Console.ReadLine();
        ulong decimalNumber = ConvertHexToDecimal(hexNumber);
        Console.WriteLine(decimalNumber);
    }
}
