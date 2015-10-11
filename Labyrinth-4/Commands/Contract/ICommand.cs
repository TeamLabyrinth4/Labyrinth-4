namespace Labyrinth.Commands
{
    using Labyrinth.Contexts;

    /// <summary>
    /// This is an interface that declares the operations.
    /// </summary>
    public interface ICommand
    {
        IContext Context { get; }

        void Execute();
    }
}
