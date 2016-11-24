// Write a recursive program that simulates the execution of n nested loopsfrom 1 to n.

using System;

namespace NestedLoops
{
    public class Startup
    {
        public static void Main()
        {
            Console.Write("Numebrs of loops: ");
            int numberOfLoops = int.Parse(Console.ReadLine());
            int[] numbers = new int[numberOfLoops];

            Loop(0, numberOfLoops, numbers);
        }

        private static void Loop(int index, int n, int[] numbers)
        {
            if (n <= index)
            {
                Console.WriteLine(string.Join(" ", numbers));
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                numbers[index] = i;
                Loop(index + 1, n, numbers);
            }
        }
    }
}
