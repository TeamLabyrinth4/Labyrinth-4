namespace Labyrinth.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Labyrinth.Contexts;
    using Utilities;

    /// <summary>
    /// The class adds a new player in the game.
    /// </summary>
    public class NewPlayerCommand : ICommand
    {
        /// <summary>
        ///  Gets an instance of a new player command
        /// </summary>
        /// <param name="context">Accepts the current game context.</param> 
        public NewPlayerCommand(IContext context)
        {
            this.Context = context;
        }

        public IContext Context { get; private set; }

        public void Execute()
        {
            this.Context.Renderer.ShowMessage(Messages.ChangePlayer);
            this.AddNewPlayer();
        }

        private void AddNewPlayer()
        {
            this.Context.Renderer.ShowMessage("Please enter your name: ");
            string userName = this.Context.Renderer.AddPlayersName();
            this.Context.Player.Name = userName;
            this.Context.StartNewGame();
        }
    }
}