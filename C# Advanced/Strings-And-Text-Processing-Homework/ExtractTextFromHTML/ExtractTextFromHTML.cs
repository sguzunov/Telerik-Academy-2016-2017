using System;
using System.Collections.Generic;
using System.Linq;

class ExtractTextFromHTML
{
    private const string TitleOpenTag = "<title>";
    private const string TitleCloseTag = "</title>";

    private static string ExtractTitle(string html)
    {
        int openTagIndex = html.IndexOf(TitleOpenTag);
        string titleContent = string.Empty;
        if (openTagIndex > -1)
        {
            int closeTagIndex = html.IndexOf(TitleCloseTag);
            titleContent = html.Substring(openTagIndex, closeTagIndex - openTagIndex);
        }

        return titleContent;
    }

    static void Main()
    {
        string html = Console.ReadLine();
    }
}
