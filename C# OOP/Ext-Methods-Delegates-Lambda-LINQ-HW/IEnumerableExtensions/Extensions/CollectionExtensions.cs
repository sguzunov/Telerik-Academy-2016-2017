namespace EnumerableExtensions.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // TODO: Implement in a better way.
    internal static class CollectionExtensions
    {
        private const string EmptyCollectionErrorMessage = "Collection is empty!";

        internal static T Sum<T>(this IEnumerable<T> collection) where T : struct
        {
            if (collection.Count() == 0)
            {
                throw new ArgumentException(EmptyCollectionErrorMessage);
            }

            T sum = (dynamic)0;
            foreach (var item in collection)
            {
                sum += (dynamic)item;
            }

            return sum;
        }

        internal static T Muliply<T>(this IEnumerable<T> collection) where T : struct
        {
            if (collection.Count() == 0)
            {
                throw new ArgumentException(EmptyCollectionErrorMessage);
            }

            T product = (dynamic)1;
            foreach (var item in collection)
            {
                product *= (dynamic)item;
            }

            return product;
        }

        internal static T Min<T>(this IEnumerable<T> collection) where T : IComparable<T>
        {
            if (collection.Count() == 0)
            {
                throw new ArgumentException(EmptyCollectionErrorMessage);
            }

            T min = collection.First();
            foreach (var item in collection)
            {
                if (min.CompareTo(item) > 0)
                {
                    min = item;
                }
            }

            return min;
        }

        internal static T Max<T>(this IEnumerable<T> collection) where T : IComparable<T>
        {
            if (collection.Count() == 0)
            {
                throw new ArgumentException(EmptyCollectionErrorMessage);
            }

            T max = collection.First();
            foreach (var item in collection)
            {
                if (max.CompareTo(item) < 0)
                {
                    max = item;
                }
            }

            return max;
        }

        //internal static T Average<T>(this IEnumerable<T> collection) where T : IComparable<T>
        //{
        //    if (collection.Count() == 0)
        //    {
        //        throw new ArgumentException(EmptyCollectionErrorMessage);
        //    }

        //    T sum = (dynamic)0;
        //    foreach (var item in collection)
        //    {

        //    }

        //    return max;
        //}
    }
}
