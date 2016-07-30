namespace Poker.Tests
{
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class HandToStringTests
    {
        [Test]
        public void ToString_WhenHandHasNoCards_ReturnsEmptyString()
        {
            var cards = new List<ICard>();
            var hand = new Hand(cards);

            string handToString = hand.ToString();

            Assert.AreEqual(string.Empty, handToString);
        }

        [Test]
        public void ToString_WhenOnlyOneCardAceOfHearts_ReturnsCorrectString()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Hearts)
            };
            var hand = new Hand(cards);

            string handToString = hand.ToString();

            Assert.AreEqual("A♥", handToString);
        }

        [Test]
        public void ToString_WhenFiveCards_ReturnsCardsSeparateBySpace()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts)
            };
            var hand = new Hand(cards);

            string handToString = hand.ToString();

            Assert.AreEqual("A♥ A♠ K♦ Q♣ 5♥", handToString);
        }
    }
}
