namespace Labyrinth.Commands
{
    using System;
    using Labyrinth.Contexts;

    /// <summary>
    /// The class performs exit from the game.
    /// </summary>
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