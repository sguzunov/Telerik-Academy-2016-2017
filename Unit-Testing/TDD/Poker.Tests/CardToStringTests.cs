namespace Poker.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class CardToStringTests
    {
        [Test]
        public void ToString_WhenTwoOfClubs_ReturnsCorrectString()
        {
            var card = new Card(CardFace.Two, CardSuit.Clubs);

            string cardToString = card.ToString();

            Assert.AreEqual("2♣", cardToString);
        }

        [Test]
        public void ToString_WhenFiveOfClubs_ReturnsCorrectString()
        {
            var card = new Card(CardFace.Five, CardSuit.Clubs);

            string cardToString = card.ToString();

            Assert.AreEqual("5♣", cardToString);
        }

        [Test]
        public void ToString_WhenTenOfDiamonds_ReturnsCorrectString()
        {
            var card = new Card(CardFace.Ten, CardSuit.Diamonds);

            string cardToString = card.ToString();

            Assert.AreEqual("10♦", cardToString);
        }

        [Test]
        public void ToString_WhenJackOfHearts_ReturnsCorrectString()
        {
            var card = new Card(CardFace.Jack, CardSuit.Hearts);

            string cardToString = card.ToString();

            Assert.AreEqual("J♥", cardToString);
        }

        [Test]
        public void ToString_WhenAceOfSpades_ReturnsCorrectString()
        {
            var card = new Card(CardFace.Ace, CardSuit.Spades);

            string cardToString = card.ToString();

            Assert.AreEqual("A♠", cardToString);
        }
    }
}
