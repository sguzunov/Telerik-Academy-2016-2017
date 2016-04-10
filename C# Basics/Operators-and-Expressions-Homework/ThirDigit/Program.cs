namespace ThirDigit
{
    /*
        Write a program that reads an integer N from the console and prints true if the third digit of N is 7, or "false THIRD_DIGIT", where you should print the third digits of N.
        The counting is done from right to left, meaning 123456's third digit is 4.
    */

    using System;

    class Program
    {
        static void Main()
        {
            uint number = uint.Parse(Console.ReadLine());

            number = number / 100;
            uint thirdDigit = number % 10;
            bool isThirdDigitSeven = thirdDigit == 7;
            Console.WriteLine(isThirdDigitSeven ? "true" : string.Format("false {0}", thirdDigit));
        }
    }
}
