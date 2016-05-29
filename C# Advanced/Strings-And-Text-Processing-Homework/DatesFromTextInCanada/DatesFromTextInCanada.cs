// Write a program that extracts from a given text all dates that match the format DD.MM.YYYY. Display them in the standard date format for Canada.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

class DatesFromTextInCanada
{
    private static List<DateTime> ParseDates(string text, string format)
    {
        var splittedText = text.Split(new char[] { '(', ')', '-', '/', ' ', '*', '+' }, StringSplitOptions.RemoveEmptyEntries);
        var dates = new List<DateTime>();
        foreach (string word in splittedText)
        {
            string trimmedWord = word.Trim('.');
            DateTime date;
            if (DateTime.TryParseExact(trimmedWord, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                dates.Add(date);
            }
        }

        return dates;
    }

    static void Main()
    {
        string text = Console.ReadLine();
        var dates = ParseDates(text, "dd.MM.yyyy");

        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
        foreach (var date in dates)
        {
            Console.WriteLine(date);
        }
    }
}
