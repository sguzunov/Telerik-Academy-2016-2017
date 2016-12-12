namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class BubbleSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.BubbleSort(collection);
        }

        private void BubbleSort(IList<T> collection)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                bool hasSwaped = false;
                for (int j = collection.Count - 1; j > i; j--)
                {
                    var leftElement = collection[j - 1];
                    var rightElement = collection[j];
                    if (leftElement.CompareTo(rightElement) > 0)
                    {
                        this.Swap(collection, j - 1, j);
                        hasSwaped = true;
                    }
                }

                if (!hasSwaped)
                {
                    break;
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
