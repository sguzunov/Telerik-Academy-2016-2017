namespace ArmyOfCreatures.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Fakes;
    using Logic.Battles;
    using Logic.Creatures;
    using NUnit.Framework;
    using Moq;
    using Logic.Specialties;

    [TestFixture]
    public class CreaturesInBattleTests
    {
        [Test]
        public void StartNewTurn_ShouldSetCurrentAttackToBeEqualToPermanentAttack()
        {
            var creatureInBattle = new CreaturesInBattle(new CreatureFake(10, 10, 10, 10M), 1);

            Assert.AreEqual(creatureInBattle.PermanentAttack, creatureInBattle.CurrentAttack);
        }

        [Test]
        public void StartNewTurn_ShouldSetCurrentDefenseToBeEqualToPermanentDefense()
        {
            var creatureInBattle = new CreaturesInBattle(new CreatureFake(10, 10, 10, 10M), 1);

            Assert.AreEqual(creatureInBattle.PermanentDefense, creatureInBattle.CurrentDefense);
        }

        [Test]
        public void Skip_WhenNoSpecialities_ShouldAddThreeToPermenentDefense()
        {
            var creatureInBattle = new CreaturesInBattle(new CreatureFake(10, 10, 10, 10M), 1);

            creatureInBattle.Skip();

            Assert.AreEqual(13, creatureInBattle.PermanentDefense);
        }

        [Test]
        public void Skip_WhenOneSpecialty_ShouldCallApplyOnSkipOnce()
        {
            var specialityFake = new Mock<Specialty>();
            var creatureFake = new CreatureFake(10, 10, 10, 10M);
            creatureFake.AddNewSpecialty(specialityFake.Object);

            var creatureInBattle = new CreaturesInBattle(creatureFake, 1);

            specialityFake.Setup(x => x.ApplyOnSkip(It.IsAny<ICreaturesInBattle>()));

            creatureInBattle.Skip();

            specialityFake.Verify(x => x.ApplyOnSkip(It.IsAny<ICreaturesInBattle>()), Times.Once);
        }

        [Test]
        public void Skip_WhenFiveSpecialty_ShouldCallApplyOnSkipFiveTimes()
        {
            var specialityFake = new Mock<Specialty>();
            var creatureFake = new CreatureFake(10, 10, 10, 10M);
            creatureFake.AddNewSpecialty(specialityFake.Object);
            creatureFake.AddNewSpecialty(specialityFake.Object);
            creatureFake.AddNewSpecialty(specialityFake.Object);
            creatureFake.AddNewSpecialty(specialityFake.Object);
            creatureFake.AddNewSpecialty(specialityFake.Object);

            var creatureInBattle = new CreaturesInBattle(creatureFake, 1);

            specialityFake.Setup(x => x.ApplyOnSkip(It.IsAny<ICreaturesInBattle>()));

            creatureInBattle.Skip();

            specialityFake.Verify(x => x.ApplyOnSkip(It.IsAny<ICreaturesInBattle>()), Times.Exactly(5));
        }
    }
}
