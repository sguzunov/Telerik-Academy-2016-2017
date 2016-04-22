/* Write a program that reads from the console a positive integer number N and prints a matrix like in the examples below. Use two nested loops */

using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int endRow = n + 1;
        int row = 1;
        int currentNumber = 1;
        for (int i = 0; i < n * n; i++)
        {
            Console.Write(currentNumber + " ");
            currentNumber++;
            if (currentNumber == endRow)
            {
                row++;
                currentNumber = row;
                endRow++;
                Console.WriteLine();
            }
        }

        //for (int i = 1; i < n + 1; i++)
        //{
        //    for (int j = i; j < n + i; j++)
        //    {
        //        Console.Write(j + " ");
        //    }

        //    Console.WriteLine();
        //}
    }
}
