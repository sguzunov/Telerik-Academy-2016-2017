namespace Kitchen
{
    using System.Collections.Generic;

    public interface IChief
    {
        IBowl Cook(IEnumerable<IVegetable> vegetables);
    }
}
