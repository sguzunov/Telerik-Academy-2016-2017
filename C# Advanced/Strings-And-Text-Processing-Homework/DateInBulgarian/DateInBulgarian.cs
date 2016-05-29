// Write a program that reads a date and time given in the format: day.month.year hour:minute:second and
// prints the date and time after 6 hours and 30 minutes (in the same format) along with the day of week in Bulgarian.

using System;
using System.Globalization;
using System.Threading;

class DateInBulgarian
{
    static void Main()
    {
        const string dateFormat = "d.MM.yyyy HH:mm:ss";

        Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");

        var date = DateTime.ParseExact(Console.ReadLine(), dateFormat, CultureInfo.InvariantCulture);

        date.AddHours(6);
        date.AddMinutes(30);
        Console.WriteLine("{0:dddd.MMM.yyyy HH:mm:ss}", date);
    }
}
