namespace Labyrinth.Users
{
    using System;

    internal class Player : IPlayer
    {
        private string name;
        private int score;
        private int positionRow;
        private int positionCol;

        public Player(string name, int score)
        {
            this.Name = name;
            this.Score = score;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name can not be null or white space");
                }

                this.name = value;
            }
        }

        public int PositionCol
        {
            get
            {
                return this.positionCol;
            }

            set
            {
                this.positionCol = value;
            }
        }

        public int PositionRow
        {
            get
            {
                return this.positionRow;
            }

            set
            {
                this.positionRow = value;
            }
        }

        public int Score
        {
            get
            {
                return this.score;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Score can not be less then zero");
                }

                this.score = value;
            }
        }
    }
}
