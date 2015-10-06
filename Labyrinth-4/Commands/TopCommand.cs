namespace Labyrinth.Commands
{
    using Labyrinth.Contexts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class TopCommand : ICommand
    {
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
