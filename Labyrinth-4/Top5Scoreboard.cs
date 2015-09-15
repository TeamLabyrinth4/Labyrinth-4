namespace Labyrinth
{    
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Users;

    public class Top5Scoreboard
    {
        // TODO IDEA: for Top5Scoreboard to use Singelton Pattern, beacuse we need only one object per game
        private const int MaxScorebordSize = 5;
        private IList<IPlayer> scoreboard;

        public Top5Scoreboard()
        {
            this.scoreboard = new List<IPlayer>(MaxScorebordSize);
        }

        public void HandleScoreboard(int moveCount)
        {
            if (this.scoreboard.Count() >= MaxScorebordSize && moveCount > this.scoreboard.Last().Score)
            {
                Console.WriteLine("You are not good enough for the scoreboard :)");
                return;
            }
            // REALLY MESSY Logic
            if (this.scoreboard.Count == 0 ||
                this.scoreboard.Count < MaxScorebordSize && this.scoreboard.Last().Score < moveCount)
            {
                string nickname = this.GetUserName();
                // Връзваме се директно с инстацията на Player!!!
                this.scoreboard.Add(new Player(nickname, moveCount));
                this.ShowScoreboard();
                return;
            }

            for (int i = 0; i < this.scoreboard.Count(); ++i)
            {
                if (moveCount <= this.scoreboard[i].Score)
                {
                    string nickname = this.GetUserName();
                    this.scoreboard.Insert(i, new Player(nickname, moveCount));
                    if (this.scoreboard.Count > MaxScorebordSize)
                    {
                        this.scoreboard.Remove(this.scoreboard.Last());
                    }

                    this.ShowScoreboard();
                    break;
                }
            }
        }

        public void ShowScoreboard()
        {
            if (this.scoreboard.Count == 0)
            {
                Console.WriteLine("The scoreboard is empty.");
                return;
            }

            for (int i = 0; i < this.scoreboard.Count; ++i)
            {
                Console.WriteLine("{0}. {1} --> {2} moves", (i + 1).ToString(), this.scoreboard[i].Name, this.scoreboard[i].Score.ToString());
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
