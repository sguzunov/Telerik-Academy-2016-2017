namespace ArmyOfCreatures.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Logic.Battles;
    using NUnit.Framework;

    [TestFixture]
    public class CreatureIdentifierTests
    {
        [Test]
        public void CreatureIdentifierFromString_InputIsNull_ShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => CreatureIdentifier.CreatureIdentifierFromString(null));
        }

        [Test]
        public void CreatureIdentifierFromString_ArmyNumberCannotBeParsed_ShouldThrowException()
        {
            Assert.Throws<FormatException>(() => CreatureIdentifier.CreatureIdentifierFromString("Angel(notNumber)"));
        }

        [Test]
        public void CreatureIdentifierFromString_InputHasNoBrackets_ShouldThrowException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => CreatureIdentifier.CreatureIdentifierFromString("Angel1"));
        }

        [Test]
        public void CreatureIdentifierFromString_ValidInput_ShouldSetCorrectValues()
        {
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            Assert.AreEqual("Angel", identifier.CreatureType);
            Assert.AreEqual(1, identifier.ArmyNumber);
        }

        [Test]
        public void ToString_ShouldReturnsValidFormat()
        {
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            Assert.AreEqual("Angel(1)", identifier.ToString());
        }
    }
}
