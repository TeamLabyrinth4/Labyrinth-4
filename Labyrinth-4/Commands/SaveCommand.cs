namespace Labyrinth.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Labyrinth.Contexts;
    using Users;

    /// <summary>
    /// Saves the game. Used with Memento pattern.
    /// </summary>
    public class SaveCommand : ICommand
    {
        public SaveCommand(IContext context)
        {
            this.Context = context;
        }

        public IContext Context { get; private set; }

        public void Execute()
        {
            this.Context.Memory.Memento = this.SaveMemento();
            this.Context.Renderer.ShowMessage(Messages.Save);
            this.Context.Renderer.ShowMessage(string.Format(Messages.Positions, this.Context.Player.PositionRow, this.Context.Player.PositionCol));
        }

        private Memento SaveMemento()
        {
            return new Memento(this.Context.Player.Score, this.Context.Player.PositionRow, this.Context.Player.PositionCol);
        }
    }
}
