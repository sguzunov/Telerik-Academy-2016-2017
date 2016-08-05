namespace Cosmetics.Test
{
    using System;
    using NUnit.Framework;

    using Engine;

    [TestFixture]
    public class CommandTests
    {
        [Test]
        public void Parse_ValidStringPassed_ReturnsCommand()
        {
            string validCommand = "ShowCategory ForMale";

            Assert.IsInstanceOf(typeof(Command), Command.Parse(validCommand));
        }

        [Test]
        public void Parse_ValidStringPassed_ReturnsCorrectCommand()
        {
            string validCommand = "ShowCategory ForMale";

            var command = Command.Parse(validCommand);
            Assert.AreEqual("ShowCategory", command.Name);
            Assert.AreEqual("ForMale", command.Parameters[0]);
        }

        [Test]
        public void Parse_CommandNameIsNullOrEmpty_ThrowsException()
        {
            string commandName = " ForMale";

            var ex = Assert.Catch<ArgumentNullException>(() => Command.Parse(commandName));
            StringAssert.Contains("Name", ex.Message);
        }

        [Test]
        public void Parse_CommandParametersAreNullOrEmpty_ThrowsException()
        {
            string commandName = "ShowCategory ";

            var ex = Assert.Catch<ArgumentNullException>(() => Command.Parse(commandName));
            StringAssert.Contains("List", ex.Message);
        }
    }
}
