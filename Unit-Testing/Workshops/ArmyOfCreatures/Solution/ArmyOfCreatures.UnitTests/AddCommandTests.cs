namespace ArmyOfCreatures.UnitTests
{
    using System;
    using NUnit.Framework;
    using Telerik.JustMock;

    using Console.Commands;
    using Logic.Battles;

    [TestFixture]
    public class AddCommandTests
    {
        [Test]
        public void ProcessCommand_BattleManagerIsNull_ThrowsException()
        {
            var command = new AddCommand();
            IBattleManager manager = null;

            Assert.Throws<ArgumentNullException>(() => command.ProcessCommand(manager, "arg", "arg1", "arg2"));
        }

        [Test]
        public void ProcessCommand_CommandArgumentsAreNull_ThrowsException()
        {
            var command = new AddCommand();
            var manager = Mock.Create<IBattleManager>();

            Assert.Throws<ArgumentNullException>(() => command.ProcessCommand(manager, null));
        }

        [Test]
        public void ProcessCommand_CommandArgumentsAreLessThanTwo_ThrowsException()
        {
            var command = new AddCommand();
            var manager = Mock.Create<IBattleManager>();

            Assert.Throws<ArgumentException>(() => command.ProcessCommand(manager, "arg"));
        }

        [Test]
        public void ProccessCommand_ValidCommand_CallsBattleManagerAddCreature()
        {
            var command = new AddCommand();
            var manager = Mock.Create<IBattleManager>();
            Mock.Arrange(() => manager.AddCreatures(Arg.IsAny<CreatureIdentifier>(), Arg.AnyInt)).MustBeCalled();

            command.ProcessCommand(manager, "10", "AncientBehemoth(1)");
        }
    }
}
