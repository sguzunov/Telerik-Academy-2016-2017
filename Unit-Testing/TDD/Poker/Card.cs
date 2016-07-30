namespace Poker
{
    using System;

    public class Card : ICard
    {
        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public override string ToString()
        {
            string faceString = this.GetCardFaceString();
            string suitString = this.GetCardSuitString();

            return faceString + suitString;
        }

        public override bool Equals(object obj)
        {
            ICard otherCard = obj as ICard;
            if (otherCard == null)
            {
                return false;
            }

            return this.Face == otherCard.Face && this.Suit == otherCard.Suit;
        }

        public override int GetHashCode()
        {
            int hash = 13;
            unchecked
            {
                hash = (hash * 7) + (int)this.Face;
                hash = (hash * 7) + (int)this.Suit;
            }

            return hash;
        }

        private string GetCardSuitString()
        {
            switch (this.Suit)
            {
                case CardSuit.Clubs:
                    return "♣";
                case CardSuit.Diamonds:
                    return "♦";
                case CardSuit.Hearts:
                    return "♥";
                case CardSuit.Spades:
                    return "♠";
                default:
                    throw new ArgumentException("Such a card suit does not exists!");
            }
        }

        private string GetCardFaceString()
        {
            switch (this.Face)
            {
                case CardFace.Two:
                    return "2";
                case CardFace.Three:
                    return "3";
                case CardFace.Four:
                    return "4";
                case CardFace.Five:
                    return "5";
                case CardFace.Six:
                    return "6";
                case CardFace.Seven:
                    return "7";
                case CardFace.Eight:
                    return "8";
                case CardFace.Nine:
                    return "9";
                case CardFace.Ten:
                    return "10";
                case CardFace.Jack:
                    return "J";
                case CardFace.Queen:
                    return "Q";
                case CardFace.King:
                    return "K";
                case CardFace.Ace:
                    return "A";
                default:
                    throw new ArgumentException("Such a card face does not exists!");
            }
        }
    }
}
