// A dictionary is stored as a sequence of text lines containing words and their explanations. Write a program that enters a word and translates it by using the dictionary.

using System;
using System.Collections.Generic;

class WordDictionary
{
    private const string AddTermOption = "add";
    private const string SearchTermOption = "search";
    private const string ExitOption = "exit";

    private static Dictionary<string, string> dictionary = new Dictionary<string, string>();

    private static bool AddTerm(string newTerm, string explanation)
    {
        if (dictionary.ContainsKey(newTerm))
        {
            return false;
        }

        dictionary.Add(newTerm, explanation);
        return true;
    }

    private static string SearchTerm(string term)
    {
        string explanation = string.Empty;
        if (dictionary.ContainsKey(term))
        {
            explanation = dictionary[term];
        }

        return explanation;
    }

    private static void PrintExplanation(string term, string explanation)
    {
        if (!string.IsNullOrEmpty(explanation))
        {
            Console.WriteLine("{0} --> {1}", term, explanation);
        }
        else
        {
            Console.WriteLine("Explanation not found!");
        }
    }

    private static void ShowOptions(params string[] options)
    {
        Console.WriteLine("Choose option");
        foreach (var option in options)
        {
            Console.WriteLine(option);
        }
    }

    static void Main()
    {
        while (true)
        {
            ShowOptions(AddTermOption, SearchTermOption, ExitOption);

            Console.Write("------> ");
            var option = Console.ReadLine().Trim().ToLower();

            if (option == AddTermOption)
            {
                Console.Write("Enter term: ");
                var newTerm = Console.ReadLine().Trim();
                Console.Write("Enter explanation: ");
                var explanation = Console.ReadLine().Trim();
                AddTerm(newTerm, explanation);
            }
            else if (option == SearchTermOption)
            {
                Console.Write("Enter term: ");
                var term = Console.ReadLine().Trim();
                var explanation = SearchTerm(term);
                PrintExplanation(term, explanation);
            }
            else
            {
                break;
            }
        }
    }
}
