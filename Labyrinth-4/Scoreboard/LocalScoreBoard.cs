namespace Labyrinth.Scoreboard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Labyrinth.Users;

    /// <summary>
    /// Implementation of a local database of the best players
    /// </summary>
    public class LocalScoreBoard : IScoreboard
    {
        private const int MaxScorebordSize = 5;
        private IList<IPlayer> scoreboard;

        public LocalScoreBoard()
        {
            this.scoreboard = new List<IPlayer>(MaxScorebordSize);
        }

        public void AddToScoreBoard(IPlayer player)
        {
            if (this.scoreboard.Count() >= MaxScorebordSize && player.Score > this.scoreboard.Last().Score)
            {
                Console.WriteLine("You are not good enough for the scoreboard :)");
                return;
            }
            else
            {
                Console.WriteLine("You have been successfully added to the Top 5 Players");                
                this.scoreboard.Add(player);
                this.scoreboard = this.scoreboard.OrderBy(x => x.Score).ToList();
                if (this.scoreboard.Count > MaxScorebordSize)
                {
                    this.scoreboard.RemoveAt(this.scoreboard.Count - 1);
                }
            }
        }

        public IList<IPlayer> ReturnCurrentScoreBoard()
        {
            // TODO: perform a deep clone of the collection / add coresponding pattern
            return new List<IPlayer>(this.scoreboard);
        }
    }
}
