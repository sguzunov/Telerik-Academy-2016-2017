namespace MathsComparison
{
    using System;
    using System.Diagnostics;

    public class MathOperationTimer
    {
        public TimeSpan CalculateExecutionTime<T>(Func<T, T, T> operation, int operationsCount)
        {
            var watch = new Stopwatch();

            watch.Start();

            T number = default(T);
            for (int i = 0; i < operationsCount; i++)
            {
                number = operation(number, number);
            }

            watch.Stop();
            var executionTime = watch.Elapsed;

            return executionTime;
        }

        public TimeSpan CalculateExecutionTime<T>(Func<T, T> operation, int operationsCount)
        {
            var watch = new Stopwatch();

            watch.Start();

            T number = default(T);
            for (int i = 0; i < operationsCount; i++)
            {
                number = operation(number);
            }

            watch.Stop();
            var executionTime = watch.Elapsed;

            return executionTime;
        }
    }
}
