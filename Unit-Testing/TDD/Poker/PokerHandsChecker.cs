namespace Poker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PokerHandsChecker : IPokerHandsChecker
    {
        private const int ValidHandCardsCount = 5;
        private const int OnePairCardGroups = 4;
        private const int TwoPairsCardGroups = 3;
        private const int FullHouseCardGroups = 2;

        public bool IsValidHand(IHand hand)
        {
            if (hand == null)
            {
                throw new ArgumentNullException("hand", "Hand is null!");
            }

            if (hand.Cards.Count == 0)
            {
                throw new ArgumentException("Empty hand!");
            }

            if (hand.Cards.Count < ValidHandCardsCount || hand.Cards.Count > ValidHandCardsCount)
            {
                return false;
            }

            int distinctCardsCount = hand.Cards.Distinct().Count();
            bool isValidHand = distinctCardsCount == ValidHandCardsCount;
            return isValidHand;
        }

        public bool IsStraightFlush(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            var cards = hand.Cards;
            if (!this.AreSameSuitCards(cards))
            {
                return false;
            }

            bool isStraightFlush = this.AreConsecutiveCards(cards);
            return isStraightFlush;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            bool isFourOfAKind = hand.Cards.GroupBy(x => x.Face).Any(g => g.Count() == 4);

            return isFourOfAKind;
        }

        public bool IsFullHouse(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            var cardsGroupedByFace = hand.Cards.GroupBy(x => x.Face).ToArray();
            int cardGroupsCount = cardsGroupedByFace.Length;
            bool hasGroupWithThreeCards = cardsGroupedByFace.Any(g => g.Count() == 3);
            bool isFullHouse = hasGroupWithThreeCards && cardGroupsCount == FullHouseCardGroups;

            return isFullHouse;
        }

        public bool IsFlush(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            var cards = hand.Cards;
            bool areSameSuits = this.AreSameSuitCards(cards);
            bool areConsecutive = this.AreConsecutiveCards(cards);
            bool isFlush = areSameSuits && !areConsecutive;

            return isFlush;
        }

        public bool IsStraight(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            var cards = hand.Cards;
            if (!this.AreConsecutiveCards(cards))
            {
                return false;
            }

            bool isStraight = cards.GroupBy(x => x.Suit).Count() > 1;
            return isStraight;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            var cardGroupedByFace = hand.Cards.GroupBy(x => x.Face);
            bool isThreeOfAKind = cardGroupedByFace.Count() == 3 && cardGroupedByFace.Any(g => g.Count() == 3);
            return isThreeOfAKind;
        }

        public bool IsTwoPair(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            var cardGroupedByFace = hand.Cards.GroupBy(x => x.Face);
            bool isTwoPair = (cardGroupedByFace.Count() == TwoPairsCardGroups) &&
                cardGroupedByFace.Any(x => x.Count() == 2);
            return isTwoPair;
        }

        public bool IsOnePair(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            int cardGroupedByKindCount = hand.Cards.GroupBy(x => x.Face).Count();
            bool isOnePair = cardGroupedByKindCount == OnePairCardGroups;
            return isOnePair;
        }

        public bool IsHighCard(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                return false;
            }

            var cards = hand.Cards;
            bool areSameSuit = this.AreSameSuitCards(cards);
            bool areConsecutiveCards = this.AreConsecutiveCards(cards);
            bool isHighCard = !areSameSuit && !areConsecutiveCards;
            return isHighCard;
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }

        private bool AreSameSuitCards(IEnumerable<ICard> cards)
        {
            CardSuit suit = cards.FirstOrDefault().Suit;
            foreach (var card in cards)
            {
                if (card.Suit != suit)
                {
                    return false;
                }
            }

            return true;
        }

        private bool AreConsecutiveCards(ICollection<ICard> cards)
        {
            var cardsOrderedByFace = cards.OrderBy(x => x.Face).ToArray();
            for (int i = 1; i < cardsOrderedByFace.Length; i++)
            {
                int faceDifference = cardsOrderedByFace[i].Face - cardsOrderedByFace[i - 1].Face;
                if (faceDifference != 1)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
