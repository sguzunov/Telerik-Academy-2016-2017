// Write a program that converts a binary number N to its decimal representation.

using System;

public class BinaryToDecimal
{
    private static ulong ConvertBinaryToDecimal(string binaryNumber)
    {
        ulong power = 1;
        ulong decimalNumber = 0;
        for (int i = binaryNumber.Length - 1; i >= 0; i--)
        {
            int digit = binaryNumber[i] - '0';
            decimalNumber += ((ulong)digit * power);
            power *= 2;
        }

        return decimalNumber;
    }

    public static void Main()
    {
        string binaryNumber = Console.ReadLine();
        ulong decimalNumber = ConvertBinaryToDecimal(binaryNumber);
        Console.WriteLine(decimalNumber);
    }
}
