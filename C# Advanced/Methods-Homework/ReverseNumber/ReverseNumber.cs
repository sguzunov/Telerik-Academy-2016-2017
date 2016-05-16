// Write a method that reverses the digits of a given decimal number.

using System;
using System.Linq;

class ReverseNumber
{
    static void Main()
    {
        string numberAsString = Console.ReadLine();
        Console.WriteLine(string.Join("", numberAsString.ToArray().Reverse()));
    }
}
