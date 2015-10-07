namespace Labyrinth.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Labyrinth.Contexts;
    using Labyrinth.Common;

    public class MoveLeftCommand : ICommand
    {
        public IContext Context { get; private set; }

        public MoveLeftCommand(IContext context)
        {
            this.Context = context;
        }

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
