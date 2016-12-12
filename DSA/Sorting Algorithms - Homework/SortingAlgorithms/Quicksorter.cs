namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.QuickSort(collection, 0, collection.Count);
        }

        private void QuickSort(IList<T> collection, int left, int right)
        {
            if (left < right)
            {
                var pivotIndex = this.Partition(collection, left, right);
                QuickSort(collection, left, pivotIndex);
                QuickSort(collection, pivotIndex + 1, right);
            }
        }

        private int Partition(IList<T> collection, int left, int right)
        {
            var pivot = collection[left];
            var store = left + 1;

            for (int i = store; i < right; i++)
            {
                if (collection[i].CompareTo(pivot) <= 0)
                {
                    this.Swap(collection, store, i);
                    store++;
                }
            }

            store--;
            this.Swap(collection, left, store);

            return store;
        }

        private void Swap(IList<T> collection, int from, int to)
        {
            var oldValue = collection[from];
            collection[from] = collection[to];
            collection[to] = oldValue;
        }
    }
}
