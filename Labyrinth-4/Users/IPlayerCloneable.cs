namespace Labyrinth.Users
{
    public interface IPlayerCloneable
    {
        string Name { get; set; }

        int Score { get; set; }

        int PositionRow { get; set; }

        int PositionCol { get; set; }

        object Clone();
    }
}
