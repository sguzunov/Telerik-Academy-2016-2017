using System;
using System.Collections;
using System.Collections.Generic;

namespace MyCollections
{
    public class Queue<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 8;

        private int headIndex;
        private int tailIndex;
        private int capacity;
        private T[] elements;

        public Queue(int capacity = InitialCapacity)
        {
            this.Capacity = capacity;

            this.Count = 0;
            this.headIndex = 0;
            this.tailIndex = 0;
            this.elements = new T[this.Capacity];
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Capacity must be a number greater than 0!");
                }

                this.capacity = value;
            }
        }

        public int Count { get; private set; }

        public void Enqueue(T element)
        {
            if (this.ShouldResize())
            {
                this.Resize();
            }

            this.elements[tailIndex] = element;
            this.tailIndex = (this.tailIndex + 1) % this.elements.Length;
            this.Count++;
        }

        // Test
        public T Dequeue()
        {
            if (this.IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty!");
            }

            var element = this.elements[this.headIndex];
            this.headIndex = (this.headIndex + 1) % this.elements.Length;
            this.Count--;

            return element;
        }

        // Test
        public T Peek()
        {
            if (this.IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty!");
            }

            var element = this.elements[this.headIndex];

            return element;
        }

        public bool Contains(T element)
        {
            foreach (var elementInCollection in this)
            {
                if (element.Equals(elementInCollection))
                {
                    return true;
                }
            }

            return false;
        }

        public void Clear()
        {
            this.Count = 0;
            this.Capacity = InitialCapacity;
            this.elements = new T[this.Capacity];
        }

        public IEnumerator<T> GetEnumerator()
        {
            int index = this.headIndex;
            while (index < this.tailIndex)
            {
                yield return this.elements[index];
                index++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private bool ShouldResize()
        {
            return !this.IsEmpty() && this.headIndex == ((this.tailIndex + 1) % this.elements.Length);
        }

        private void Resize()
        {
            var newElements = new T[this.Capacity * 2];
            int i = 0;
            foreach (var element in this)
            {
                newElements[i] = element;
                i++;
            }

            this.Capacity *= 2;
            this.headIndex = 0;
            this.tailIndex = this.Count;
            this.elements = newElements;
        }

        private bool IsEmpty()
        {
            return this.Count == 0;
        }
    }
}
