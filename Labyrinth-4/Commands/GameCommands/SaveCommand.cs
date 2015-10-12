namespace Labyrinth.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Labyrinth.Contexts;
    using Users;
    using Utilities;

    /// <summary>
    /// Saves the game. Used with Memento pattern.
    /// </summary>
    public class SaveCommand : ICommand
    {
        /// <summary>
        ///  Gets an instance of a save command
        /// </summary>
        /// <param name="context">Accepts the current game context.</param> 
        public SaveCommand(IContext context)
        {
            this.Context = context;
        }

        public IContext Context { get; private set; }

        /// <summary>
        /// Saves the game with help of the Memento pattern.
        /// </summary>
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
