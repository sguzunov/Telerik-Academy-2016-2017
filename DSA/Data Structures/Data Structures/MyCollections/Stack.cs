using System;
using System.Collections;
using System.Collections.Generic;

namespace MyCollections
{
    public class Stack<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 8;

        private int capacity;
        private int topIndex;
        private T[] elements;

        public Stack(int capacity = InitialCapacity)
        {
            this.Capacity = capacity;

            this.Count = 0;
            this.topIndex = -1;
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

        public T Peek()
        {
            if (this.IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            T element = this.elements[this.topIndex];

            return element;
        }

        public T Pop()
        {
            if (this.IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            var element = this.elements[this.topIndex];
            this.topIndex--;
            this.Count--;

            return element;
        }

        // Test what happens with capacity!!!
        public void Push(T element)
        {
            if (this.Count + 1 >= this.Capacity)
            {
                this.Resize();
            }

            this.topIndex++;
            this.elements[this.topIndex] = element;
            this.Count++;
        }

        public bool Contains(T element)
        {
            foreach (var elementInCollection in this.elements)
            {
                if (elementInCollection.Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public T[] ToArray()
        {
            T[] result = new T[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                result[i] = this.elements[i];
            }

            return result;
        }

        public void Clear()
        {
            this.Count = 0;
            this.Capacity = InitialCapacity;
            this.elements = new T[this.Capacity];
        }

        private void Resize()
        {
            this.Capacity *= 2;
            T[] newElements = new T[this.Capacity];
            for (int i = 0; i < this.Count; i++)
            {
                newElements[i] = this.elements[i];
            }

            this.elements = newElements;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in this.elements)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private bool IsEmpty()
        {
            return this.Count == 0;
        }
    }
}
