namespace GenericsCollection
{
    using System;
    using System.Text;
    using VersionAttributeImplementation;

    [Version(0, 1)]
    public class GenericList<T> where T : IEquatable<T>, IComparable<T>
    {
        private const int DefaultCapacity = 4;
        private const string IndexOutOfBoundsErrorException = "Index was out of the bounds of the list!";
        private const string EmptyListErrorException = "List is empty!";

        private T[] elements;

        public GenericList(int capacity = DefaultCapacity)
        {
            this.Capacity = capacity;
            this.elements = new T[this.Capacity];
        }

        public int Count { get; private set; }

        public int Capacity { get; private set; }

        public T this[int index]
        {
            get
            {
                if (!this.IsIndexInRange(index))
                {
                    throw new IndexOutOfRangeException(IndexOutOfBoundsErrorException);
                }

                return this.elements[index];
            }

            set
            {
                if (!this.IsIndexInRange(index))
                {
                    throw new IndexOutOfRangeException(IndexOutOfBoundsErrorException);
                }

                this.elements[index] = value;
            }
        }

        public void Add(T element)
        {
            if (this.ShouldResize())
            {
                var oldValues = this.elements;
                this.Resize();
                this.CopyElementsFromTo(oldValues, this.elements, this.Count);
            }

            this.elements[this.Count] = element;
            this.Count++;
        }

        public void RemoveAt(int index)
        {
            if (this.IsEmpty())
            {
                throw new InvalidOperationException(EmptyListErrorException);
            }

            if (!this.IsIndexInRange(index))
            {
                throw new IndexOutOfRangeException(IndexOutOfBoundsErrorException);
            }

            var newElements = new T[this.Capacity];
            this.CopyElementsFromTo(this.elements, newElements, index);
            this.CopyElementsFromTo(this.elements, newElements, this.Count - index, index + 1, index);
            this.elements = newElements;
            this.Count--;
        }

        public void InsertAt(int index, T element)
        {
            if (this.IsEmpty())
            {
                throw new InvalidOperationException(EmptyListErrorException);
            }

            if (!this.IsIndexInRange(index))
            {
                throw new IndexOutOfRangeException(IndexOutOfBoundsErrorException);
            }

            var oldValues = this.elements;
            if (this.ShouldResize())
            {
                this.Resize();
            }

            this.CopyElementsFromTo(oldValues, this.elements, index);
            this.elements[index] = element;
            this.CopyElementsFromTo(oldValues, this.elements, this.Count - index, index, index + 1);
            this.Count++;
        }

        public void Clear()
        {
            this.elements = new T[this.Capacity];
            this.Count = 0;
        }

        public bool Find(T element)
        {
            if (this.IsEmpty())
            {
                throw new InvalidOperationException(EmptyListErrorException);
            }

            foreach (var item in this.elements)
            {
                if (element.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public T Min()
        {
            if (this.IsEmpty())
            {
                throw new InvalidOperationException(EmptyListErrorException);
            }

            int minIndex = 0;
            for (int i = 1; i < this.Count; i++)
            {
                if (this.elements[minIndex].CompareTo(this.elements[i]) > 0)
                {
                    minIndex = i;
                }
            }

            return this.elements[minIndex];
        }

        public T Max()
        {
            if (this.IsEmpty())
            {
                throw new InvalidOperationException(EmptyListErrorException);
            }

            int maxIndex = 0;
            for (int i = 1; i < this.Count; i++)
            {
                if (this.elements[maxIndex].CompareTo(this.elements[i]) < 0)
                {
                    maxIndex = i;
                }
            }

            return this.elements[maxIndex];
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            for (int i = 0; i < this.Count - 1; i++)
            {
                builder.Append($"{this.elements[i]}, ");
            }

            builder.Append(this.elements[this.Count - 1]);
            return builder.ToString();
        }

        private void Resize()
        {
            this.Capacity *= 2;
            this.elements = new T[this.Capacity];
        }

        private bool IsEmpty()
        {
            return this.Count == 0;
        }

        private void CopyElementsFromTo(T[] source, T[] destination, int length, int sourceIndex = 0, int destinationIndex = 0)
        {
            Array.Copy(source, sourceIndex, destination, destinationIndex, length);
        }

        private bool ShouldResize()
        {
            return this.Count >= this.elements.Length;
        }

        private bool IsIndexInRange(int index)
        {
            return index >= 0 && index < this.Count;
        }
    }
}
