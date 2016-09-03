namespace Statistics
{
    using System;
    using System.Collections.Generic;

    public static class ArrayStatisticsPrinter
    {
        public static T PrintMax<T>(IList<T> elements, int count) where T : IComparable<T>
        {
            if (elements.Count == 0)
            {
                throw new ArgumentException($"{nameof(elements)} cannot be empty!");
            }

            if (count > elements.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            T maxFoundElement = elements[0];
            for (int i = 0; i < count; i++)
            {
                if (maxFoundElement.CompareTo(elements[i]) < 0)
                {
                    maxFoundElement = elements[i];
                }
            }

            return maxFoundElement;
        }

        public static T PrintMin<T>(IList<T> elements, int count) where T : IComparable<T>
        {
            if (elements.Count == 0)
            {
                throw new ArgumentException($"{nameof(elements)} cannot be empty!");
            }

            if (count > elements.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            T minFoundElement = elements[0];
            for (int i = 0; i < count; i++)
            {
                if (minFoundElement.CompareTo(elements[i]) > 0)
                {
                    minFoundElement = elements[i];
                }
            }

            return minFoundElement;
        }

        public static T PrintAverage<T>(IList<T> elements, int count) where T : IComparable<T>
        {
            if (elements.Count == 0)
            {
                throw new ArgumentException($"{nameof(elements)} cannot be empty!");
            }

            if (count > elements.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            dynamic sum = elements[0];
            foreach (var element in elements)
            {
                sum += element;
            }

            T average = (T)(sum / count);

            return average;
        }
    }
}
