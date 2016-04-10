namespace NthBit
{
    /* Write a program that reads from the console two integer numbers P and N and prints on the console the value of P's N-th bit. */

    using System;

    class Program
    {
        static void Main()
        {
            ulong number = ulong.Parse(Console.ReadLine());
            int position = int.Parse(Console.ReadLine());

            ulong bit = (number >> position) & 1;
            Console.WriteLine(bit);
        }
    }
}
