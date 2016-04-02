using System;

namespace ExchangeVariableValues
{
    class Program
    {
        static void Main()
        {
            int a = 10;
            int b = 5;

            // Changing values
            a = a + b;
            b = a - b;
            a = a - b;

            Console.WriteLine("a = {0}", a);
            Console.WriteLine("b = {0}", b);
        }
    }
}
