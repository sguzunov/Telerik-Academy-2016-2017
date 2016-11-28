using System;

namespace OrderedSubsets
{
    public class Startup
    {
        public static void Main()
        {
            Console.Write("K = ");
            int k = int.Parse(Console.ReadLine());
            Console.Write("N = ");
            int n = int.Parse(Console.ReadLine());

            GenerateOrderedKElementSubset(0, k, n, new int[k]);
        }

        private static void GenerateOrderedKElementSubset(int index, int k, int n, int[] variation)
        {
            if (k <= index)
            {
                Console.WriteLine(string.Join(" ", variation));
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                variation[index] = i;
                GenerateOrderedKElementSubset(index + 1, k, n, variation);
            }
        }
    }
}
