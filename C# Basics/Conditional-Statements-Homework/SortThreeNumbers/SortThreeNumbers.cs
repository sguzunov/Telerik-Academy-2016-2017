/*  Write a program that enters 3 real numbers and prints them sorted in descending order.
    Use nested if statements.
    Don’t use arrays and the built-in sorting functionality.
*/

using System;

class SortThreeNumbers
{
    static void Main()
    {
        short firstNumber = short.Parse(Console.ReadLine());
        short secondNumber = short.Parse(Console.ReadLine());
        short thirdNumber = short.Parse(Console.ReadLine());

        string numbersTemplate = "{0} {1} {2}";
        if (firstNumber > secondNumber && firstNumber > thirdNumber)
        {
            if (secondNumber > thirdNumber)
            {
                Console.WriteLine(numbersTemplate, firstNumber, secondNumber, thirdNumber);
            }
            else
            {
                Console.WriteLine(numbersTemplate, firstNumber, thirdNumber, secondNumber);
            }
        }
        else
        {
            if (secondNumber > thirdNumber)
            {
                if (firstNumber > thirdNumber)
                {
                    Console.WriteLine(numbersTemplate, secondNumber, firstNumber, thirdNumber);
                }
                else
                {
                    Console.WriteLine(numbersTemplate, secondNumber, thirdNumber, firstNumber);
                }
            }
            else
            {
                if (firstNumber > secondNumber)
                {
                    Console.WriteLine(numbersTemplate, thirdNumber, firstNumber, secondNumber);
                }
                else
                {
                    Console.WriteLine(numbersTemplate, thirdNumber, secondNumber, firstNumber);
                }
            }
        }
    }
}
