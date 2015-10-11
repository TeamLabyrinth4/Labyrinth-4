namespace Labyrinth.Scoreboard
{
    using System;

    using Users;
    using Utilities;

    /// <summary>
    /// The 'ConcreteObserver' class, who manages the relation with the databases with top players.
    /// </summary>
    public class ScoreBoardHandler : IScoreBoardObserver
    {
        private IScoreboard scoreboard;

        /// <summary>
        /// Creates an object which will handle the relation with the database.
        /// </summary>
        /// <param name="scoreboard">A Scoreboard object to store the result.</param>
        public ScoreBoardHandler(IScoreboard scoreboard)
        {
            this.scoreboard = scoreboard;
        }

        public void Update(IPlayer player)
        {
            this.scoreboard.AddToScoreBoard(player);
            this.ShowScoreboard();
        }

        public void ShowScoreboard()
        {
            var currentScoreBoard = this.scoreboard.ReturnCurrentScoreBoard();
            if (currentScoreBoard.Count == 0)
            {
                Console.WriteLine(Messages.EmptyScoreBoard);
                return;
            }

            Console.WriteLine(Messages.ScoreBoardHeader);
            for (int i = 0; i < currentScoreBoard.Count; ++i)
            {
                Console.WriteLine("{0}. {1} --> {2} moves", (i + 1).ToString(), currentScoreBoard[i].Name, currentScoreBoard[i].Score.ToString());
            }
        }        
    }
}
