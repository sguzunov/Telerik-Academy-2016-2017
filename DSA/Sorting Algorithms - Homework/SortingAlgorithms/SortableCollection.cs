namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            for (int i = 0; i < this.Items.Count; i++)
            {
                if (this.Items[i].CompareTo(item) == 0) return true;
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            int leftIndex = 0;
            int rightIndex = this.items.Count - 1;

            while (leftIndex <= rightIndex)
            {
                int midIndex = (rightIndex + leftIndex) / 2;
                T middle = this.Items[midIndex];
                if (item.CompareTo(middle) < 0)
                {
                    rightIndex = midIndex - 1;
                }
                else
                {
                    leftIndex = midIndex + 1;
                }
            }

            return this.Items[rightIndex].CompareTo(item) == 0;
        }

        public void Shuffle()
        {
            var random = new Random();
            for (int i = 0; i < this.Items.Count - 1; i++)
            {
                int randomIndex = random.Next(i + 1, this.Items.Count);
                var oldValue = this.Items[i];
                this.Items[i] = this.Items[randomIndex];
                this.Items[randomIndex] = oldValue;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
