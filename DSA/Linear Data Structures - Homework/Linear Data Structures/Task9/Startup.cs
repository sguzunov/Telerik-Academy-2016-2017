// S1 = N; S2 = S1 + 1; S3 = 2* S1 + 1; S4 = S1 + 2; S5 = S2 + 1; S6 = 2* S2 + 1; S7 = S2 + 2

using System;
using System.Collections.Generic;

namespace Task9
{
    public class Startup
    {
        public static void Main()
        {
            const int N = 50;

            var numbers = new Queue<int>();
            numbers.Enqueue(2);

            int i = 0;
            while (numbers.Count > 0)
            {
                if (i == N)
                {
                    break;
                }

                int number = numbers.Dequeue();
                numbers.Enqueue(number + 1);
                numbers.Enqueue(2 * number + 1);
                numbers.Enqueue(number + 2);

                Console.WriteLine(number);

                ++i;
            }
        }
    }
}
