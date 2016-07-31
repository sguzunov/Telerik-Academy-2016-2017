namespace Poker.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class PokerHandsCheckerTests
    {
        private IPokerHandsChecker handsChecker = new PokerHandsChecker();

        // IsValidHand
        [Test]
        public void IsValidHand_WhenNullPassed_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => handsChecker.IsValidHand(null));
        }

        [Test]
        public void IsValidHand_WhenNoCards_ThrowsException()
        {
            var cards = new List<ICard>();
            var hand = new Hand(cards);

            Assert.Throws<ArgumentException>(() => handsChecker.IsValidHand(hand));
        }

        [Test]
        public void IsValidHand_WhenDuplicateCards_ReturnsFalse()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Hearts)
            };
            var hand = new Hand(cards);

            Assert.IsFalse(handsChecker.IsValidHand(hand));
        }

        [Test]
        public void IsValidHand_WhenLessThanFiveCards_ReturnsFalse()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Diamonds)
            };
            var hand = new Hand(cards);

            Assert.IsFalse(handsChecker.IsValidHand(hand));
        }

        [Test]
        public void IsValidHand_WhenMoreThanFiveCards_ReturnsFalse()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Clubs)
            };
            var hand = new Hand(cards);

            Assert.IsFalse(handsChecker.IsValidHand(hand));
        }

        [Test]
        public void IsValidHand_WhenFiveDifferentCards_ReturnsTrue()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Hearts)
            };
            var hand = new Hand(cards);

            Assert.IsTrue(handsChecker.IsValidHand(hand));
        }

        // IsFlush
        [Test]
        public void IsFlush_WhenFiveNonConsecutiveCardsWithMixedSuits_ReturnsFalse()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Hearts)
            };
            var hand = new Hand(cards);

            Assert.IsFalse(handsChecker.IsFlush(hand));
        }

        [Test]
        public void IsFlush_WhenFiveConsecutiveCardsWithSameSuit_ReturnsFalse()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Hearts)
            };
            var hand = new Hand(cards);

            Assert.IsFalse(handsChecker.IsFlush(hand));
        }

        [Test]
        public void IsFlush_WhenFiveConsecutiveCardsWithDifferentSuit_ReturnsFalse()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Hearts)
            };
            var hand = new Hand(cards);

            Assert.IsFalse(handsChecker.IsFlush(hand));
        }

        [Test]
        public void IsFlush_WhenFiveNonConsecutiveCardsWithSameSuit_ReturnsTrue()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Hearts)
            };
            var hand = new Hand(cards);

            Assert.IsTrue(handsChecker.IsFlush(hand));
        }

        // IsFourOfAKind
        [Test]
        public void IsFourOfAKind_WhenFourCardsTheSameFace_ReturnsTrue()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Hearts)
            };
            var hand = new Hand(cards);

            Assert.IsTrue(handsChecker.IsFourOfAKind(hand));
        }

        [Test]
        public void IsFourOfAKind_WhenLessThanFourCardsTheSameFace_ReturnsFalse()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Hearts)
            };
            var hand = new Hand(cards);

            Assert.IsFalse(handsChecker.IsFourOfAKind(hand));
        }

        [Test]
        public void IsFourOfAKind_WhenMoreThanFourCardsTheSameFace_ReturnsFalse()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Hearts)
            };
            var hand = new Hand(cards);

            Assert.IsFalse(handsChecker.IsFourOfAKind(hand));
        }

        // IsOnePair
        [Test]
        public void IsOnePair_WhenOnlyOnePairOfAKind_ReturnsTrue()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Hearts)
            };
            var hand = new Hand(cards);

            Assert.IsTrue(handsChecker.IsOnePair(hand));
        }

        [Test]
        public void IsOnePair_WhenTwoPairsOfDifferentKinds_ReturnsFalse()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Hearts)
            };
            var hand = new Hand(cards);

            Assert.IsFalse(handsChecker.IsOnePair(hand));
        }

        [Test]
        public void IsOnePair_WhenOnePairOfAKindAndThreeOfAnotherKind_ReturnsFalse()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Clubs)
            };
            var hand = new Hand(cards);

            Assert.IsFalse(handsChecker.IsOnePair(hand));
        }

        [Test]
        public void IsOnePair_WhenAllDifferentCards_ReturnsFalse()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs)
            };
            var hand = new Hand(cards);

            Assert.IsFalse(handsChecker.IsOnePair(hand));
        }

        // IsTwoPair
        [Test]
        public void IsTwoPair_WhenTwoPairsOfDifferentKinds_ReturnsTrue()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs)
            };
            var hand = new Hand(cards);

            Assert.IsTrue(handsChecker.IsTwoPair(hand));
        }

        [Test]
        public void IsTwoPair_WhenOnePairOfAKind_ReturnsFalse()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs)
            };
            var hand = new Hand(cards);

            Assert.IsFalse(handsChecker.IsTwoPair(hand));
        }

        [Test]
        public void IsTwoPair_WhenAllDifferentCards_ReturnsFalse()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs)
            };
            var hand = new Hand(cards);

            Assert.IsFalse(handsChecker.IsTwoPair(hand));
        }

        [Test]
        public void IsTwoPair_WhenOnePairOfAKindAndThreeOfAnotherKind_ReturnsFalse()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Clubs)
            };
            var hand = new Hand(cards);

            Assert.IsFalse(handsChecker.IsTwoPair(hand));
        }

        [Test]
        public void IsTwoPair_WhenThreeOfAKind_ReturnsFalse()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Clubs)
            };
            var hand = new Hand(cards);

            Assert.IsFalse(handsChecker.IsTwoPair(hand));
        }

        // IsThreeOfAKind
        [Test]
        public void IsThreeOfAKind_WhenThreeOfOneKindAndTwoOfOtherKind_ReturnsFalse()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Clubs)
            };
            var hand = new Hand(cards);

            Assert.IsFalse(handsChecker.IsThreeOfAKind(hand));
        }

        [Test]
        public void IsThreeOfAKind_WhenThreeOfOneKindAndTwoOfDifferentKinds_ReturnsTrue()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Clubs)
            };
            var hand = new Hand(cards);

            Assert.IsTrue(handsChecker.IsThreeOfAKind(hand));
        }

        // IsFullHouse
        [Test]
        public void IsFullHouse_WhenThreeOfAKindAndPairOfAnotherKind_ReturnsTrue()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Clubs)
            };
            var hand = new Hand(cards);

            Assert.IsTrue(handsChecker.IsFullHouse(hand));
        }

        [Test]
        public void IsFullHouse_WhenOnlyTwoOfAKind_ReturnsFalse()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Clubs)
            };
            var hand = new Hand(cards);

            Assert.IsFalse(handsChecker.IsFullHouse(hand));
        }

        [Test]
        public void IsFullHouse_WhenOnlyThreeOfAKind_ReturnsFalse()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Clubs)
            };
            var hand = new Hand(cards);

            Assert.IsFalse(handsChecker.IsFullHouse(hand));
        }

        [Test]
        public void IsFullHouse_WhenFourOfAKind_ReturnsFalse()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Clubs)
            };
            var hand = new Hand(cards);

            Assert.IsFalse(handsChecker.IsFullHouse(hand));
        }

        [Test]
        public void IsFullHouse_WhenAllCardsAreDifferent_ReturnsFalse()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Clubs)
            };
            var hand = new Hand(cards);

            Assert.IsFalse(handsChecker.IsFullHouse(hand));
        }

        // IsStraight
        [Test]
        public void IsStraight_WhenFiveConsecutiveOfSameSuit_ReturnsFalse()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Clubs)
            };
            var hand = new Hand(cards);

            Assert.IsFalse(handsChecker.IsStraight(hand));
        }

        [Test]
        public void IsStraight_WhenFiveNonConsecutiveOfMixedSuit_ReturnsFalse()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Hearts)
            };
            var hand = new Hand(cards);

            Assert.IsFalse(handsChecker.IsStraight(hand));
        }

        [Test]
        public void IsStraight_WhenFiveConsecutiveOfMixedSuit_ReturnsTrue()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Clubs)
            };
            var hand = new Hand(cards);

            Assert.IsTrue(handsChecker.IsStraight(hand));
        }

        // IsStraightFlush
        [Test]
        public void IsStraightFlush_WhenFiveConsecutiveOfMixedSuit_ReturnsFalse()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Clubs)
            };
            var hand = new Hand(cards);

            Assert.IsFalse(handsChecker.IsStraightFlush(hand));
        }

        [Test]
        public void IsStraightFlush_WhenLessThanFiveConsecutiveOfSameSuit_ReturnsFalse()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts)
            };
            var hand = new Hand(cards);

            Assert.IsFalse(handsChecker.IsStraightFlush(hand));
        }

        [Test]
        public void IsStraightFlush_WhenFiveNonConsecutiveOfSameSuit_ReturnsFalse()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs)
            };
            var hand = new Hand(cards);

            Assert.IsFalse(handsChecker.IsStraightFlush(hand));
        }

        [Test]
        public void IsStraightFlush_WhenFiveConsecutiveOfSameSuit_ReturnsTrue()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Clubs)
            };
            var hand = new Hand(cards);

            Assert.IsTrue(handsChecker.IsStraightFlush(hand));
        }

        // IsHighCard
        [Test]
        public void IsHighCard_WhenFiveNonConsecutiveOfSameSuit_ReturnsFalse()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs)
            };
            var hand = new Hand(cards);

            Assert.IsFalse(handsChecker.IsHighCard(hand));
        }

        [Test]
        public void IsHighCard_WhenFiveConsecutiveOfMixedSuit_ReturnsFalse()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Clubs)
            };
            var hand = new Hand(cards);

            Assert.IsFalse(handsChecker.IsHighCard(hand));
        }

        [Test]
        public void IsHighCard_WhenFiveNonConsecutiveOfMixedSuit_ReturnsTrue()
        {
            var cards = new List<ICard>
            {
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs)
            };
            var hand = new Hand(cards);

            Assert.IsTrue(handsChecker.IsHighCard(hand));
        }
    }
}
