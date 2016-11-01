namespace NorthwindDB.Models
{
    using System.Data.Linq;

    public partial class Employee
    {
        public EntitySet<Territory> TerritoriesEntitySet
        {
            get
            {
                var territoriesSet = new EntitySet<Territory>();
                territoriesSet.AddRange(this.Territories);
                return territoriesSet;
            }
        }
    }
}
