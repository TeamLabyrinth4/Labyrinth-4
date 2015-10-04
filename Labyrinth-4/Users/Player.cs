namespace Labyrinth.Users
{
    using System;

    internal sealed class Player : IPlayer
    {
        private const int StartPositionVertical = 3;
        private const int StartPositionHorizontal = 3;

        private string name;
        private int score;
        private int positionRow;
        private int positionCol;

        public Player(string name)
        {
            this.Name = name;
            this.Score = 0;
            this.PositionRow = StartPositionVertical;
            this.PositionCol = StartPositionHorizontal;
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

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
