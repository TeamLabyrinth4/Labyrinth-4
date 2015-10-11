namespace Labyrinth.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Labyrinth.Contexts;

    /// <summary>
    /// Starts a new game.
    /// </summary>
    public class RestartCommand : ICommand
    {
        public RestartCommand(IContext context)
        {
            this.Context = context;
        }

        public IContext Context { get; private set; }

        public void Execute()
        {
            this.Context.StartNewGame();
        }
    }
}
