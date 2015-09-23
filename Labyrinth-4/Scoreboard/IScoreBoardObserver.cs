namespace Labyrinth
{
    using Labyrinth.Users;

    public interface IScoreBoardObserver
    {
        void ShowScoreboard();

        void Update(IPlayerCloneable player);
    }
}
