/*
    Write a program that allocates array of N integers, initializes each element by its index multiplied by 5 and the prints the obtained array on the console.
 */

using System;

class Program
{
    static void Main()
    {
        byte n = byte.Parse(Console.ReadLine());

        byte[] numbers = new byte[n];
        for (int i = 0; i < n; i++)
        {
            numbers[i] = (byte)(i * 5);
        }

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(numbers[i]);
        }
    }
}
