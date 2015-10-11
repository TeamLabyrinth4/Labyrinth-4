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
        /// <summary>
        ///  Gets an instance of a restart command
        /// </summary>
        /// <param name="context">Accepts the current game context.</param> 
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
