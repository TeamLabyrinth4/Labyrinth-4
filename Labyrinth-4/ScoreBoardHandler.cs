namespace Labyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Users;
    using Labyrinth.Scoreboard;

    // TODO this class creates the class Player, which is terrebly WRONG!
    public class ScoreBoardHandler
    {
        private IScoreboard scoreboard = new LocalScoreBoard();

        public void HandleScoreboard(int moveCount)
        {
            string nickname = this.GetUserName();
            var player = Player.Instace(nickname, moveCount);
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

        private string GetUserName()
        {
            Console.Write("Please enter your name for the top scoreboard: ");
            string nickname = Console.ReadLine();
            return nickname;
        }
    }
}
