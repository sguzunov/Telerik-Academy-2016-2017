// Write a program that reads from the console a string of maximum 20 characters. If the length of the string is less than 20, the rest of the characters should be filled with *.

using System;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        input = input.Replace("\\", string.Empty);
        Console.WriteLine(input.PadRight(20, '*'));
    }
}
