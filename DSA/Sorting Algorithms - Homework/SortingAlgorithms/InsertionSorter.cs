namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class InsertionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.InsertionSort(collection);
        }

        private void InsertionSort(IList<T> collection)
        {
            for (int i = 1; i < collection.Count; i++)
            {
                int j = i;
                while (j > 0 && collection[j - 1].CompareTo(collection[j]) > 0)
                {
                    Swap(collection, j - 1, j);
                    j--;
                }
            }
        }

        private void Swap(IList<T> collection, int fromIndex, int toIndex)
        {
            var oldValue = collection[fromIndex];
            collection[fromIndex] = collection[toIndex];
            collection[toIndex] = oldValue;
        }
    }
}
