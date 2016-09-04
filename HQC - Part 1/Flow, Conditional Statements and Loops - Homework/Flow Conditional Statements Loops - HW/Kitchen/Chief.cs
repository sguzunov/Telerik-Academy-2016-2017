namespace Kitchen
{
    using System.Collections.Generic;

    public class Chief : IChief
    {
        public IBowl Cook(IEnumerable<IVegetable> vegetables)
        {
            var bowl = this.GetBowl();
            foreach (var vegie in vegetables)
            {
                this.Peel(vegie);
                this.Cut(vegie);
                bowl.Add(vegie);
            }

            return bowl;
        }

        private void Cut(IVegetable vegie)
        {
            vegie.IsCut = true;
        }

        private void Peel(IVegetable vegie)
        {
            vegie.IsPeeled = true;
        }

        private IBowl GetBowl()
        {
            return new Bowl();
        }
    }
}
