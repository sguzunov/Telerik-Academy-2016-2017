using System;
using System.Linq;

namespace Lazyness
{
    public class Startup
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var ab = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int startIndex = ab[0];
            int endIndex = ab[1];

            QuickSort(numbers, startIndex, endIndex + 1);
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void QuickSort(int[] numbers, int left, int right)
        {
            if (left < right)
            {
                var pivotIndex = Partition(numbers, left, right);
                QuickSort(numbers, left, pivotIndex);
                QuickSort(numbers, pivotIndex + 1, right);
            }
        }

        private static int Partition(int[] numbers, int left, int right)
        {
            var pivot = numbers[left];
            int store = left + 1;
            for (int i = store; i < right; i++)
            {
                if (numbers[i] <= pivot)
                {
                    Swap(numbers, store, i);
                    store++;
                }
            }

            store--;
            Swap(numbers, left, store);

            return store;
        }

        private static void Swap(int[] collection, int fromIndex, int toIndex)
        {
            var result = collection[fromIndex] ^ collection[toIndex];
            collection[fromIndex] = result ^ collection[fromIndex];
            collection[toIndex] = result ^ collection[fromIndex];
        }
    }
}
