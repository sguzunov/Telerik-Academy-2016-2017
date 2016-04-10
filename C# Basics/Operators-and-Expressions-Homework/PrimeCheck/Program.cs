namespace PrimeCheck
{
    using System;

    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            bool isPrime = IsPrime(number);
            Console.WriteLine(isPrime.ToString().ToLower());
        }

        static bool IsPrime(int number)
        {
            if (number >= 2)
            {
                double maxDivider = Math.Sqrt(number);
                for (int i = 2; i <= maxDivider; i++)
                {
                    if (number % i == 0)
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
