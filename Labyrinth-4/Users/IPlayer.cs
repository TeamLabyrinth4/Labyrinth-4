namespace Labyrinth.Users
{
    public interface IPlayer
    {
        string Name { get; set; }

        int Score { get; set; }

        int PositionRow { get; set; }

        int PositionCol { get; set; }
    }
}
