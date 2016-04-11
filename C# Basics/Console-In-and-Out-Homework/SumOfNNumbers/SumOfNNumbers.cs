using System;

/* Write a program that enters a number N and after that enters more N numbers and calculates and prints their sum. */
class SumOfNNumbers
{
    static void Main()
    {
        byte n = byte.Parse(Console.ReadLine());

        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            int number = int.Parse(Console.ReadLine());
            sum += number;
        }

        Console.WriteLine(sum);
    }
}
