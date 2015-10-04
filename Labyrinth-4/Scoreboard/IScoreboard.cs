namespace Labyrinth.Scoreboard
{
    using System.Collections.Generic;

    using Labyrinth.Users;

    public interface IScoreboard
    {
        void AddToScoreBoard(IPlayer player);

        IList<IPlayer> ReturnCurrentScoreBoard();
    }
}
