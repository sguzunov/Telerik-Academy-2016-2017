// Write a program that converts a decimal number N to its binary representation.

using System;
using System.Linq;
using System.Text;

class DecimalToBinary
{
    private static string ConvertDecimalToBinary(ulong decimalNumber)
    {
        ulong numeralSystem = 2;
        StringBuilder binaryNumber = new StringBuilder();
        while (decimalNumber > 0)
        {
            ulong digit = decimalNumber % numeralSystem;
            binaryNumber.Append(digit);
            decimalNumber /= 2;
        }

        string result = string.Join(string.Empty, binaryNumber.ToString().ToArray().Reverse());
        return result;
    }

    public static void Main()
    {
        ulong decimalNumber = ulong.Parse(Console.ReadLine());
        string binaryNumber = ConvertDecimalToBinary(decimalNumber);
        Console.WriteLine(binaryNumber);
    }
}
