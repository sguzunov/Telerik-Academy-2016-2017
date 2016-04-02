using System;

namespace DeclareVariables
{
    class Program
    {
        static void Main()
        {
            ushort ushortVariable = 52130;
            sbyte sbyteVariable = -115;
            uint uintVariable = 4825932;
            byte byteVariable = 97;
            short shortVariable = -10000;

            Console.WriteLine("{0} number is suitable for type of ushort.", ushortVariable);
            Console.WriteLine("{0} number is suitable for type of sbyte.", sbyteVariable);
            Console.WriteLine("{0} number is suitable for type of uint.", uintVariable);
            Console.WriteLine("{0} number is suitable for type of byte.", byteVariable);
            Console.WriteLine("{0} number is suitable for type of short.", shortVariable);
        }
    }
}
