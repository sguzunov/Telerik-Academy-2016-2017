using System;

using NorthwindDB.Models;

namespace CustomersDAO
{
    public class Startup
    {
        private static void Main()
        {
            // Uncomment to check step by step.

            // Adding test
            var customerToAdd = new Customer
            {
                CustomerID = "AAAAA",
                CompanyName = "Telerik",
            };
            //CustomersDAO.Insert(customerToAdd);

            var customerById = CustomersDAO.GetById("AAAAA");
            Console.WriteLine($"Customer id: {customerById.CustomerID}, Company name: {customerById.CompanyName}");

            // Updaing test
            var costomerToUpdate = new Customer
            {
                CustomerID = "AAAAA",
                CompanyName = "Telerik Academy",
            };
            //CustomersDAO.Update(costomerToUpdate);

            // Deleting test
            //CustomersDAO.Delete("AAAAA");

            var customerToDelete = new Customer
            {
                CustomerID = "AAAAA"
            };
            //CustomersDAO.Delete(customerToDelete);
        }
    }
}
