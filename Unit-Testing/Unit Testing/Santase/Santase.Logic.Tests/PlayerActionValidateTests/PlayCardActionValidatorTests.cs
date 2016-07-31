namespace Santase.Logic.Tests
{
    using System.Collections.Generic;
    using NUnit.Framework;

    using Cards;
    using PlayerActionValidate;

    public class PlayCardActionValidatorTests
    {
        private readonly Card TrumpCard = new Card(CardSuit.Heart, CardType.Ace);
        private readonly ICollection<Card> Cards = new List<Card>()
            {
                new Card(CardSuit.Heart, CardType.Queen), // Trump
                new Card(CardSuit.Diamond, CardType.Ace),
                new Card(CardSuit.Club, CardType.Jack),
                new Card(CardSuit.Spade, CardType.King),
                new Card(CardSuit.Spade, CardType.Queen),
                new Card(CardSuit.Diamond, CardType.Ten)
            };


        [Test]
        public void CanPlayCard_PlayerIsFirstRulesShouldBeObservedButHandDoesNotHavePlayedCard_ReturnsFalse()
        {
            var playedCard = new Card(CardSuit.Spade, CardType.Nine);
            var otherPlayerCard = new Card(CardSuit.Spade, CardType.Jack);
            bool observerRules = false;

            bool canPlayCard = PlayCardActionValidator.CanPlayCard(true, playedCard, otherPlayerCard, TrumpCard, Cards, observerRules);

            Assert.IsFalse(canPlayCard);
        }

        [Test]
        public void CanPlayCard_PlayerIsFirstRulesShouldBeObserved_ReturnsTrue()
        {
            var playedCard = new Card(CardSuit.Diamond, CardType.Ten);
            var otherPlayerCard = new Card(CardSuit.Spade, CardType.Nine);
            bool observeRules = true;

            bool canPlayCard = PlayCardActionValidator.CanPlayCard(true, playedCard, otherPlayerCard, TrumpCard, Cards, observeRules);

            Assert.IsTrue(canPlayCard);
        }

        [Test]
        public void CanPlayCard_PlayerIsFirstRulesShouldNotBeObserved_ReturnsTrue()
        {
            var playedCard = new Card(CardSuit.Diamond, CardType.Ten);
            var otherPlayerCard = new Card(CardSuit.Spade, CardType.Nine);
            bool observeRules = false;

            bool canPlayCard = PlayCardActionValidator.CanPlayCard(true, playedCard, otherPlayerCard, TrumpCard, Cards, observeRules);

            Assert.IsTrue(canPlayCard);
        }

        [Test]
        public void CanPlayCard_PlayerIsNotFirstRulesShouldNotBeObserved_ReturnsTrue()
        {
            var playedCard = new Card(CardSuit.Diamond, CardType.Ten);
            var otherPlayerCard = new Card(CardSuit.Spade, CardType.Nine);
            bool observeRules = false;

            bool canPlayCard = PlayCardActionValidator.CanPlayCard(false, playedCard, otherPlayerCard, TrumpCard, Cards, observeRules);

            Assert.IsTrue(canPlayCard);
        }

        [Test]
        public void CanPlayCard_PlayerAnswerWithLowerCardTheSameSuit_ReturnsTrue()
        {
            var playedCard = new Card(CardSuit.Diamond, CardType.Jack);
            var otherPlayerCard = new Card(CardSuit.Diamond, CardType.Ten);
            bool observeRules = true;
            var cards = new List<Card>()
            {
                new Card(CardSuit.Heart, CardType.Queen),
                new Card(CardSuit.Club, CardType.Ace),
                new Card(CardSuit.Club, CardType.Jack),
                new Card(CardSuit.Spade, CardType.King),
                new Card(CardSuit.Spade, CardType.Queen),
                new Card(CardSuit.Diamond, CardType.Jack)
            };

            bool canPlayCard = PlayCardActionValidator.CanPlayCard(false, playedCard, otherPlayerCard, TrumpCard, cards, observeRules);

            Assert.IsTrue(canPlayCard);
        }

        [Test]
        public void CanPlayCard_PlayerAnswerWithBiggerTheSameSuit_ReturnsTrue()
        {
            var playedCard = new Card(CardSuit.Diamond, CardType.Ten);
            var otherPlayerCard = new Card(CardSuit.Diamond, CardType.Jack);
            bool observeRules = true;
            var cards = new List<Card>()
            {
                new Card(CardSuit.Heart, CardType.Queen),
                new Card(CardSuit.Club, CardType.Ace),
                new Card(CardSuit.Club, CardType.Jack),
                new Card(CardSuit.Spade, CardType.King),
                new Card(CardSuit.Spade, CardType.Queen),
                new Card(CardSuit.Diamond, CardType.Ten)
            };

            bool canPlayCard = PlayCardActionValidator.CanPlayCard(false, playedCard, otherPlayerCard, TrumpCard, cards, observeRules);

            Assert.IsTrue(canPlayCard);
        }

        [Test]
        public void CanPlayCard_PlayerAnswerWithLowerTheSameSuitButHasBiggerInHand_ReturnsFalse()
        {
            var playedCard = new Card(CardSuit.Diamond, CardType.Jack);
            var otherPlayerCard = new Card(CardSuit.Diamond, CardType.Ten);
            bool observeRules = true;
            var cards = new List<Card>()
            {
                new Card(CardSuit.Heart, CardType.Queen),
                new Card(CardSuit.Club, CardType.Ace),
                new Card(CardSuit.Club, CardType.Jack),
                new Card(CardSuit.Spade, CardType.King),
                new Card(CardSuit.Spade, CardType.Queen),
                new Card(CardSuit.Diamond, CardType.Ace)
            };

            bool canPlayCard = PlayCardActionValidator.CanPlayCard(false, playedCard, otherPlayerCard, TrumpCard, cards, observeRules);

            Assert.IsFalse(canPlayCard);
        }

        [Test]
        public void CanPlayCard_PlayedCardIsDifferentSuitButRequiredSuitIsInHand_ReturnsFalse()
        {
            var playedCard = new Card(CardSuit.Club, CardType.Jack);
            var otherPlayerCard = new Card(CardSuit.Diamond, CardType.Ten);
            bool observeRules = true;
            var cards = new List<Card>()
            {
                new Card(CardSuit.Club, CardType.Queen),
                new Card(CardSuit.Club, CardType.Ace),
                new Card(CardSuit.Club, CardType.Jack),
                new Card(CardSuit.Spade, CardType.King),
                new Card(CardSuit.Spade, CardType.Queen),
                new Card(CardSuit.Diamond, CardType.Ace)
            };

            bool canPlayCard = PlayCardActionValidator.CanPlayCard(false, playedCard, otherPlayerCard, TrumpCard, cards, observeRules);

            Assert.IsFalse(canPlayCard);
        }

        [Test]
        public void CanPlayCard_PlayedCardIsDifferentSuitAndTrumpCardInHand_ReturnsFalse()
        {
            var playedCard = new Card(CardSuit.Club, CardType.Jack);
            var otherPlayerCard = new Card(CardSuit.Diamond, CardType.Ten);
            bool observeRules = true;
            var cards = new List<Card>()
            {
                new Card(CardSuit.Heart, CardType.Queen),
                new Card(CardSuit.Club, CardType.Ace),
                new Card(CardSuit.Club, CardType.Jack),
                new Card(CardSuit.Spade, CardType.King),
                new Card(CardSuit.Spade, CardType.Queen),
                new Card(CardSuit.Club, CardType.Ace)
            };

            bool canPlayCard = PlayCardActionValidator.CanPlayCard(false, playedCard, otherPlayerCard, TrumpCard, cards, observeRules);

            Assert.IsFalse(canPlayCard);
        }

        [Test]
        public void CanPlayCard_PlayedCardIsTrumpAndNoCardToAnswerInHand_ReturnsTrue()
        {
            var playedCard = new Card(CardSuit.Heart, CardType.Queen);
            var otherPlayerCard = new Card(CardSuit.Diamond, CardType.Ten);
            bool observeRules = true;
            var cards = new List<Card>()
            {
                new Card(CardSuit.Heart, CardType.Queen),
                new Card(CardSuit.Club, CardType.Ace),
                new Card(CardSuit.Club, CardType.Jack),
                new Card(CardSuit.Spade, CardType.King),
                new Card(CardSuit.Spade, CardType.Queen),
                new Card(CardSuit.Club, CardType.Ace)
            };

            bool canPlayCard = PlayCardActionValidator.CanPlayCard(false, playedCard, otherPlayerCard, TrumpCard, cards, observeRules);

            Assert.IsTrue(canPlayCard);
        }
    }
}
