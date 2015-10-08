namespace Labyrinth.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Labyrinth.Contexts;

    public class ExitCommand : ICommand
    {
        public ExitCommand(IContext context)
        {
            this.Context = context;
        }

        public IContext Context { get; private set; }

        public void Execute()
        {
            this.Context.Renderer.ShowMessage(Messages.GoodBye);
            System.Environment.Exit(0);
        }
    }
}