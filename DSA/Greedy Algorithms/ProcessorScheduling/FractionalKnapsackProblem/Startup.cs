using System;
using System.Collections.Generic;
using System.Linq;

namespace FractionalKnapsackProblem
{
    public class Startup
    {
        public static void Main()
        {
            Console.Write("Knapsack Capacity: ");
            int capacity = int.Parse(Console.ReadLine());
            Console.Write("Items: ");
            int numberOfItems = int.Parse(Console.ReadLine());

            var items = new List<int[]>(); // price, weight
            for (int i = 0; i < numberOfItems; i++)
            {
                var item = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                items.Add(item);
            }

            Solve(items, capacity);
        }

        private static void Solve(List<int[]> items, int maxCapacity)
        {
            int capacity = 0;
            double totalPrice = 0.0;
            while (capacity < maxCapacity)
            {
                items = items.OrderBy(x => x[0] / (double)x[1]).ToList();
                int itemIndex = items.Count - 1;
                var optimalItem = items[itemIndex];

                int price = optimalItem[0];
                int weight = optimalItem[1];

                int neededWeight = maxCapacity - capacity;
                double percentage = 0.0;
                if (neededWeight >= weight)
                {
                    capacity += weight;
                    percentage = 100;
                    totalPrice += price;

                    // Clear
                    items.RemoveAt(itemIndex);
                }
                else
                {
                    capacity += neededWeight;
                    percentage = (neededWeight / (double)weight) * 100;
                    totalPrice += (price * percentage) / 100;
                    items[itemIndex][1] -= weight;
                }

                Console.WriteLine("Take {0:F2}% of item with price {1:F2} and weight {2}", percentage, price, weight);
            }

            Console.WriteLine("Total price: {0:F2}", totalPrice);
        }
    }
}
