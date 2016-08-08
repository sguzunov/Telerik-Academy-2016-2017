namespace ArmyOfCreatures.UnitTests
{
    using System;
    using Logic;
    using Logic.Battles;
    using NUnit.Framework;
    using Telerik.JustMock;
    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.Kernel;
    using Logic.Creatures;
    using System.Collections.Generic;
    using Logic.Specialties;
    using Fakes;

    [TestFixture]
    public class BattleManagerTests
    {
        [Test]
        public void AddCreatures_CreatureIdentifierIsNull_ShouldThrowException()
        {
            var factoryFake = GetCreatureFactoryFake();
            var loggerFake = GetLoggerFake();
            var manager = new BattleManager(factoryFake, loggerFake);

            Assert.Throws<ArgumentNullException>(() => manager.AddCreatures(null, 5));
        }

        [Test]
        public void AddCreature_ValidCreatureIdentifier_ShouldCallFactoryCreateCreatureMethod()
        {
            string identifierString = "Angel(1)";
            var identifier = CreatureIdentifier.CreatureIdentifierFromString(identifierString);
            var factoryFake = GetCreatureFactoryFake();
            var loggerFake = GetLoggerFake();
            var manager = new BattleManager(factoryFake, loggerFake);

            Fixture fixture = new Fixture();
            fixture.Customizations.Add(
                    new TypeRelay(
                        typeof(Creature),
                        typeof(Angel)));
            var creature = fixture.Create<Creature>();

            Mock.Arrange(() => factoryFake.CreateCreature(Arg.AnyString)).Returns(creature);

            manager.AddCreatures(identifier, 1);

            Mock.Assert(() => factoryFake.CreateCreature(Arg.AnyString), Occurs.Once());
        }

        [Test]
        public void AddCreatures_ValidCreatureIdentifier_ShouldCallLoggerWriteLineMethod()
        {
            // Arrange
            string identifierString = "Angel(1)";
            var identifier = CreatureIdentifier.CreatureIdentifierFromString(identifierString);
            var factoryFake = GetCreatureFactoryFake();
            var loggerFake = GetLoggerFake();
            var manager = new BattleManager(factoryFake, loggerFake);

            var fixture = new Fixture();
            fixture.Customizations.Add(
                    new TypeRelay(
                        typeof(Creature),
                        typeof(Angel)));
            var creature = fixture.Create<Creature>();

            Mock.Arrange(() => factoryFake.CreateCreature(Arg.AnyString)).Returns(creature);

            // Act
            manager.AddCreatures(identifier, 1);

            // Assert
            Mock.Assert(() => loggerFake.WriteLine(Arg.AnyString), Occurs.Once());
        }

        [Test]
        public void AddCreatures_AddingCreatureToNonExistingArmy_ShouldThrowException()
        {
            string identifierString = "Angel(3)";
            var identifier = CreatureIdentifier.CreatureIdentifierFromString(identifierString);
            var factoryFake = GetCreatureFactoryFake();
            var loggerFake = GetLoggerFake();
            var manager = new BattleManager(factoryFake, loggerFake);

            var fixture = new Fixture();
            fixture.Customizations.Add(
                    new TypeRelay(
                        typeof(Creature),
                        typeof(Angel)));
            var creature = fixture.Create<Creature>();

            Mock.Arrange(() => factoryFake.CreateCreature(Arg.AnyString)).Returns(creature);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => manager.AddCreatures(identifier, 1));
        }

        [Test]
        public void Attack_AttackerIdentifierIsNull_ThrowsException()
        {
            var factoryFake = GetCreatureFactoryFake();
            var loggerFake = GetLoggerFake();
            var manager = new BattleManager(factoryFake, loggerFake);

            var defenderIdentifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            Assert.Throws<ArgumentNullException>(() => manager.Attack(null, defenderIdentifier));
        }

        [Test]
        public void Attack_AttackerArmyMissing_ThrowsExceptionWithCorrectMessage()
        {
            var factoryFake = GetCreatureFactoryFake();
            var loggerFake = GetLoggerFake();
            var manager = new BattleManager(factoryFake, loggerFake);

            var attackerIdentifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(5)");
            var defenderIdentifier = CreatureIdentifier.CreatureIdentifierFromString("Devil(1)");

            var exception = Assert.Catch<ArgumentException>(() => manager.Attack(attackerIdentifier, defenderIdentifier));
            StringAssert.Contains("Invalid ArmyNumber", exception.Message);
        }

        [Test]
        public void Attack_AttackerIsNotInArmy_ThrowsExceptionWithCorrectMessage()
        {
            var factoryFake = GetCreatureFactoryFake();
            var loggerFake = GetLoggerFake();
            var manager = new BattleManager(factoryFake, loggerFake);

            var attackerIdentifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(2)");
            var defenderIdentifier = CreatureIdentifier.CreatureIdentifierFromString("Devil(1)");

            var exception = Assert.Catch<ArgumentException>(() => manager.Attack(attackerIdentifier, defenderIdentifier));
            StringAssert.Contains("Attacker not found", exception.Message);
        }

        [Test]
        public void Attack_DefenderIdentifierIsNull_ShouldThrowException()
        {
            // Arrange
            var factoryFake = GetCreatureFactoryFake();
            var loggerFake = GetLoggerFake();
            var manager = new BattleManager(factoryFake, loggerFake);

            Mock.Arrange(() => factoryFake.CreateCreature(Arg.AnyString)).Returns(new Angel());

            var attackerIdentifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            manager.AddCreatures(attackerIdentifier, 1);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => manager.Attack(attackerIdentifier, null));
        }

        [Test]
        public void Attack_DefenderIdentifierIsMissing_ShouldThrowException()
        {
            // Arrange
            var factoryFake = GetCreatureFactoryFake();
            var loggerFake = GetLoggerFake();
            var manager = new BattleManager(factoryFake, loggerFake);

            Mock.Arrange(() => factoryFake.CreateCreature(Arg.AnyString)).Returns(new Angel());

            var attackerIdentifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            var defenderIdentifier = CreatureIdentifier.CreatureIdentifierFromString("Devil(5)");
            manager.AddCreatures(attackerIdentifier, 1);

            // Act & Assert
            var exception = Assert.Catch<ArgumentException>(() => manager.Attack(attackerIdentifier, defenderIdentifier));
            StringAssert.Contains("Invalid ArmyNumber", exception.Message);
        }

        [Test]
        public void Attack_DefenderIsNotInArmy_ShouldThrowException()
        {
            // Arrange
            var factoryFake = GetCreatureFactoryFake();
            var loggerFake = GetLoggerFake();
            var manager = new BattleManager(factoryFake, loggerFake);

            Mock.Arrange(() => factoryFake.CreateCreature(Arg.AnyString)).Returns(new Angel());

            var attackerIdentifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            var defenderIdentifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(2)");
            manager.AddCreatures(attackerIdentifier, 1);

            // Act & Assert
            var exception = Assert.Catch<ArgumentException>(() => manager.Attack(attackerIdentifier, defenderIdentifier));
            StringAssert.Contains("Defender not found", exception.Message);
        }

        [Test]
        public void Attack_ValidInput_ShouldCallLogerWriteLineSixTimes()
        {
            // Arrange
            var factoryFake = GetCreatureFactoryFake();
            var loggerFake = GetLoggerFake();
            var manager = new BattleManager(factoryFake, loggerFake);

            Mock.Arrange(() => factoryFake.CreateCreature(Arg.AnyString)).Returns(new Angel());

            var attackerIdentifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            var defenderIdentifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(2)");
            manager.AddCreatures(attackerIdentifier, 1);
            manager.AddCreatures(defenderIdentifier, 1);

            manager.Attack(attackerIdentifier, defenderIdentifier);

            Mock.Assert(() => loggerFake.WriteLine(Arg.AnyString), Occurs.Exactly(6));
        }

        private ICreaturesFactory GetCreatureFactoryFake()
        {
            var factoryFake = Mock.Create<ICreaturesFactory>();
            return factoryFake;
        }

        private ILogger GetLoggerFake()
        {
            var loggerFake = Mock.Create<ILogger>();
            return loggerFake;
        }
    }
}
