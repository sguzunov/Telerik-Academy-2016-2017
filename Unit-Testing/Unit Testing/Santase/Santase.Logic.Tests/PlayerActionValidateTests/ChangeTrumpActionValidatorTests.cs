namespace Santase.Logic.Tests
{
    using System.Collections.Generic;
    using Moq;
    using NUnit.Framework;

    using Cards;
    using RoundStates;
    using Santase.Logic.PlayerActionValidate;

    [TestFixture]
    public class ChangeTrumpActionValidatorTests
    {
        private readonly Card TrumpCard = new Card(CardSuit.Heart, CardType.Ace);
        private readonly Mock<IStateManager> MochedStateManager = new Mock<IStateManager>();
        private ICollection<Card> CardsWithoutNineTrumpCard = new List<Card>()
            {
                new Card(CardSuit.Heart, CardType.Queen),
                new Card(CardSuit.Club, CardType.Ace),
                new Card(CardSuit.Diamond, CardType.Jack),
                new Card(CardSuit.Spade, CardType.King),
                new Card(CardSuit.Spade, CardType.Queen),
                new Card(CardSuit.Diamond, CardType.Ten)
            };

        [Test]
        public void CanChangeTrump_RulesAllowButPlayerIsNotFirst_ReturnFalse()
        {
            var state = new MoreThanTwoCardsLeftRoundState(MochedStateManager.Object);

            bool canChangeTrumpCard = ChangeTrumpActionValidator.CanChangeTrump(false, state, TrumpCard, CardsWithoutNineTrumpCard);

            Assert.IsFalse(canChangeTrumpCard);
        }

        [Test]
        public void CanChangeTrump_PlayerIsFirstButRulesDontAllow_ReturnsFalse()
        {
            var state = new StartRoundState(MochedStateManager.Object);

            bool canChangeTrumpCard = ChangeTrumpActionValidator.CanChangeTrump(true, state, TrumpCard, CardsWithoutNineTrumpCard);

            Assert.IsFalse(canChangeTrumpCard);
        }

        [Test]
        public void CanChangeTrump_PlayerOnTurnRulesAllowButMissingNineOfTrumpCardInHand_ReturnsFalse()
        {
            var state = new MoreThanTwoCardsLeftRoundState(MochedStateManager.Object);

            bool canChangeTrumpCard = ChangeTrumpActionValidator.CanChangeTrump(true, state, TrumpCard, CardsWithoutNineTrumpCard);

            Assert.IsFalse(canChangeTrumpCard);
        }

        [Test]
        public void CanChangeTrump_PlayerOnTurnRulesAllowAndNineOfTrumpCardInHand_ReturnsTrue()
        {
            var state = new MoreThanTwoCardsLeftRoundState(MochedStateManager.Object);
            var cardsWithNineTrumpCard = new List<Card>
            {
                new Card(CardSuit.Heart, CardType.Queen),
                new Card(CardSuit.Heart, CardType.Nine),
                new Card(CardSuit.Diamond, CardType.Jack),
                new Card(CardSuit.Spade, CardType.King),
                new Card(CardSuit.Spade, CardType.Queen),
                new Card(CardSuit.Diamond, CardType.Ten)
            };

            bool canChangeTrumpCard = ChangeTrumpActionValidator.CanChangeTrump(true, state, TrumpCard, cardsWithNineTrumpCard);

            Assert.IsTrue(canChangeTrumpCard);
        }
    }
}
