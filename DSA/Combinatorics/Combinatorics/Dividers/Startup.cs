using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divisors
{
    public class Startup
    {
        private static int minimunDivisors = int.MaxValue;
        private static int solution = int.MaxValue;

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] digits = new int[n];
            for (int i = 0; i < n; i++)
            {
                digits[i] = int.Parse(Console.ReadLine());
            }

            PermuteDigits(digits, 0, 0, new bool[n]);

            //Console.WriteLine(minimunDivisors);
            Console.WriteLine(solution);
        }

        private static void PermuteDigits(int[] digits, int index, int number, bool[] used)
        {
            if (digits.Length <= index)
            {
                int numberOfDivisors = CountDivisors(number);
                if (numberOfDivisors < minimunDivisors)
                {
                    minimunDivisors = numberOfDivisors;
                    solution = number;
                }
                else if (numberOfDivisors == minimunDivisors && number < solution)
                {
                    solution = number;
                }

                return;
            }

            for (int i = 0; i < digits.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    PermuteDigits(digits, index + 1, number * 10 + digits[i], used);
                    used[i] = false;
                }
            }
        }

        private static int CountDivisors(int number)
        {
            int count = 0;
            for (int i = 1; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    if (number / i == i)
                    {
                        count++;
                    }
                    else
                    {
                        count += 2;
                    }
                }
            }

            return count;
        }
    }
}
