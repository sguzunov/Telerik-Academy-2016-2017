using System;
using System.Numerics;

namespace CubicRoot
{
    public class Startup
    {
        public static void Main()
        {
            var number = BigInteger.Parse(Console.ReadLine());

            var result = FindCubicRoot(number);
            Console.WriteLine(result);
        }

        private static BigInteger FindCubicRoot(BigInteger number)
        {
            BigInteger left = 0;
            BigInteger right = number / 3;

            while (left < right)
            {
                var rootCandidate = (left + right) >> 1; // (left + right) / 2
                var cubicRoot = rootCandidate * rootCandidate * rootCandidate;
                if (cubicRoot > number)
                {
                    right = rootCandidate;
                }
                else if (cubicRoot < number)
                {
                    left = rootCandidate + 1;
                }
                else
                {
                    return rootCandidate;
                }
            }

            return -1;
        }
    }
}
