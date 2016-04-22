/* 
    Write a program that reads a card sign(as a char) from the console and generates and prints all possible cards from a standard deck of 52 cards up to the card with the given sign(without the jokers). The cards should be printed using the classical notation (like 5 of spades, A of hearts, 9 of clubs; and K of diamonds).
    The card faces should start from 2 to A.
    Print each card face in its four possible suits: clubs, diamonds, hearts and spades. */

using System;

class Program
{
    static void Main()
    {
        string[] faces = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        string[] colors = { "spades", "clubs", "hearts", "diamonds" };

        string face = Console.ReadLine();

        int faceIndex = 0;
        while (true)
        {
            string[] cardsOfAFace = new string[colors.Length];
            for (int i = 0; i < colors.Length; i++)
            {
                cardsOfAFace[i] = faces[faceIndex] + " of " + colors[i];
            }

            Console.WriteLine(string.Join(", ", cardsOfAFace));

            if (faces[faceIndex] == face)
            {
                break;
            }

            faceIndex++;
        }
    }
}
