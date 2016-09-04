namespace Kitchen
{
    using System.Collections.Generic;

    public class Bowl : IBowl
    {
        private readonly IList<IVegetable> vegetables;

        public Bowl()
        {
            this.vegetables = new List<IVegetable>();
        }

        public void Add(IVegetable vegie)
        {
            this.vegetables.Add(vegie);
        }
    }
}
