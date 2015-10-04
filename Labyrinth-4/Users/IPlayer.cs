namespace Labyrinth.Users
{
    using System;

    public interface IPlayer : ICloneable
    {
        string Name { get; set; }

        int Score { get; set; }

        int PositionRow { get; set; }

        int PositionCol { get; set; }

        object Clone();
    }
}
