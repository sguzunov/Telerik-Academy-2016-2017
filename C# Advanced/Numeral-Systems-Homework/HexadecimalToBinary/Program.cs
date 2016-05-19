using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexadecimalToBinary
{
    class HexadecimalToBinary
    {
        private static string ConvertHexToBinary(string hexNumber, List<string> hexAndBinaryValues)
        {
            string result = string.Empty;
            for (int i = hexNumber.Length - 1; i >= 0; i--)
            {
                string binValue = string.Empty;
                char digit = hexNumber[i];
                if (digit >= '0' && digit <= '9')
                {
                    binValue = hexAndBinaryValues[digit - '0'];
                    result = binValue + result;
                }
                else if (digit >= 'A' && digit <= 'F')
                {
                    binValue = hexAndBinaryValues[digit - 'A' + 10];
                    result = binValue + result;
                }
            }

            return result;
        }

        private static string RemoveLeadingZeroes(string binaryNumber)
        {
            int indexOfFirstSignfBit = binaryNumber.IndexOf('1');
            return binaryNumber.Substring(indexOfFirstSignfBit);
        }

        static void Main(string[] args)
        {
            List<string> hexAndBinaryValues = new List<string>() { "0000", "0001", "0010", "0011",
                                                "0100", "0101", "0110", "0111",
                                                "1000", "1001", "1010", "1011",
                                                "1100", "1101", "1110", "1111" };
            string hexNumber = Console.ReadLine();
            string binaryNumber = ConvertHexToBinary(hexNumber, hexAndBinaryValues);
            binaryNumber = RemoveLeadingZeroes(binaryNumber);
            Console.WriteLine(binaryNumber);
        }
    }
}
