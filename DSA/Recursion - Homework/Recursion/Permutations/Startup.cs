using System;

namespace Permutations
{
    public class Startup
    {
        public static void Main()
        {
            Console.Write("N = ");
            int n = int.Parse(Console.ReadLine());

            GeneratePermutations(0, n, new int[n], new bool[n + 1]);
        }

        private static void GeneratePermutations(int index, int n, int[] permutation, bool[] used)
        {
            if (n <= index)
            {
                Console.WriteLine(string.Join(" ", permutation));
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    permutation[index] = i;
                    GeneratePermutations(index + 1, n, permutation, used);
                    used[i] = false;
                }
            }
        }
    }
}
