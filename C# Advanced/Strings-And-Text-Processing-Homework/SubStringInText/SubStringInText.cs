// Write a program that finds how many times a sub-string is contained in a given text (perform case insensitive search).

using System;

class SubStringInText
{
    private static int CountPatternInText(string text, string pattern)
    {
        string textToLower = text.ToLower();
        string patternToLower = pattern.ToLower();

        int count = 0;
        int index = textToLower.IndexOf(patternToLower, 0);
        while (index > -1)
        {
            count++;
            index = textToLower.IndexOf(patternToLower, index + 1);
        }

        return count;
    }

    static void Main()
    {
        string pattern = Console.ReadLine();
        string text = Console.ReadLine();
        Console.WriteLine(CountPatternInText(text, pattern));
    }
}
