using System;

namespace Goro
{
    public class Startup
    {
        public static void Main()
        {
            var numbers = new int[3];

            numbers[0] = int.Parse(Console.ReadLine());
            numbers[1] = int.Parse(Console.ReadLine());
            numbers[2] = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            var result = Solve(numbers, n);
            Console.WriteLine(result);
        }

        private static int Solve(int[] numbers, int n)
        {
            SortNumbers(numbers);

            int sum = 0;
            int maxNumberIndex = numbers.Length - 1;
            for (int i = 0; i < n; i++)
            {
                int sumCandidate = numbers[maxNumberIndex];
                sum += sumCandidate;
                if (sumCandidate >= 1)
                {
                    numbers[maxNumberIndex]--;
                    SortNumbers(numbers);
                }
            }

            return sum;
        }

        private static void SortNumbers(int[] numbers)
        {
            for (int i = 1; i < numbers.Length; i++)
            {
                int current = numbers[i];
                int j = i;
                while (j > 0 && numbers[j - 1] > numbers[j])
                {
                    Swap(numbers, j - 1, j);
                    j--;
                }
            }
        }

        private static void Swap(int[] numbers, int from, int to)
        {
            int result = numbers[from] ^ numbers[to];
            numbers[from] = result ^ numbers[from];
            numbers[to] = result ^ numbers[to];
        }
    }
}
