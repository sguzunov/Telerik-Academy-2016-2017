namespace SumOfEvenDivisors
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            long totalSumOfDivisors = 0;
            for (int number = firstNumber; number <= secondNumber; number++)
            {
                long sumOfDivisors = 0;
                for (int candidateDivisor = 1; candidateDivisor <= number; candidateDivisor++)
                {
                    bool isDivisor = number % candidateDivisor == 0;
                    bool divisorIsEven = candidateDivisor % 2 == 0;
                    if (isDivisor && divisorIsEven)
                    {
                        sumOfDivisors += candidateDivisor;
                    }
                }

                totalSumOfDivisors += sumOfDivisors;
            }

            Console.WriteLine(totalSumOfDivisors);
        }
    }
}
