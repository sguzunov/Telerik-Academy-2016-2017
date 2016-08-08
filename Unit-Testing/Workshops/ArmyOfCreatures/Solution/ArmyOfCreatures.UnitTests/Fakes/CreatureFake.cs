using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Logic.Creatures;
using ArmyOfCreatures.Logic.Specialties;

namespace ArmyOfCreatures.UnitTests.Fakes
{
    internal class CreatureFake : Creature
    {
        public CreatureFake(int attack, int defense, int healthPoints, decimal damage) : base(attack, defense, healthPoints, damage)
        {
        }

        public void AddNewSpecialty(Specialty specialty)
        {
            this.AddSpecialty(specialty);
        }
    }
}
