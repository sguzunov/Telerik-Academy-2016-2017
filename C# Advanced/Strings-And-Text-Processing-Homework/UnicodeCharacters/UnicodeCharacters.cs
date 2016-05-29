// Write a program that converts a string to a sequence of C# Unicode character literals.

using System;

class UnicodeCharacters
{
    static void Main()
    {
        string input = Console.ReadLine();

        for (int i = 0; i < input.Length; i++)
        {
            Console.Write("\\u{0:X4}", (int)input[i]);
        }

        Console.WriteLine();
    }
}
