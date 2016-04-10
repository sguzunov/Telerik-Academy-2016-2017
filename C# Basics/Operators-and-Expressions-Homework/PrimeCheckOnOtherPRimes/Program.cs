namespace PrimeCheckOnOtherPRimes
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        private static IList<int> firstPrimes = new List<int>() { 2, 3, 5, 7, 9, 11, 13, 17, 19 };

        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            bool isPrime = IsPrime(number);
            Console.WriteLine(isPrime);
        }

        private static bool IsPrime(int number)
        {
            int foundPrimesCount = firstPrimes.Count;
            double maxDivider = Math.Sqrt(number);
            int i = 0;
            int prime = firstPrimes[i];
            bool isPrime = true;
            while (i < foundPrimesCount && prime <= maxDivider)
            {
                if (number % prime == 0)
                {
                    isPrime = false;
                    break;
                }

                i++;
                prime = firstPrimes[i];
            }

            if (isPrime && !firstPrimes.Contains(number))
            {
                firstPrimes.Add(number);
            }

            return isPrime;
        }
    }
}
