namespace Labyrinth.Scoreboard
{
    using Labyrinth.Users;
    using System.Collections.Generic;

    public interface IScoreboard
    {
        void AddToScoreBoard(IPlayerCloneable player);

        IList<IPlayerCloneable> ReturnCurrentScoreBoard();
    }
}
