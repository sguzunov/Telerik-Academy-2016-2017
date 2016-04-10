namespace OddOrEven
{
    using System;

    /*
        Write a program that reads an integer from the console, uses an expression to check if given integer is odd or even, and prints "even NUMBER" or "odd NUMBER", where you should print the input number's value instead of NUMBER.
    */
    class Program
    {
        static void Main()
        {
            sbyte number = sbyte.Parse(Console.ReadLine());

            bool isEvenNumber = false;

            // Using bitwise operations.
            byte mask = 1;
            byte firstBit = (byte)(number & mask);
            isEvenNumber = firstBit == 0 ? true : false;

            // Check if has remainder devided by 2.
            //if (number % 2 == 0)
            //{
            //    isEvenNumber = true;
            //}

            if (isEvenNumber)
            {
                Console.WriteLine("even {0}", number);
            }
            else
            {
                Console.WriteLine("odd {0}", number);
            }
        }
    }
}
