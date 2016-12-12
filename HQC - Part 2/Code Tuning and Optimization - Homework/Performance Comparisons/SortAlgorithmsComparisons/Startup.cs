using System;
using System.Collections.Generic;

namespace SortAlgorithmsComparisons
{
    public class Startup
    {
        public static void Main()
        {
            IList<IComparable> elements = new List<IComparable> { 3, 1, 5, 8, 2, 9, 7, 9, 7 };
            SelectionSort(elements);
            Console.WriteLine(string.Join(" ", elements));
        }

        private static void InsertionsSort(IList<IComparable> elements)
        {
            for (int i = 1; i < elements.Count; i++)
            {
                int j = i;
                var candidateToBeSorted = elements[i];
                while (j > 0 && elements[j - 1].CompareTo(elements[j]) > 0)
                {
                    SwapElements(j, j - 1, elements);
                    j--;
                }
            }
        }

        private static void SelectionSort(IList<IComparable> elements)
        {
            for (int i = 0; i < elements.Count - 1; i++)
            {
                int minElementIndex = i;
                for (int j = i + 1; j < elements.Count; j++)
                {
                    if (elements[minElementIndex].CompareTo(elements[j]) > 0)
                    {
                        minElementIndex = j;
                    }
                }

                if (minElementIndex != i)
                {
                    SwapElements(i, minElementIndex, elements);
                }
            }
        }

        private static void QuickSort(IList<IComparable> elements)
        {

        }

        private static void SwapElements<T>(int from, int to, IList<T> elements)
        {
            var oldValue = elements[from];
            elements[from] = elements[to];
            elements[to] = oldValue;
        }
    }
}
