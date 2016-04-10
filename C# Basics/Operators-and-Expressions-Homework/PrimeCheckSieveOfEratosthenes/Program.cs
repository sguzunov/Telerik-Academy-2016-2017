namespace PrimeCheckSieveOfEratosthenes
{
    using System;

    class Program
    {
        private static bool[] numbers;

        static void Main()
        {
            int rangeNumber = int.Parse(Console.ReadLine());
            numbers = new bool[rangeNumber + 1];
            Sieve();
            PrintPrimesInRange();
        }

        private static void PrintPrimesInRange()
        {
            for (int i = 2; i < numbers.Length; i++)
            {
                if (numbers[i] == false)
                {
                    Console.WriteLine(i);
                }
            }
        }

        static void Sieve()
        {
            int i = 2;
            while (i < numbers.Length)
            {
                if (numbers[i] == false)
                {
                    int j = i + i;
                    while (j < numbers.Length)
                    {
                        numbers[j] = true;
                        j += i;
                    }
                }

                i++;
            }
        }
    }
}
