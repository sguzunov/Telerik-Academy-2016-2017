// Write a program for extracting all email addresses from given text. All sub-strings that match the format <identifier>@<host>…<domain> should be recognized as emails.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class ExtractEmails
{
    static void Main()
    {
        const string emailPattern = @"\b[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}\b";

        string text = Console.ReadLine();

        Regex regex = new Regex(emailPattern);
        var matches = regex.Matches(text);
        foreach (var match in matches)
        {
            Console.WriteLine(match);
        }
    }
}
