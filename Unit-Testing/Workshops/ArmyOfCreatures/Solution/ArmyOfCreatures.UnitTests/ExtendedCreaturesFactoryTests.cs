namespace ArmyOfCreatures.UnitTests
{
    using System;
    using Extended;
    using NUnit.Framework;
    using Telerik.JustMock;

    [TestFixture]
    public class ExtendedCreaturesFactoryTests
    {
        [Test]
        public void CreateCreature_WhenNonExistingTypeIsPassed_ShouldThrowExceptionWithCorrectMessage()
        {
            var factory = new ExtendedCreaturesFactory();
            string nonExistingType = "NonExistingCreatureType";

            var ex = Assert.Catch<ArgumentException>(() => factory.CreateCreature(nonExistingType));

            StringAssert.Contains("Invalid creature type", ex.Message);
        }

        [TestCase("AncientBehemoth")]
        [TestCase("CyclopsKing")]
        [TestCase("Goblin")]
        [TestCase("Griffin")]
        [TestCase("WolfRaider")]
        [TestCase("Angel")]
        public void CreateCreature_WhenExistingCreatureTypeIsPassed_ShouldReturnCorrectType(string creatureType)
        {
            var factory = new ExtendedCreaturesFactory();

            var creature = factory.CreateCreature(creatureType);

            Assert.AreEqual(creatureType, creature.GetType().Name);
        }
    }
}
