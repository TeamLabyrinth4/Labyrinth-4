namespace Labyrinth.Commands
{
    using Labyrinth.Contexts;

    /// <summary>
    /// This is an interface that declares the operations.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Returns a copy of the contex class.
        /// </summary>
        IContext Context { get; }

        /// <summary>
        /// When the command is recieved this metohd will be executed.
        /// </summary>
        void Execute();
    }
}
