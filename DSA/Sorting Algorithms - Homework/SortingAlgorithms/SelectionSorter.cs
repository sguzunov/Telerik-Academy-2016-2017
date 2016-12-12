namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                int minElementIndex = i;
                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[minElementIndex].CompareTo(collection[j]) >= 0)
                    {
                        minElementIndex = j;
                    }
                }

                if (minElementIndex != i)
                {
                    Swap(i, minElementIndex, collection);
                }
            }
        }

        private static void Swap(int fromIndex, int toIndex, IList<T> collection)
        {
            var oldValue = collection[fromIndex];
            collection[fromIndex] = collection[toIndex];
            collection[toIndex] = oldValue;
        }
    }
}
