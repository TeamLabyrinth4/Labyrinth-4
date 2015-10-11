namespace Labyrinth.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Labyrinth.Contexts;

    /// <summary>
    /// Displays the best player and their score.
    /// </summary>
    public class TopCommand : ICommand
    {
        /// <summary>
        ///  Gets an instance of a show top players command
        /// </summary>
        /// <param name="context">Accepts the current game context.</param> 
        public TopCommand(IContext context)
        {
            this.Context = context;
        }

        public IContext Context { get; private set; }

        public void Execute()
        {
            this.Context.ScoreboardHandler.ShowScoreboard();
        }
    }
}
