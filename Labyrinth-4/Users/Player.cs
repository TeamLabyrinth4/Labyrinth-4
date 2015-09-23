namespace Labyrinth.Users
{
    using System;

    internal sealed class Player : IPlayer
    {
        private const int StartPositionVertical = 3;
        private const int StartPositionHorizontal = 3;
        private static volatile Player instance;
        private static object syncLock = new object();

        private string name;
        private int score;
        private int positionRow;
        private int positionCol;

        private Player(string name)
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

        public static Player Instace(string name)
        {
            if (instance == null)
            {
                lock (syncLock)
                {
                    if (instance == null)
                    {
                        instance = new Player(name);
                    }
                }
            }

            return instance;
        }
    }
}
