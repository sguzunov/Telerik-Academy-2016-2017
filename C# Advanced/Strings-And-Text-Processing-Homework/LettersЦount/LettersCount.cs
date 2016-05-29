// Write a program that reads a string from the console and prints all different letters in the string along with information how many times each letter is found.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class LettersCount
{
    static void Main()
    {
        string text = Console.ReadLine();

        int[] smallLetters = new int[26];
        int[] capitalletters = new int[26];

        foreach (var ch in text)
        {
            if (ch >= 'A' && ch <= 'Z')
            {
                capitalletters[ch - 'A']++;
            }
            else if (ch >= 'a' && ch <= 'z')
            {
                smallLetters[ch - 'a']++;
            }
        }

        for (int i = 0; i < capitalletters.Length; i++)
        {
            if (capitalletters[i] != 0)
            {
                Console.WriteLine("{0} - {1} times", (char)(capitalletters[i] + 'A'), capitalletters[i]);
            }
        }

        for (int i = 0; i < smallLetters.Length; i++)
        {
            if (smallLetters[i] != 0)
            {
                Console.WriteLine("{0} - {1} times", (char)(smallLetters[i] + 'a'), smallLetters[i]);
            }
        }
    }
}
