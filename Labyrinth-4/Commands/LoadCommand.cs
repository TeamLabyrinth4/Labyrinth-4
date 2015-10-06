namespace Labyrinth.Commands
{
    using Labyrinth.Contexts;
    using Users;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class LoadCommand : ICommand
    {
        public LoadCommand(IContext context)
        {
            this.Context = context;
        }

        public IContext Context { get; private set; }

        public void Execute()
        {
            this.RestoreMemento(this.Context.Memory.Memento);
            this.Context.Renderer.ShowMessage(Messages.Load);
            this.Context.Renderer.ShowMessage(string.Format(Messages.Positions, this.Context.Player.PositionRow, this.Context.Player.PositionCol));
        }

        private void RestoreMemento(Memento mementos)
        {
            this.Context.Player.Score = mementos.Score;
            this.Context.Player.PositionRow = mementos.PositionRow;
            this.Context.Player.PositionCol = mementos.PositionCol;
        }
    }
}
