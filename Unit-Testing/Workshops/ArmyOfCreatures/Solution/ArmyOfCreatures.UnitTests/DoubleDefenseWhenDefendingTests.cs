namespace ArmyOfCreatures.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Logic.Battles;
    using Logic.Specialties;
    using NUnit.Framework;
    using Telerik.JustMock;

    [TestFixture]
    public class DoubleDefenseWhenDefendingTests
    {
        [Test]
        public void ApplyWhenDefending_DefenderWithSpecialtyIsNull_ShouldThrowsException()
        {
            var attackerFake = Mock.Create<ICreaturesInBattle>();
            var defence = new DoubleDefenseWhenDefending(5);

            Assert.Throws<ArgumentNullException>(() => defence.ApplyWhenDefending(null, attackerFake));
        }

        [Test]
        public void ApplyWhenDefending_AttackerIsNull_ShouldThrowsException()
        {
            var defenderFake = Mock.Create<ICreaturesInBattle>();
            var defence = new DoubleDefenseWhenDefending(5);

            Assert.Throws<ArgumentNullException>(() => defence.ApplyWhenDefending(defenderFake, null));
        }

        [TestCase(1)]
        [TestCase(3)]
        [TestCase(5)]
        public void ApplyWhenDefending_WhenEffectHasNotExpired_ShouldDoubleCurrentDefenseOfDefender(int rounds)
        {
            var defender = Mock.Create<ICreaturesInBattle>();
            var attacker = Mock.Create<ICreaturesInBattle>();
            var defense = new DoubleDefenseWhenDefending(rounds);
            defender.CurrentDefense = 5;
            int expectedDefense = 10;

            defense.ApplyWhenDefending(defender, attacker);

            Assert.AreEqual(expectedDefense, defender.CurrentDefense);
        }
    }
}
