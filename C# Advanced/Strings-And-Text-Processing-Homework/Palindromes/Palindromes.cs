// Write a program that extracts from a given text all palindromes, e.g. ABBA, lamal, exe.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Palindromes
{
    private static List<string> ExtractPolindromes(string text)
    {
        var fixedText = Regex.Replace(text, "[^a-zA-Z0-9]", " ");
        var splitedText = fixedText.Split(' ');
        List<string> polindromes = new List<string>();
        foreach (var word in splitedText)
        {
            if (word.Length > 1 && IsPolindrome(word))
            {
                polindromes.Add(word);
            }
        }

        return polindromes;
    }

    private static bool IsPolindrome(string word)
    {
        int lenght = word.Length;
        for (int i = 0; i < lenght / 2; i++)
        {
            if (word[i] != word[lenght - 1 - i])
            {
                return false;
            }
        }

        return true;
    }

    static void Main()
    {
        string text = Console.ReadLine();
        var polindromes = ExtractPolindromes(text);

        foreach (var polindrome in polindromes)
        {
            Console.WriteLine(polindrome);
        }
    }
}
