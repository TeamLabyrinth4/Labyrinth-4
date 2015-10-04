namespace Labyrinth.Users
{
    public class Memento
    {
        public Memento(int positionRow, int positionCol)
        {
            this.PositionRow = positionRow;
            this.PositionCol = positionCol;
        }

        public int PositionRow { get; set; }

        public int PositionCol { get; set; }
    }
}
