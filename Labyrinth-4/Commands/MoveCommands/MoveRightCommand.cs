namespace Labyrinth.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Labyrinth.Contexts;
    using Labyrinth.Utilities;

    /// <summary>
    /// Moves the player in direction right.
    /// </summary>
    public class MoveRightCommand : ICommand
    {
        /// <summary>
        ///  Gets an instance of a move right command
        /// </summary>
        /// <param name="context">Accepts the current game context.</param> 
        public MoveRightCommand(IContext context)
        {
            this.Context = context;
        }

        public IContext Context { get; private set; }

        public void Execute()
        {
            if (!(this.Context.Player.PositionCol == Constants.MaximalHorizontalPosition) &&
                  this.Context.Matrix.Matrix[this.Context.Player.PositionCol + 1][this.Context.Player.PositionRow] == '-')
            {
                this.Context.Player.MoveRight();
            }
        }
    }
}
