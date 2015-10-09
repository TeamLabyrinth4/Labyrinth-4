namespace Labyrinth.Users
{
    using System;

    /// <summary>
    /// This interface provides all the basic functionalities for a player.
    /// </summary>
    public interface IPlayer : ICloneable
    {
        string Name { get; set; }

        int Score { get; set; }

        int PositionRow { get; set; }

        int PositionCol { get; set; }

        void MoveUp();

        void MoveDown();

        void MoveRight();

        void MoveLeft();
    }
}
