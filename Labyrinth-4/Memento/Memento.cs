namespace Labyrinth.Users
{
    /// <summary>
    /// The 'Memento' class, which will hold information about the players position and score.
    /// </summary>
    public class Memento
    {
        /// <summary>
        /// Creates an instance of memento to hold the needed information for save and load commands.
        /// </summary>
        /// <param name="score">The current player score.</param>
        /// <param name="positionRow">The current player position on the Row.</param>
        /// <param name="positionCol">The current player position on the Column.</param>
        public Memento(int score, int positionRow, int positionCol)
        {
            this.Score = score;
            this.PositionRow = positionRow;
            this.PositionCol = positionCol;
        }

        public int Score { get; set; }

        public int PositionRow { get; set; }

        public int PositionCol { get; set; }
    }
}
