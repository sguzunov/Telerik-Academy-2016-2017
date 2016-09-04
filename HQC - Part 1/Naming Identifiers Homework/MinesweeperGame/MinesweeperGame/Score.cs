namespace MinesweeperGame
{
    using System;

    public class Score : IScore
    {
        private string playerName;
        private int points;

        public Score()
        {
        }

        public Score(string playerName, int points)
        {
            this.PlayerName = playerName;
            this.Points = points;
        }

        public string PlayerName
        {
            get
            {
                return this.playerName;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null or empty string!");
                }

                this.playerName = value;
            }
        }

        public int Points
        {
            get
            {
                return this.points;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player score cannot be less than zero!");
                }

                this.points = value;
            }
        }
    }
}
