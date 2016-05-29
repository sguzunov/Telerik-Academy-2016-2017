// Write a program that extracts from a given text all sentences containing given word.

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

class Program
{
    private static char[] GetAllNoneLetterSymbols(string text)
    {
        var nonLetterSymbol = new HashSet<char>();
        foreach (var ch in text)
        {
            if (!char.IsLetter(ch))
            {
                nonLetterSymbol.Add(ch);
            }
        }

        return nonLetterSymbol.ToArray();
    }

    static void Main()
    {
        string searchedWord = Console.ReadLine();
        string text = Console.ReadLine();

        var nonLetterSymbols = GetAllNoneLetterSymbols(text);
        var textSplitted = text.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
        StringBuilder result = new StringBuilder();
        foreach (var sentence in textSplitted)
        {
            var words = sentence.Split(nonLetterSymbols, StringSplitOptions.RemoveEmptyEntries).ToList();
            if (words.Contains(searchedWord))
            {
                result.Append(sentence.Trim() + ". ");
            }
        }

        Console.WriteLine(result.ToString());
    }
}
