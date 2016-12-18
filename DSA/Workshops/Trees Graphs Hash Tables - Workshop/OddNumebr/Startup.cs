using System;

namespace OddNumebr
{
    public class Startup
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var result = long.Parse(Console.ReadLine());
            for (int i = 0; i < n - 1; i++)
            {
                result ^= long.Parse(Console.ReadLine());
            }

            Console.WriteLine(result);
        }
    }
}
