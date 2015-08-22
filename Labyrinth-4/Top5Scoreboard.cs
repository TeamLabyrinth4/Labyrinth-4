namespace Labyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Top5Scoreboard
    {
        // TODO IDEA: Create class Player instead using Tuple<uint, string>
        // TODO IDEA: for Top5Scoreboard to use Singelton Pattern, beacuse we need only one object per game
        private const int MaxScorebordSize = 5;
        private IList<Tuple<uint, string>> scoreboard;

        public Top5Scoreboard()
        {
            this.scoreboard = new List<Tuple<uint, string>>(MaxScorebordSize);
        }

        public void HandleScoreboard(uint moveCount)
        {
            if (this.scoreboard.Count() >= MaxScorebordSize && moveCount > this.scoreboard.Last().Item1)
            {
                Console.WriteLine("You are not good enough for the scoreboard :)");
                return;
            }
            // REALLY MESSY Logic
            if (this.scoreboard.Count == 0 ||
                this.scoreboard.Count < MaxScorebordSize && this.scoreboard.Last().Item1 < moveCount)
            {
                string nickname = this.ShowScoreboardInMessage();
                this.scoreboard.Add(new Tuple<uint, string>(moveCount, nickname));
                this.ShowScoreboard();
                return;
            }

            for (int i = 0; i < this.scoreboard.Count(); ++i)
            {
                if (moveCount <= this.scoreboard[i].Item1)
                {
                    string nickname = this.ShowScoreboardInMessage();
                    this.scoreboard.Insert(i, new Tuple<uint, string>(moveCount, nickname));
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
                Console.WriteLine("{0}. {1} --> {2} moves", (i + 1).ToString(), this.scoreboard[i].Item2, this.scoreboard[i].Item1.ToString());
            }
        }

        private string ShowScoreboardInMessage()
        {
            Console.Write("Please enter your name for the top scoreboard: ");
            string nickname = Console.ReadLine();
            return nickname;
        }
    }
}
