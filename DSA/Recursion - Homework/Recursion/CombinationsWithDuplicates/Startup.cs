// Write a recursive program for generating and printing all the combinations WITH duplicatesof k elements from n-element set.
// n=3, k=2 → (1 1), (1 2), (1 3), (2 2), (2 3), (3 3)

using System;

namespace CombinationsWithDuplicates
{
    public class Startup
    {
        public static void Main()
        {
            Console.Write("K elements: ");
            int k = int.Parse(Console.ReadLine());
            Console.Write("N-element set: ");
            int n = int.Parse(Console.ReadLine());

            GenerateCombinationsWithDuplicates(0, 1, k, n, new int[k]);
        }

        private static void GenerateCombinationsWithDuplicates(int index, int start, int k, int n, int[] combinations)
        {
            if (k <= index)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = start; i <= n; i++)
            {
                combinations[index] = i;
                GenerateCombinationsWithDuplicates(index + 1, i, k, n, combinations);
            }
        }
    }
}
