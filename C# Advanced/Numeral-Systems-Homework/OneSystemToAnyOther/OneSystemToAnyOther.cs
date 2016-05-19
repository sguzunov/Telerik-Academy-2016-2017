// Write a program to convert the number N from any numeral system of given base s to any other numeral system of base d.

using System;
using System.Linq;
using System.Text;

class OneSystemToAnyOther
{
    private static ulong ConvertToDecimal(string number, int numeralSystem)
    {
        ulong power = 1;
        ulong decimalNumber = 0;
        for (int i = number.Length - 1; i >= 0; i--)
        {
            char digit = number[i];
            if (digit >= '0' && digit <= '9')
            {
                decimalNumber += ((ulong)(digit - '0') * power);
            }
            else
            {
                decimalNumber += ((ulong)(digit - 'A' + 10) * power);
            }

            power *= (ulong)numeralSystem;
        }

        return decimalNumber;
    }

    private static string ConvertDecimalToAnyNumeralSystem(ulong decimalNumber, int numeralSystem)
    {
        StringBuilder result = new StringBuilder();
        while (decimalNumber > 0)
        {
            ulong rest = decimalNumber % (ulong)numeralSystem;
            if (rest >= 0 && rest <= 9)
            {
                result.Append(rest);
            }
            else
            {
                result.Append((char)(rest - 10 + 'A'));
            }

            decimalNumber /= (ulong)numeralSystem;
        }

        return string.Join(string.Empty, result.ToString().ToArray().Reverse());
    }

    private static string ConvertFromOneNumeralToOtherNumeralSystem(string number, int fromBase, int toBase)
    {
        ulong decimalNumber = ConvertToDecimal(number, fromBase);
        string result = ConvertDecimalToAnyNumeralSystem(decimalNumber, toBase);
        return result;
    }

    static void Main()
    {
        int fromBase = int.Parse(Console.ReadLine());
        string number = Console.ReadLine();
        int toBase = int.Parse(Console.ReadLine());

        string result = ConvertFromOneNumeralToOtherNumeralSystem(number, fromBase, toBase);
        Console.WriteLine(result);
    }
}
