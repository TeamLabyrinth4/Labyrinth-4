namespace Labyrinth
{
    using System;

    using Users;
    using Labyrinth.Scoreboard;

    public class ScoreBoardHandler
    {
        private IScoreboard scoreboard = new LocalScoreBoard();

        public void HandleScoreboard(IPlayerCloneable player)
        {
            scoreboard.AddToScoreBoard(player);
            this.ShowScoreboard();
        }

        public void ShowScoreboard()
        {
            var currentScoreBoard = scoreboard.ReturnCurrentScoreBoard();
            if (currentScoreBoard.Count == 0)
            {
                Console.WriteLine("The scoreboard is empty.");
                return;
            }

            for (int i = 0; i < currentScoreBoard.Count; ++i)
            {
                Console.WriteLine("{0}. {1} --> {2} moves", (i + 1).ToString(), currentScoreBoard[i].Name, currentScoreBoard[i].Score.ToString());
            }
        }        
    }
}
