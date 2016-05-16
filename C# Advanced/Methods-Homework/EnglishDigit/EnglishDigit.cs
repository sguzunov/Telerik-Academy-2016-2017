// Write a method that returns the last digit of given integer as an English word. Write a program that reads a number and prints the result of the method.

using System;

class EnglishDigit
{
    private static void PrintDigit(byte digit)
    {
        string[] digitsAsWords = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

        if (digit >= 0 && digit <= 9)
        {
            Console.WriteLine(digitsAsWords[digit]);
        }
    }

    private static byte GetLastDigit(int number)
    {
        byte lastDigit = (byte)(number % 10);
        return lastDigit;
    }

    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        byte lastDigit = GetLastDigit(number);
        PrintDigit(lastDigit);
    }
}
