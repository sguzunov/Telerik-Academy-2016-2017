namespace SortAlgorithmsComparisons
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class SortPerformanceTimer<T>
    {
        public TimeSpan CalculateExecutionTime(Action<IList<IComparable>> sorter, IList<IComparable> elements)
        {
            var watch = new Stopwatch();

            watch.Start();
            sorter(elements);
            watch.Stop();

            var executionTime = watch.Elapsed;

            return executionTime;
        }
    }
}
