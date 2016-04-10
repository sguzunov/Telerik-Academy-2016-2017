using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourDigits
{
    /*
        Write a program that takes as input a four-digit number in format abcd (e.g. 2011) and performs the following:
            Calculates the sum of the digits (in our example 2 + 0 + 1 + 1 = 4) and prints it on the console.
            Prints on the console the number in reversed order: dcba (in our example 1102) and prints the reversed number.
            Puts the last digit in the first position: dabc (in our example 1201) and prints the result.
            Exchanges the second and the third digits: acbd (in our example 2101) and prints the result.
    */

    class Program
    {
        static void Main()
        {
            short inputNumber = short.Parse(Console.ReadLine());

            byte firstDigit = (byte)(inputNumber / 1000);
            inputNumber %= 1000;
            byte secondDigit = (byte)(inputNumber / 100);
            inputNumber %= 100;
            byte thirdDigit = (byte)(inputNumber / 10);
            inputNumber %= 10;
            byte fourthDigit = (byte)inputNumber;

            byte sum = (byte)(firstDigit + secondDigit + thirdDigit + fourthDigit);

            Console.WriteLine(sum);
            Console.WriteLine("{0}{1}{2}{3}", fourthDigit, thirdDigit, secondDigit, firstDigit);
            Console.WriteLine("{0}{1}{2}{3}", fourthDigit, firstDigit, secondDigit, thirdDigit);
            Console.WriteLine("{0}{1}{2}{3}", firstDigit, thirdDigit, secondDigit, fourthDigit);
        }
    }
}
