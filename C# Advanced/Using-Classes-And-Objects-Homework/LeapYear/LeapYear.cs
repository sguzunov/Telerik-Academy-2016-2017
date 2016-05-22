// Write a program that reads a year from the console and checks whether it is a leap one.

using System;

class LeapYear
{
    private static bool CheckIsLeapYear(int year)
    {
        var isLeapYear = DateTime.IsLeapYear(year);
        return isLeapYear;
    }

    //private static bool CheckIsLeapYear(int year)
    //{
    //    if (year % 4 == 0)
    //    {
    //        if (year % 100 == 0)
    //        {
    //            if (year % 400 == 0)
    //            {
    //                return true;
    //            }
    //            else
    //            {
    //                return false;
    //            }
    //        }

    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

    static void Main()
    {
        ushort year = ushort.Parse(Console.ReadLine());

        bool isLeapYear = CheckIsLeapYear(year);
        if (isLeapYear)
        {
            Console.WriteLine("Leap");
        }
        else
        {
            Console.WriteLine("Common");
        }
    }
}
