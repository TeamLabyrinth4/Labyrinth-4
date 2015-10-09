namespace Labyrinth.Scoreboard
{
    using System.Collections.Generic;

    using Labyrinth.Users;

    /// <summary>
    /// Defines the functionality of the database with the top players.
    /// </summary>
    public interface IScoreboard
    {
        void AddToScoreBoard(IPlayer player);

        IList<IPlayer> ReturnCurrentScoreBoard();
    }
}
