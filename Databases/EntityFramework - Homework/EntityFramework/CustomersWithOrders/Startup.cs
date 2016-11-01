using System;
using System.Collections.Generic;
using System.Linq;
using NorthwindDB.Models;

namespace CustomersWithOrders
{
    public class Startup
    {
        private static void Main()
        {
            Console.WriteLine(GetCustomersWithOrders(1997, "Canada").Count());
            Console.WriteLine(GetCustomersWithOrdersSQL(1997, "Canada").Count());
        }

        private static IEnumerable<Customer> GetCustomersWithOrders(int year, string shipCountry)
        {
            using (NorthwindEntities dbContext = new NorthwindEntities())
            {
                var customers = dbContext
                    .Customers
                    .Where(
                    c => c.Orders.Any(o => o.ShipCountry == shipCountry && o.OrderDate.Value.Year == year))
                    .ToList();

                return customers;
            }
        }

        private static IEnumerable<Customer> GetCustomersWithOrdersSQL(int year, string shipCountry)
        {
            using (NorthwindEntities dbContext = new NorthwindEntities())
            {
                string query = "SELECT * " +
                    "FROM customers " +
                    "WHERE CustomerID IN " +
                    "(SELECT DISTINCT CustomerID " +
                    "FROM Orders " +
                    "WHERE ShipCountry = {0} AND YEAR(OrderDate) = {1});";

                var customers = dbContext.Database.SqlQuery<Customer>(query, shipCountry, year).ToList();
                return customers;
            }
        }
    }
}
