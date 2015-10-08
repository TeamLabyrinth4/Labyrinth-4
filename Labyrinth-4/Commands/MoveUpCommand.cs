namespace Labyrinth.Commands
{    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Labyrinth.Common;
    using Labyrinth.Contexts;

    public class MoveUpCommand : ICommand
    {
        public MoveUpCommand(IContext context)
        {
            this.Context = context;
        }

        public IContext Context { get; private set; }

        public void Execute()
        {
            if (!(this.Context.Player.PositionRow == Constants.MinimalVerticalPosition) &&
                this.Context.Matrix.Matrix[this.Context.Player.PositionCol][this.Context.Player.PositionRow - 1] == '-')
            {
                this.Context.Player.MoveUp();
            }
        }
    }
}
