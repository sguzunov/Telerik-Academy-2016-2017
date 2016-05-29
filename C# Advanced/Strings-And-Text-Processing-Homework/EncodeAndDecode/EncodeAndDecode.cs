/*
    Write a program that encodes and decodes a string using given encryption key (cipher).
    The key consists of a sequence of characters.
    The encoding/decoding is done by performing XOR (exclusive or) operation over the first letter of the string with the first of the key, the second – with the second, etc. 
    When the last key character is reached, the next is the first.
 */

using System;

class EncodeAndDecode
{
    private static string EncodeOrDecodeMessage(string message, string cypher)
    {
        char[] messageAsArray = message.ToCharArray();
        int maxLenght = Math.Max(message.Length, cypher.Length);
        for (int i = 0; i < maxLenght; i++)
        {
            int messageIndex = i % message.Length;
            int cypherIndex = i % cypher.Length;
            messageAsArray[messageIndex] = (char)(messageAsArray[messageIndex] ^ cypher[cypherIndex]);
        }

        string encodedDecodedMessage = string.Join("", messageAsArray);
        return encodedDecodedMessage;
    }

    static void Main()
    {
        string message = Console.ReadLine();
        string cypher = Console.ReadLine();

        string encodedDecodedMessage = EncodeOrDecodeMessage(message, cypher);
        Console.WriteLine(encodedDecodedMessage);
    }
}
