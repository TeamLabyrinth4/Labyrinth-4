namespace Labyrinth.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Labyrinth.Contexts;
    using Labyrinth.Utilities;

    /// <summary>
    /// Moves the player in direction down.
    /// </summary>
    public class MoveDownCommand : ICommand
    {
        /// <summary>
        ///  Gets an instance of a move down command
        /// </summary>
        /// <param name="context">Accepts the current game context.</param> 
        public MoveDownCommand(IContext context)
        {
            this.Context = context;
        }

        public IContext Context { get; private set; }

        public void Execute()
        {
            if (this.Context.Matrix.Matrix[this.Context.Player.PositionCol][this.Context.Player.PositionRow + 1] == '-')
            {
                this.Context.Player.MoveDown();
            }
            else
            {
                this.Context.Renderer.ShowMessage(Messages.LabirinthBlock);
            }
        }
    }
}
