using System;

namespace NullValuesArithmetic
{
    class Program
    {
        static void Main()
        {
            int? nullableInt = null;
            double? nullableDouble = null;
            Console.WriteLine(nullableInt);
            Console.WriteLine(nullableDouble);

            nullableInt = 1;
            nullableDouble = 1.1;
            Console.WriteLine(nullableInt);
            Console.WriteLine(nullableDouble);
        }
    }
}
