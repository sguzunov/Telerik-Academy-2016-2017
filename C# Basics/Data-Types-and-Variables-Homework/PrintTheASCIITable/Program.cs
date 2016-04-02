using System;

namespace PrintTheASCIITable
{
    class Program
    {
        static void Main()
        {
            for (int i = 33; i <= 126; i++)
            {
                char symbol = (char)i;
                Console.Write(symbol);
            }
        }
    }
}
