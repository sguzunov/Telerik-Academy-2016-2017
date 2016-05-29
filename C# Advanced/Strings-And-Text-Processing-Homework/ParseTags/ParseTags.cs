// You are given a text. Write a program that changes the text in all regions surrounded by the tags <upcase> and </upcase> to upper-case.

using System;
using System.Text;

class Program
{
    private static string ParseUpCaseTags(string text, string openTag, string closeTag)
    {
        StringBuilder parsedTextBuilder = new StringBuilder();
        bool inTag = false;
        for (int i = 0; i < text.Length; i++)
        {
            if (inTag)
            {
                int indexOfCloseTag = text.IndexOf(closeTag, i);
                if (indexOfCloseTag == i)
                {
                    inTag = false;
                    i += closeTag.Length - 1;
                }
                else
                {
                    parsedTextBuilder.Append(text[i].ToString().ToUpper());
                }
            }
            else
            {
                int indexOfOpenTag = text.IndexOf(openTag, i);
                if (indexOfOpenTag == i)
                {
                    inTag = true;
                    i += openTag.Length - 1;
                }
                else
                {
                    parsedTextBuilder.Append(text[i]);
                }
            }
        }

        string parsedText = parsedTextBuilder.ToString();
        return parsedText;
    }

    static void Main()
    {
        const string openUpCaseTag = "<upcase>";
        const string closeUpCaseTag = "</upcase>";

        string text = Console.ReadLine();
        string parsedText = ParseUpCaseTags(text, openUpCaseTag, closeUpCaseTag);
        Console.WriteLine(parsedText);
    }
}
