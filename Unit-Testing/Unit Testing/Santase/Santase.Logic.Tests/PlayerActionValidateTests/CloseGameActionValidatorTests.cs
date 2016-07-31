namespace Santase.Logic.Tests
{
    using NUnit.Framework;
    using Moq;

    using RoundStates;
    using PlayerActionValidate;

    public class CloseGameActionValidatorTests
    {
        private readonly Mock<IStateManager> mochedStateManager = new Mock<IStateManager>();

        [Test]
        public void CanCloseGame_PlayerIsFirstButRulesDontAllow_ReturnFalse()
        {
            var state = new StartRoundState(mochedStateManager.Object);

            bool canCloseGame = CloseGameActionValidator.CanCloseGame(true, state);

            Assert.IsFalse(canCloseGame);
        }

        [Test]
        public void CanCloseGame_PlayerIsNotFirstAndRulesAllow_ReturnFalse()
        {
            var state = new MoreThanTwoCardsLeftRoundState(mochedStateManager.Object);

            bool canCloseGame = CloseGameActionValidator.CanCloseGame(false, state);

            Assert.IsFalse(canCloseGame);
        }

        [Test]
        public void CanCloseGame_PlayerIsFirstAndRulesAllow_ReturnTrue()
        {
            var state = new MoreThanTwoCardsLeftRoundState(mochedStateManager.Object);

            bool canCloseGame = CloseGameActionValidator.CanCloseGame(true, state);

            Assert.IsTrue(canCloseGame);
        }
    }
}
