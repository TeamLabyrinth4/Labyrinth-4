namespace Labyrinth.Commands
{
    using Labyrinth.Contexts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class NewPlayerCommand : ICommand
    {
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
            Console.Write("Please enter your name: ");
            string userName = Console.ReadLine();
            this.Context.Player.Name = userName;
            this.Context.Restart();
        }
    }
}
