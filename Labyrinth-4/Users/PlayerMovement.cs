namespace Labyrinth.Users
{
    using System;

    /// <summary>
    ///  Concrete Flyweight class holding the possible player movements.
    /// </summary>
    [Serializable]
    public class PlayerMovement
    {
        public void MoveDown(IPlayer player)
        {
            player.PositionRow++;
            player.Score++;
        }

        public void MoveUp(IPlayer player)
        {
            player.PositionRow--;
            player.Score++;
        }

        public void MoveRight(IPlayer player)
        {
            player.PositionCol++;
            player.Score++;
        }

        public void MoveLeft(IPlayer player)
        {
            player.PositionCol--;
            player.Score++;
        }
    }
}