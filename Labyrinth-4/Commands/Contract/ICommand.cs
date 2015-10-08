namespace Labyrinth.Commands
{
    using Labyrinth.Contexts;

    public interface ICommand
    {
        IContext Context { get; }

        void Execute();
    }
}
