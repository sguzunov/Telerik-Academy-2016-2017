using System;
using System.Text;

namespace IsoscelesTriangle
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            char copyRightSymbol = '\u00A9';
            Console.WriteLine("   " + copyRightSymbol);
            Console.WriteLine("  " + copyRightSymbol + " " + copyRightSymbol);
            Console.WriteLine(" " + copyRightSymbol + "   " + copyRightSymbol);
            Console.WriteLine(copyRightSymbol + " " + copyRightSymbol + " " + copyRightSymbol + " " + copyRightSymbol);
        }
    }
}
