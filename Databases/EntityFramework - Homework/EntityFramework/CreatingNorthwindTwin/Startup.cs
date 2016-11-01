using NorthwindDB.Models;

namespace CreatingNorthwindTwin
{
    public class Startup
    {
        private static void Main()
        {
            using (var ctx = new NorthwindEntities())
            {
                // Check App.config
                ctx.Database.CreateIfNotExists();
                ctx.SaveChanges();
            }
        }
    }
}
