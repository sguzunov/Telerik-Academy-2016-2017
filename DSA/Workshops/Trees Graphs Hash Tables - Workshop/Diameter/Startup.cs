using System;
using System.Collections.Generic;
using System.Linq;

namespace Diameter
{
    public class Startup
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var matrix = ReadTree(n);


        }

        private static void Print(int[,] matrix, int n)
        {
            Console.WriteLine();
            Console.Write("   ");
            for (int i = 0; i < n; i++)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                Console.Write(i + "  ");
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        private static int[,] ReadTree(int n)
        {
            var matrix = new int[n, n];
            for (int i = 0; i < n - 1; i++)
            {
                var tokens = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                int from = tokens[0];
                int to = tokens[1];
                int distance = tokens[2];

                matrix[from, to] = distance;
                matrix[to, from] = distance;
            }

            return matrix;
        }
    }
}
