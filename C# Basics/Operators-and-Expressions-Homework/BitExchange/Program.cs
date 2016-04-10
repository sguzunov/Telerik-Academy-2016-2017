namespace BitExchange
{
    // Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer(read from the console).

    using System;

    class Program
    {
        static void Main()
        {
            uint number = uint.Parse(Console.ReadLine());

            int frontBitPosition = 3;
            int endBitPosition = 24;

            // Exchanging bits.
            for (int i = 0; i < 3; i++)
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
