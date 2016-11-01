using System;
using System.Collections.Generic;
using System.Linq;

using NorthwindDB.Models;

namespace SalesByRegionAndPeriod
{
    public class Startup
    {
        private static void Main()
        {
            var periodStart = new DateTime(1995, 11, 11);
            var periodEnd = new DateTime(1998, 11, 11);
            var sales = FindSalesByRegionAndPeriod("SP", periodStart, periodEnd);

            Console.WriteLine(sales.Count());
        }

        private static IEnumerable<Order> FindSalesByRegionAndPeriod(string region, DateTime start, DateTime end)
        {
            using (var dbContext = new NorthwindEntities())
            {
                var sales = dbContext.Orders
                    .Where(o => o.OrderDate >= start &&
                    o.ShippedDate <= end &&
                    o.ShipRegion == region)
                    .ToList();

                return sales;
            }
        }
    }
}
