using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ForbiddenWords
{
    private static string ReplceForbiddenWords(string text, List<string> forbiddenWords, char replaceCharacter)
    {
        StringBuilder textBuilder = new StringBuilder(text);
        foreach (var forbWord in forbiddenWords)
        {
            textBuilder.Replace(forbWord, new string('*', forbWord.Length));
        }

        return textBuilder.ToString();
    }

    static void Main()
    {
        string text = Console.ReadLine();
        List<string> forbiddenWords = Console.ReadLine().Split(' ').ToList();
        string replacedText = ReplceForbiddenWords(text, forbiddenWords, '*');
        Console.WriteLine(replacedText);
    }
}
