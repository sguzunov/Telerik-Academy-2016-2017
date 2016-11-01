using System;
using System.Data.Entity;
using System.Linq;

using NorthwindDB.Models;

namespace CustomersDAO
{
    public class CustomersDAO
    {
        public static Customer GetById(string id)
        {
            using (NorthwindEntities dbContex = new NorthwindEntities())
            {
                return dbContex.Customers.FirstOrDefault(c => c.CustomerID == id);
            }
        }

        public static void Insert(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            using (NorthwindEntities dbContext = new NorthwindEntities())
            {
                dbContext.Customers.Add(customer);

                dbContext.SaveChanges();
            }
        }

        public static void Update(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            using (NorthwindEntities dbContext = new NorthwindEntities())
            {
                if (GetById(customer.CustomerID) == null)
                {
                    throw new ArgumentException("Customer is not existing in the database");
                }

                dbContext.Customers.Attach(customer);
                dbContext.Entry(customer).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
        }

        public static void Delete(string id)
        {
            using (NorthwindEntities dbContex = new NorthwindEntities())
            {
                var customerToRemove = GetById(id);
                dbContex.Customers.Attach(customerToRemove);
                dbContex.Customers.Remove(customerToRemove);

                dbContex.SaveChanges();
            }
        }

        public static void Delete(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            using (NorthwindEntities dbContex = new NorthwindEntities())
            {
                dbContex.Customers.Attach(customer);
                dbContex.Customers.Remove(customer);

                dbContex.SaveChanges();
            }
        }
    }
}
