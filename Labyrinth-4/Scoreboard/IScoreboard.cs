namespace Labyrinth.Scoreboard
{
    using Labyrinth.Users;
    using System.Collections.Generic;

    public interface IScoreboard
    {
        void AddToScoreBoard(IPlayer player);

        IList<IPlayer> ReturnCurrentScoreBoard();
    }
}
