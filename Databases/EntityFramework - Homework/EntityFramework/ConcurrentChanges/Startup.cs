using System.Linq;

using NorthwindDB.Models;

namespace ConcurrentChanges
{
    public class Startup
    {
        private static void Main()
        {
            var firstDbContext = new NorthwindEntities();
            var order = firstDbContext.Employees.FirstOrDefault();
            order.FirstName = "Pesho";

            var secondDbContext = new NorthwindEntities();
            var anotherOrder = firstDbContext.Employees.FirstOrDefault();
            anotherOrder.FirstName = "Gosho";

            firstDbContext.SaveChanges();
            secondDbContext.SaveChanges();

            firstDbContext.Dispose();
            secondDbContext.Dispose();

            // As a result the second change is stored in the database.
        }
    }
}
