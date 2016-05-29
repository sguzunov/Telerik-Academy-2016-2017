// Write a program that reads a string from the console and replaces all series of consecutive identical letters with a single one.

using System;
using System.Text;

class SeriesOfLetters
{
    private static string ReplaceConsecutiveLettersByOne(string text)
    {
        char previousLetter = '\0';
        StringBuilder replacedLetterBuilder = new StringBuilder();
        for (int i = 0; i < text.Length; i++)
        {
            char currentLetter = text[i];
            if (previousLetter != currentLetter)
            {
                replacedLetterBuilder.Append(currentLetter);
                previousLetter = currentLetter;
            }
        }

        string replacedText = replacedLetterBuilder.ToString();
        return replacedText;
    }

    static void Main()
    {
        string text = Console.ReadLine();

        string replcedText = ReplaceConsecutiveLettersByOne(text);
        Console.WriteLine(replcedText);
    }
}
