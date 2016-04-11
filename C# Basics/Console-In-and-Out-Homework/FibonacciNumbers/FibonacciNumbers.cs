using System;

/* Write a program that reads a number N and prints on the console the first N members of the Fibonacci sequence (at a single line, separated by comma and space - ", ") : 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, ….

 */
class FibonacciNumbers
{
    static void Main()
    {
        byte n = byte.Parse(Console.ReadLine());

        ulong fib1 = 1;
        ulong fib2 = 0;
        Console.Write(fib2);
        if (n > 1)
        {
            for (int i = 0; i < n - 1; i++)
            {
                Console.Write(", {0}", fib1);
                fib1 = fib1 + fib2;
                fib2 = fib1 - fib2;
            }
        }
    }
}
