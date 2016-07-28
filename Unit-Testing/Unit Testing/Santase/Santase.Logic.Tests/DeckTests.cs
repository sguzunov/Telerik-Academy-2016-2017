namespace Santase.Logic.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;

    using Santase.Logic.Cards;

    [TestFixture]
    public class DeckTests
    {
        [Test]
        public void Deck_WhenInstantiated_ShouldHave24Cards()
        {
            var deck = new Deck();
            int expectedCardsCount = 24;

            int actualCardsCount = deck.CardsLeft;

            Assert.AreEqual(expectedCardsCount, actualCardsCount);
        }

        [Test]
        public void Deck_WhenInstantiated_TrumpCardShouldNotBeNull()
        {
            var deck = new Deck();

            Assert.IsNotNull(deck.TrumpCard);
        }

        [Test]
        public void GetNextCard_WhenDrawOneCardFromANewDeck_ShouldHave23CardsLeft()
        {
            var deck = new Deck();
            int expectedCardsCount = 23;

            deck.GetNextCard();
            int actualCardsCount = deck.CardsLeft;

            Assert.AreEqual(expectedCardsCount, actualCardsCount);
        }

        [Test]
        public void GetNextCard_Called24TimesAfterInitialization_DeckShouldBeEmpty()
        {
            var deck = new Deck();
            int expectedCardsCount = 0;
            for (int i = 0; i < 24; i++)
            {
                deck.GetNextCard();
            }

            int actualCardsCount = deck.CardsLeft;

            Assert.AreEqual(expectedCardsCount, actualCardsCount);
        }

        public void GetNextCard_WhenDeckIsInstantiated_ShouldReturn24UniqeCards()
        {
            var deck = new Deck();
            var cards = new List<Card>();
            int expectedUniqueCardsCount = 24;

            for (int i = 0; i < 24; i++)
            {
                cards.Add(deck.GetNextCard());
            }

            int actualUniqueCardsCount = cards.Distinct().ToArray().Length;

            Assert.AreEqual(expectedUniqueCardsCount, actualUniqueCardsCount);
        }

        [Test]
        public void GetNextCard_WhenDeckIsEmpty_Throws()
        {
            var deck = new Deck();
            for (int i = 0; i < 24; i++)
            {
                deck.GetNextCard();
            }

            Assert.Throws<InternalGameException>(() => deck.GetNextCard());
        }

        [Test]
        public void Deck_WhenInstantiated_ShouldNotContainsNullCards()
        {
            var deck = new Deck();
            bool containsNullCard = false;
            for (int i = 0; i < 24; i++)
            {
                var drawnCard = deck.GetNextCard();
                if (drawnCard == null)
                {
                    containsNullCard = true;
                    break;
                }
            }

            Assert.IsFalse(containsNullCard);
        }

        [Test]
        public void TrumpCard_ShouldBeTheFirstCardForANewDeck()
        {
            var deck = new Deck();
            for (int i = 0; i < 23; i++)
            {
                deck.GetNextCard();
            }

            Assert.AreEqual(deck.TrumpCard, deck.GetNextCard());
        }

        [Test]
        public void ChangeTrumpCard_ShouldChangeTrumpCardWithThePassedCard()
        {
            var deck = new Deck();
            var newTrumpCard = new Card(CardSuit.Club, CardType.Ace);

            deck.ChangeTrumpCard(newTrumpCard);

            Assert.AreEqual(newTrumpCard, deck.TrumpCard);
        }

        [Test]
        public void ChangeTrumpCard_ShouldChangeFirstCardOfDeck()
        {
            var deck = new Deck();
            var newTrumpCard = new Card(CardSuit.Club, CardType.Ace);

            deck.ChangeTrumpCard(newTrumpCard);
            for (int i = 0; i < 23; i++)
            {
                deck.GetNextCard();
            }

            Assert.AreEqual(newTrumpCard, deck.GetNextCard());
        }

        [Test]
        public void ChangeTrumpCard_ForEmptyDeck_DoesNotAddACardToDeck()
        {
            var deck = new Deck();
            int expectedCardsCount = 0;
            var card = new Card(CardSuit.Club, CardType.Ace);
            for (int i = 0; i < 24; i++)
            {
                deck.GetNextCard();
            }

            deck.ChangeTrumpCard(card);
            var cardsLeft = deck.CardsLeft;

            Assert.AreEqual(expectedCardsCount, cardsLeft);
        }
    }
}
