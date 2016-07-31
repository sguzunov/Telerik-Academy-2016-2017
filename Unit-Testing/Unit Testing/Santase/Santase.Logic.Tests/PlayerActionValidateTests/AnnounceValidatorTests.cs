namespace Santase.Logic.Tests.PlayerActionValidateTests
{
    using System.Collections.Generic;
    using NUnit.Framework;

    using Cards;
    using PlayerActionValidate;

    [TestFixture]
    public class AnnounceValidatorTests
    {
        private readonly Card TrumpCard = new Card(CardSuit.Heart, CardType.Ace);
        private readonly AnnounceValidator announceValidator = new AnnounceValidator();

        [Test]
        public void GetPossibleAnnounce_PlayerIsNotFirst_AnnounceIsNone()
        {
            var cardToBePlayed = new Card(CardSuit.Spade, CardType.Queen);
            var cards = new List<Card>()
            {
                new Card(CardSuit.Heart, CardType.Queen), // Trump
                new Card(CardSuit.Diamond, CardType.Ace),
                new Card(CardSuit.Spade, CardType.Queen),
                new Card(CardSuit.Diamond, CardType.Ten),
                new Card(CardSuit.Club, CardType.Jack),
                new Card(CardSuit.Spade, CardType.King)
            };
            var expectedAnnounce = Announce.None;

            var actualAnnounce = announceValidator.GetPossibleAnnounce(cards, cardToBePlayed, TrumpCard, false);

            Assert.AreEqual(expectedAnnounce, actualAnnounce);
        }

        [Test]
        public void GetPossibleAnnounce_PlayedCardIsNeitherKingNorQueen_AnnounceIsNone()
        {
            var cardToBePlayed = new Card(CardSuit.Diamond, CardType.Ace);
            var cards = new List<Card>()
            {
                new Card(CardSuit.Heart, CardType.Queen), // Trump
                new Card(CardSuit.Diamond, CardType.Ace),
                new Card(CardSuit.Spade, CardType.Queen),
                new Card(CardSuit.Diamond, CardType.Ten),
                new Card(CardSuit.Club, CardType.Jack),
                new Card(CardSuit.Spade, CardType.King)
            };
            var expectedAnnounce = Announce.None;

            var actualAnnounce = announceValidator.GetPossibleAnnounce(cards, cardToBePlayed, TrumpCard, true);

            Assert.AreEqual(expectedAnnounce, actualAnnounce);
        }

        [Test]
        public void GetPossibleAnnounce_PlayedCardIsKingButNoQueenTheSameSuitInHand_AnnounceIsNone()
        {
            var cardToBePlayed = new Card(CardSuit.Spade, CardType.King);
            var cards = new List<Card>()
            {
                new Card(CardSuit.Heart, CardType.Queen), // Trump
                new Card(CardSuit.Diamond, CardType.Ace),
                new Card(CardSuit.Diamond, CardType.Queen),
                new Card(CardSuit.Diamond, CardType.Ten),
                new Card(CardSuit.Club, CardType.Jack),
                new Card(CardSuit.Spade, CardType.King)
            };
            var expectedAnnounce = Announce.None;

            var actualAnnounce = announceValidator.GetPossibleAnnounce(cards, cardToBePlayed, TrumpCard, true);

            Assert.AreEqual(expectedAnnounce, actualAnnounce);
        }

        [Test]
        public void GetPossibleAnnounce_PlayedCardIsQueenButNoKingTheSameSuitInHand_AnnounceIsNone()
        {
            var cardToBePlayed = new Card(CardSuit.Spade, CardType.Queen);
            var cards = new List<Card>()
            {
                new Card(CardSuit.Heart, CardType.Queen), // Trump
                new Card(CardSuit.Diamond, CardType.Ace),
                new Card(CardSuit.Diamond, CardType.Queen),
                new Card(CardSuit.Diamond, CardType.Ten),
                new Card(CardSuit.Club, CardType.Jack),
                new Card(CardSuit.Spade, CardType.Ten)
            };
            var expectedAnnounce = Announce.None;

            var actualAnnounce = announceValidator.GetPossibleAnnounce(cards, cardToBePlayed, TrumpCard, true);

            Assert.AreEqual(expectedAnnounce, actualAnnounce);
        }

        [Test]
        public void GetPossibleAnnounce_PlayedCardIsQueenAndKingTheSameSuitInHand_ReturnsTwenty()
        {
            var cardToBePlayed = new Card(CardSuit.Spade, CardType.Queen);
            var cards = new List<Card>()
            {
                new Card(CardSuit.Heart, CardType.Queen), // Trump
                new Card(CardSuit.Diamond, CardType.Ace),
                new Card(CardSuit.Spade, CardType.Queen),
                new Card(CardSuit.Spade, CardType.King),
                new Card(CardSuit.Club, CardType.Jack),
                new Card(CardSuit.Spade, CardType.Ten)
            };
            var expectedAnnounce = Announce.Twenty;

            var actualAnnounce = announceValidator.GetPossibleAnnounce(cards, cardToBePlayed, TrumpCard, true);

            Assert.AreEqual(expectedAnnounce, actualAnnounce);
        }

        [Test]
        public void GetPossibleAnnounce_PlayedCardIsQueenAndKingTheSameSuitInHand_ReturnsFourty()
        {
            var cardToBePlayed = new Card(CardSuit.Heart, CardType.Queen);
            var cards = new List<Card>()
            {
                new Card(CardSuit.Heart, CardType.Queen), // Trump
                new Card(CardSuit.Heart, CardType.King),
                new Card(CardSuit.Diamond, CardType.Ace),
                new Card(CardSuit.Spade, CardType.Queen),
                new Card(CardSuit.Club, CardType.Jack),
                new Card(CardSuit.Spade, CardType.Ten)
            };
            var expectedAnnounce = Announce.Forty;

            var actualAnnounce = announceValidator.GetPossibleAnnounce(cards, cardToBePlayed, TrumpCard, true);

            Assert.AreEqual(expectedAnnounce, actualAnnounce);
        }

        [Test]
        public void GetPossibleAnnounce_PlayedCardIsKingAndQueenTheSameSuitInHand_ReturnsTwenty()
        {
            var cardToBePlayed = new Card(CardSuit.Spade, CardType.King);
            var cards = new List<Card>()
            {
                new Card(CardSuit.Heart, CardType.Queen), // Trump
                new Card(CardSuit.Diamond, CardType.Ace),
                new Card(CardSuit.Spade, CardType.Queen),
                new Card(CardSuit.Spade, CardType.King),
                new Card(CardSuit.Club, CardType.Jack),
                new Card(CardSuit.Spade, CardType.Ten)
            };
            var expectedAnnounce = Announce.Twenty;

            var actualAnnounce = announceValidator.GetPossibleAnnounce(cards, cardToBePlayed, TrumpCard, true);

            Assert.AreEqual(expectedAnnounce, actualAnnounce);
        }

        [Test]
        public void GetPossibleAnnounce_PlayedCardIsKingAndQueenTheSameSuitInHand_ReturnsFourty()
        {
            var cardToBePlayed = new Card(CardSuit.Heart, CardType.Queen);
            var cards = new List<Card>()
            {
                new Card(CardSuit.Heart, CardType.Queen), // Trump
                new Card(CardSuit.Heart, CardType.King),
                new Card(CardSuit.Diamond, CardType.Ace),
                new Card(CardSuit.Spade, CardType.Queen),
                new Card(CardSuit.Club, CardType.Jack),
                new Card(CardSuit.Spade, CardType.Ten)
            };
            var expectedAnnounce = Announce.Forty;

            var actualAnnounce = announceValidator.GetPossibleAnnounce(cards, cardToBePlayed, TrumpCard, true);

            Assert.AreEqual(expectedAnnounce, actualAnnounce);
        }
    }
}
