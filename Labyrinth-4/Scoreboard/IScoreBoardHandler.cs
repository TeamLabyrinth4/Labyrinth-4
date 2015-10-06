namespace Labyrinth
{
    using Labyrinth.Users;

    public interface IScoreBoardHandler
    {
        void HandleScoreboard(IPlayer player);

        void ShowScoreboard();
    }
}