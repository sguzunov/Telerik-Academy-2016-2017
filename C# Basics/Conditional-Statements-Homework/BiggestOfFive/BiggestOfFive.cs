/* Write a program that finds the biggest of 5 numbers that are read from the console, using only 5 if statements */

using System;
using System.Globalization;
using System.Threading;

class BiggestOfFive
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        float firstNumber = float.Parse(Console.ReadLine());
        float secondNumber = float.Parse(Console.ReadLine());
        float thirdNumber = float.Parse(Console.ReadLine());
        float fourthNumber = float.Parse(Console.ReadLine());
        float fifthNumber = float.Parse(Console.ReadLine());

        float biggestNumber = firstNumber;
        if (biggestNumber < secondNumber || biggestNumber < thirdNumber | biggestNumber < fourthNumber || biggestNumber < fifthNumber)
        {
            biggestNumber = secondNumber;
            if (biggestNumber < thirdNumber || biggestNumber < fourthNumber || biggestNumber < fifthNumber)
            {
                biggestNumber = thirdNumber;
                if (biggestNumber < fourthNumber || biggestNumber < fifthNumber)
                {
                    biggestNumber = fourthNumber;
                    if (biggestNumber < fifthNumber)
                    {
                        biggestNumber = fifthNumber;
                    }
                }
            }
        }

        Console.WriteLine(biggestNumber);
    }
}
