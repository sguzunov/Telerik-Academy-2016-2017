namespace ArmyOfCreatures.Logic
{
    using System.Collections.Generic;

    using Specialties;

    public interface ICreature
    {
        int Attack { get; }

        int Defense { get; }

        int HealthPoints { get; }

        decimal Damage { get; }

        IEnumerable<Specialty> Specialties
        {
            get;
        }
    }
}
