namespace Labyrinth.Users
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;

    /// <summary>
    /// The actual implementation of the IPlayer interfaced.
    /// </summary>
    [Serializable]
    internal sealed class Player : IPlayer
    {
        private PlayerMovement playerMovement = PlayerFactory.GetPlayer();

        private string name;
        private int score;
        private int positionRow;
        private int positionCol;

        public Player(string name)
        {
            this.Name = name;
            this.Score = 0;
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
            // Don't serialize a null object, simply return the default for that object
            if (object.ReferenceEquals(this, null))
            {
                return this;
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();

            using (stream)
            {
                formatter.Serialize(stream, this);
                stream.Seek(0, SeekOrigin.Begin);
                return formatter.Deserialize(stream);
            }
        }

        public void MoveUp()
        {
            this.playerMovement.MoveUp(this);
        }

        public void MoveDown()
        {
            this.playerMovement.MoveDown(this);
        }

        public void MoveRight()
        {
            this.playerMovement.MoveRight(this);
        }

        public void MoveLeft()
        {
            this.playerMovement.MoveLeft(this);
        }
    }
}
