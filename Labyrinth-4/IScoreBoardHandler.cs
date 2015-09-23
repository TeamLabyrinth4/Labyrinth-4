namespace Labyrinth
{
    using Labyrinth.Users;

    public interface IScoreBoardHandler
    {
        void HandleScoreboard(IPlayerCloneable player);

        void ShowScoreboard();
    }
}
