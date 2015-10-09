namespace Labyrinth
{
    using Labyrinth.Users;

    /// <summary>
    /// The Observer interface giving the required functionality - The 'Subject' interface
    /// </summary>
    public interface IScoreBoardObserver
    {
        void ShowScoreboard();

        void Update(IPlayer player);
    }
}
