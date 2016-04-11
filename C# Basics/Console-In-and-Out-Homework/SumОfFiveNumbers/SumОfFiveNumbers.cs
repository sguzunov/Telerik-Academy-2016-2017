using System;

class SumОfFiveNumbers
{
    static void Main()
    {
        short firstNumber = short.Parse(Console.ReadLine());
        short secondNumber = short.Parse(Console.ReadLine());
        short thirdNumber = short.Parse(Console.ReadLine());
        short fourthNumber = short.Parse(Console.ReadLine());
        short fifthNumber = short.Parse(Console.ReadLine());

        int sum = firstNumber + secondNumber + thirdNumber + fourthNumber + fifthNumber;
        Console.WriteLine(sum);
    }
}

