namespace Labyrinth.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Labyrinth.Common;
    using Labyrinth.Contexts;

    /// <summary>
    /// Moves the player in direction left.
    /// </summary>
    public class MoveLeftCommand : ICommand
    {
        public MoveLeftCommand(IContext context)
        {
            this.Context = context;
        }

        public IContext Context { get; private set; }

        public void Execute()
        {
            if (!(this.Context.Player.PositionCol == Constants.MinimalHorizontalPosition) &&
                 this.Context.Matrix.Matrix[this.Context.Player.PositionCol - 1][this.Context.Player.PositionRow] == '-')
            {
                this.Context.Player.MoveLeft();
            }
        }
    }
}
