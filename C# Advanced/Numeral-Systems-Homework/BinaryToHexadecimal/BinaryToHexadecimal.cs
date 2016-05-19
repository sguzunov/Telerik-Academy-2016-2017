using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

class BinaryToHexadecimal
{
    private static List<string> ConvertBinaryToHex(string binaryNumber, List<string> hexAndBinaryValues)
    {
        List<string> hexParts = new List<string>();
        int leftLenght
            = binaryNumber.Length;
        while (leftLenght > 0)
        {
            string substr = string.Empty;
            if (leftLenght >= 4)
            {
                substr = binaryNumber.Substring(leftLenght - 4, 4);
                leftLenght -= 4;
            }
            else
            {
                substr = binaryNumber.Substring(0, leftLenght);
                leftLenght -= leftLenght;
            }

            int hexValue = hexAndBinaryValues.IndexOf(substr.PadLeft(4, '0'));
            if (hexValue >= 0 && hexValue <= 9)
            {
                hexParts.Add(hexValue.ToString());
            }
            else if (hexValue >= 10 && hexValue <= 15)
            {
                hexParts.Add(((char)(hexValue - 10 + 'A')).ToString());
            }
        }

        return hexParts;
    }

    static void Main()
    {
        List<string> hexAndBinaryValues = new List<string>() { "0000", "0001", "0010", "0011",
                                                "0100", "0101", "0110", "0111",
                                                "1000", "1001", "1010", "1011",
                                                "1100", "1101", "1110", "1111" };
        string binaryNumber = Console.ReadLine();
        var hexNumber = ConvertBinaryToHex(binaryNumber, hexAndBinaryValues);
        hexNumber.Reverse();
        Console.WriteLine(string.Join(string.Empty, hexNumber));
    }
}
