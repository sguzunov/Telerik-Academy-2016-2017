// Write a program that reads two dates in the format: day.month.year and calculates the number of days between them.

using System;
using System.Collections.Generic;
using System.Globalization;

class DateDifference
{
    static void Main()
    {
        const string dateFormat = "d.MM.yyyy";

        Console.Write("Enter a date: ");
        DateTime firstDate = DateTime.ParseExact(Console.ReadLine(), dateFormat, CultureInfo.InvariantCulture);
        Console.Write("Enter a date: ");
        DateTime secondDate = DateTime.ParseExact(Console.ReadLine(), dateFormat, CultureInfo.InvariantCulture);

        int difference = secondDate.Day + (DateTime.DaysInMonth(firstDate.Year, firstDate.Month) - firstDate.Day);
        Console.WriteLine(difference);
    }
}
