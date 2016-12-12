using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sieve
{
    public class Startup
    {
        public static void Main()
        {
            var maxNum = int.Parse(Console.ReadLine());

            var numbers = new bool[maxNum + 1];
            ScratchNumbers(numbers, maxNum);
            FindLastScratchedNumber(numbers);
        }

        private static void FindLastScratchedNumber(bool[] numbers)
        {
            Console.WriteLine();
        }

        private static void ScratchNumbers(bool[] numbers, int maxNum)
        {
            for (int i = 2; i < maxNum; i++)
            {
                if (!numbers[i])
                {
                    for (int j = i * i; j < maxNum; j += i)
                    {
                        numbers[j] = true;
                    }
                }
            }
        }
    }
}
