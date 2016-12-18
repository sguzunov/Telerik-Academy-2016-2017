using System;
using System.Linq;

namespace SumOfCoins
{
    public class Startup
    {
        public static void Main()
        {
            Console.Write("Coins: ");
            var coins = Console.ReadLine().Split(' ').Select(int.Parse).OrderBy(x => x).ToArray();
            Console.Write("Desired sum: ");
            var desiredSum = int.Parse(Console.ReadLine());

            int currentSum = 0;
            int coinIndex = coins.Length - 1;
            while (currentSum < desiredSum)
            {
                while (desiredSum < (currentSum + coins[coinIndex]) && 0 < coinIndex)
                {
                    coinIndex--;
                }

                if (coinIndex < 0) break;

                currentSum += coins[coinIndex];
            }

            Console.WriteLine("Sum possible -> {0}", currentSum == desiredSum);
        }
    }
}
