namespace BitSwap
{
    /* Write a program first reads 3 numbers n, p, q and k and than swaps bits {p, p+1, …, p+k-1} with bits {q, q+1, …, q+k-1} of n. Print the resulting integer on the console. */

    using System;

    class Program
    {
        static void Main()
        {
            uint number = uint.Parse(Console.ReadLine());
            int frontBitPosition = int.Parse(Console.ReadLine());
            int endBitPosition = int.Parse(Console.ReadLine());
            uint k = uint.Parse(Console.ReadLine());

            //Console.WriteLine(Convert.ToString(n, 2).PadLeft(32, '0'));

            for (int i = 0; i < k; i++)
            {
                uint frontBit = (number >> frontBitPosition) & 1;
                uint endBit = (number >> endBitPosition) & 1;
                if (frontBit != endBit)
                {
                    if (frontBit == 1)
                    {
                        number = number & (uint)(~(1 << frontBitPosition));
                        number = number | (uint)(1 << endBitPosition);
                    }
                    else
                    {
                        number = number | (uint)(1 << frontBitPosition);
                        number = number & (uint)(~(1 << endBitPosition));
                    }
                }

                frontBitPosition++;
                endBitPosition++;
            }

            Console.WriteLine(number);
        }
    }
}
