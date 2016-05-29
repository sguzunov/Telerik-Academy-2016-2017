// Write a program that reads a string, reverses it and prints the result on the console.

using System;
using System.Text;

class ReverseString
{
    private static string ReverseStringCharacters(string str)
    {
        StringBuilder reversedStringBuilder = new StringBuilder();
        for (int i = str.Length - 1; i >= 0; i--)
        {
            reversedStringBuilder.Append(str[i]);
        }

        string reversedString = reversedStringBuilder.ToString();
        return reversedString;
    }

    static void Main()
    {
        string str = Console.ReadLine();

        string reversedString = ReverseStringCharacters(str);
        Console.WriteLine(reversedString);
    }
}
