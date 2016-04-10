namespace ModifyBit
{
    /* We are given an integer number N (read from the console), a bit value v (read from the console as well) (v = 0 or 1) and a position P (read from the console). Write a sequence of operators (a few lines of C# code) that modifies N to hold the value v at the position P from the binary representation of N while preserving all other bits in N. Print the resulting number on the console. */

    using System;

    class Program
    {
        static void Main()
        {
            ulong number = ulong.Parse(Console.ReadLine());
            int position = int.Parse(Console.ReadLine());
            int value = int.Parse(Console.ReadLine());

            ulong bit = (number >> position) & 1;
            if (bit == 1)
            {
                if (value == 0)
                {
                    number = number & (~(1u << position));
                }
            }
            else
            {
                if (value == 1)
                {
                    number = number | (1u << position);
                }
            }

            Console.WriteLine(number);
        }
    }
}
