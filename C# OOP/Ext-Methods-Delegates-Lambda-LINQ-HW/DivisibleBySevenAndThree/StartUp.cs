namespace DivisibleBySevenAndThree
{

    // Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. Use the built-in extension methods and lambda expressions. 
    // Rewrite the same with LINQ.

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class StartUp
    {
        static void Main()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 21, 63 };

            numbers.Where(x => x % 7 == 0 && x % 3 == 0).ToList().ForEach(Console.WriteLine);
        }
    }
}
