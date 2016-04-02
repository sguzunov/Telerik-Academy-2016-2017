namespace ComparingFloats
{
    using System;
    using System.Globalization;
    using System.Threading;

    class Program
    {
        private const double eps = 0.000001;

        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            double difference = Math.Abs(a - b);
            bool areEqual = difference < eps;
            Console.WriteLine(areEqual ? "true" : "false");
        }
    }
}
