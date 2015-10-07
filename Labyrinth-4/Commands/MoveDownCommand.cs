namespace Labyrinth.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Labyrinth.Contexts;
    using Labyrinth.Common;

    public class MoveDownCommand : ICommand
    {
        public IContext Context { get; private set; }

        public MoveDownCommand(IContext context)
        {
            this.Context = context;
        }

        public void Execute()
        {
            if (!(this.Context.Player.PositionRow == Constants.MinimalVerticalPosition) &&
                this.Context.Matrix.Matrix[this.Context.Player.PositionCol][this.Context.Player.PositionRow + 1] == '-')
            {
                this.Context.Player.MoveDown();
            }
        }
    }
}
