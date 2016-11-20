using System;
using System.Collections;
using System.Collections.Generic;

namespace MyCollections
{
    public class LinkedList<T> : IEnumerable<T>
    {
        private ListElement<T> lastElement;

        public LinkedList()
        {
            this.FirstElement = null;
            this.lastElement = null;
        }
        public ListElement<T> FirstElement { get; private set; }

        public int Count { get; private set; }

        public ListElement<T> Find(T key)
        {
            var currentElement = this.FirstElement;
            while (currentElement != null)
            {
                if (currentElement.Key.Equals(key))
                {
                    return currentElement;
                }
                currentElement = currentElement.NextElement;
            }

            return null;
        }

        public void InsertAt(int index, T key)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }

            var newElement = this.CreateElement(key);
            if (index == 0)
            {
                newElement.NextElement = this.FirstElement;
                this.FirstElement = newElement;
            }
            else
            {
                int i = 1;
                var currentElement = this.FirstElement;
                while (currentElement != null && i < index)
                {
                    currentElement = currentElement.NextElement;
                    i++;
                }

                newElement.NextElement = currentElement.NextElement;
                currentElement.NextElement = newElement;
            }

            this.Count++;
        }

        public void AddFirst(T key)
        {
            var newElement = this.CreateElement(key);
            if (this.IsEmpty())
            {
                this.lastElement = newElement;
            }

            newElement.NextElement = this.FirstElement;
            this.FirstElement = newElement;
            this.Count++;
        }

        public void AddLast(T key)
        {
            var newElement = this.CreateElement(key);
            if (this.IsEmpty())
            {
                this.FirstElement = newElement;
            }
            else
            {
                this.lastElement.NextElement = newElement;
            }

            this.lastElement = newElement;
            this.Count++;
        }

        public bool Contains(T key)
        {
            var element = this.Find(key);

            return key == null ? false : true;
        }

        public bool Remove(T key)
        {
            if (this.Contains(key))
            {
                return false;
            }

            if (this.Count == 1)
            {
                this.FirstElement = null;
                this.lastElement = null;
            }
            else
            {
                var currentElement = this.FirstElement;
                while (!currentElement.NextElement.Key.Equals(key))
                {
                    currentElement = currentElement.NextElement;
                }

                currentElement.NextElement = currentElement.NextElement.NextElement;
            }

            this.Count--;

            return true;
        }

        public void ForEach(Action<T> action)
        {
            foreach (var element in this)
            {
                action(element);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentElement = this.FirstElement;
            while (currentElement != null)
            {
                yield return currentElement.Key;
                currentElement = currentElement.NextElement;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private bool IsEmpty()
        {
            bool isEmpty = this.Count == 0;
            return isEmpty;
        }

        private ListElement<T> CreateElement(T key)
        {
            return new ListElement<T>(key);
        }
    }
}
