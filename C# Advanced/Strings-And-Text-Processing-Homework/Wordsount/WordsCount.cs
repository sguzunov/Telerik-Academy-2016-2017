// Write a program that reads a string from the console and lists all different words in the string along with information how many times each word is found.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class WordsCount
{
    static void Main()
    {
        string text = Console.ReadLine();

        string fixedText = Regex.Replace(text, "[^a-zA-Z]", " ");
        var splittedText = fixedText.Split(' ');
        Dictionary<string, int> wordCount = new Dictionary<string, int>();
        foreach (var word in splittedText)
        {
            if (word.Length > 1)
            {
                if (!wordCount.ContainsKey(word))
                {
                    wordCount.Add(word, 1);
                }
                else
                {
                    wordCount[word]++;
                }
            }
        }

        foreach (var item in wordCount)
        {
            string word = item.Key;
            int count = item.Value;
            Console.WriteLine("{0} - {1} times", word, count);
        }
    }
}
