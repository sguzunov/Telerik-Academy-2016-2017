/* Write a program that creates an array containing all letters from the alphabet (a-z).
   Read a word from the console and print the index of each of its letters in the array.
*/

using System;

class IndexOfLetters
{
    private const int AlphabetLettersCount = 26;

    static void Main()
    {
        string word = Console.ReadLine();

        char[] letters = new char[AlphabetLettersCount];
        for (int i = 0; i < 26; i++)
        {
            letters[i] = (char)(i + 97);
        }

        foreach (var letter in word)
        {
            int letterIndex = GetLetterIndex(letter, letters);
            Console.WriteLine(letterIndex);
        }
    }

    static int GetLetterIndex(char letter, char[] letters)
    {
        int leftIndex = 0;
        int rightIndex = letters.Length - 1;
        while (leftIndex <= rightIndex)
        {
            int midIndex = (rightIndex + leftIndex) / 2;
            if (letter > letters[midIndex])
            {
                leftIndex = midIndex + 1;
            }
            else if (letter < letters[midIndex])
            {
                rightIndex = midIndex - 1;
            }
            else
            {
                return midIndex;
            }
        }

        return -1;
    }
}
