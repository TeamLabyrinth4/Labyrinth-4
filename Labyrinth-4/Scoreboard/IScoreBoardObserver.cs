namespace Labyrinth
{
    using Labyrinth.Users;

    /// <summary>
    /// The Observer interface giving the required functionality 
    /// </summary>
    public interface IScoreBoardObserver
    {
        void ShowScoreboard();

        void Update(IPlayer player);
    }
}
