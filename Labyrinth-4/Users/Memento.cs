namespace Labyrinth.Users
{
    public class Memento
    {
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
