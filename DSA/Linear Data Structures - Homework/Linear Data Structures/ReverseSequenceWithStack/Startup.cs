//Write a program that reads N integers from the console and reverses them using a stack. Use the Stack<int> class.

using System;
using System.Collections.Generic;

namespace ReverseSequenceWithStack
{
    public class Startup
    {
        private static void Main()
        {
            var numbers = ReadNumbers();
            PrintNumbers(numbers);
        }

        private static Stack<int> ReadNumbers()
        {
            var numbersAsString = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var numbers = new Stack<int>();
            foreach (var numString in numbersAsString)
            {
                int number = int.Parse(numString);
                numbers.Push(number);
            }

            return numbers;
        }

        private static void PrintNumbers(Stack<int> numbers)
        {
            while (numbers.Count > 0)
            {
                int number = numbers.Pop();
                Console.Write(number + " ");
            }

            Console.WriteLine();
        }
    }
}
