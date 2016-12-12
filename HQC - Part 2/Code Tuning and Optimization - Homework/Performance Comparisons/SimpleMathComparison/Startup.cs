namespace MathsComparison
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            const int TestsCount = 5;
            const int OperationsCount = 1000000;

            var performanceComparator = new MathOperationTimer();

            for (int i = 0; i < TestsCount; i++)
            {
                Console.WriteLine($"---------- Test {i + 1} ----------");
                TestInteger32(performanceComparator, OperationsCount);
                //TestInteger64(performanceComparator, OperationsCount);
                //TestSingle(performanceComparator, OperationsCount);
                //TestDouble(performanceComparator, OperationsCount);
                //TestDecimal(performanceComparator, OperationsCount);
            }
        }

        // Task: Compare simple maths.
        private static void TestInteger32(MathOperationTimer performanceComparator, int operationsCount)
        {
            Console.WriteLine("Addition (int): {0}", performanceComparator.CalculateExecutionTime<int>((x, y) => x + y, operationsCount));
            Console.WriteLine("Subtraction (int): {0}", performanceComparator.CalculateExecutionTime<int>((x, y) => x - y, operationsCount));
            Console.WriteLine("Multiplication (int): {0}", performanceComparator.CalculateExecutionTime<int>((x, y) => x * y, operationsCount));
            Console.WriteLine("Division (int): {0}", performanceComparator.CalculateExecutionTime<int>((x) => x / 1, operationsCount));
            Console.WriteLine("Incrementation (int): {0}", performanceComparator.CalculateExecutionTime<int>((x) => x++, operationsCount));
        }

        private static void TestInteger64(MathOperationTimer performanceComparator, int operationsCount)
        {
            Console.WriteLine("Addition (long): {0}", performanceComparator.CalculateExecutionTime<long>((x, y) => x + y, operationsCount));
            Console.WriteLine("Subtraction (long): {0}", performanceComparator.CalculateExecutionTime<long>((x, y) => x - y, operationsCount));
            Console.WriteLine("Multiplication (long): {0}", performanceComparator.CalculateExecutionTime<long>((x, y) => x * y, operationsCount));
            Console.WriteLine("Division (long): {0}", performanceComparator.CalculateExecutionTime<long>((x) => x / 1, operationsCount));
            Console.WriteLine("Incrementation (long): {0}", performanceComparator.CalculateExecutionTime<long>((x) => x++, operationsCount));
        }

        private static void TestSingle(MathOperationTimer performanceComparator, int operationsCount)
        {
            Console.WriteLine("Addition (float): {0}", performanceComparator.CalculateExecutionTime<float>((x, y) => x + y, operationsCount));
            Console.WriteLine("Subtraction (float): {0}", performanceComparator.CalculateExecutionTime<float>((x, y) => x - y, operationsCount));
            Console.WriteLine("Multiplication (float): {0}", performanceComparator.CalculateExecutionTime<float>((x, y) => x * y, operationsCount));
            Console.WriteLine("Division (float): {0}", performanceComparator.CalculateExecutionTime<float>((x) => x / 1, operationsCount));
            Console.WriteLine("Incrementation (float): {0}", performanceComparator.CalculateExecutionTime<float>((x) => x++, operationsCount));
        }

        private static void TestDouble(MathOperationTimer performanceComparator, int operationsCount)
        {
            Console.WriteLine("Addition (double): {0}", performanceComparator.CalculateExecutionTime<double>((x, y) => x + y, operationsCount));
            Console.WriteLine("Subtraction (double): {0}", performanceComparator.CalculateExecutionTime<double>((x, y) => x - y, operationsCount));
            Console.WriteLine("Multiplication (double): {0}", performanceComparator.CalculateExecutionTime<double>((x, y) => x * y, operationsCount));
            Console.WriteLine("Division (double): {0}", performanceComparator.CalculateExecutionTime<double>((x) => x / 1, operationsCount));
            Console.WriteLine("Incrementation (double): {0}", performanceComparator.CalculateExecutionTime<double>((x) => x++, operationsCount));
        }

        private static void TestDecimal(MathOperationTimer performanceComparator, int operationsCount)
        {
            Console.WriteLine("Addition (decimal): {0}", performanceComparator.CalculateExecutionTime<decimal>((x, y) => x + y, operationsCount));
            Console.WriteLine("Subtraction (decimal): {0}", performanceComparator.CalculateExecutionTime<decimal>((x, y) => x - y, operationsCount));
            Console.WriteLine("Multiplication (decimal): {0}", performanceComparator.CalculateExecutionTime<decimal>((x, y) => x * y, operationsCount));
            Console.WriteLine("Division (decimal): {0}", performanceComparator.CalculateExecutionTime<decimal>((x) => x / 1, operationsCount));
            Console.WriteLine("Incrementation (decimal): {0}", performanceComparator.CalculateExecutionTime<decimal>((x) => x++, operationsCount));
        }
    }
}
