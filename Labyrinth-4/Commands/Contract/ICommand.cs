using Labyrinth.Contexts;

namespace Labyrinth.Commands
{
    public interface ICommand
    {
        void Execute();

        IContext Context { get; }
    }
}
