namespace Labyrinth.Factories
{
    using System;
    using Labyrinth.Commands;
    using Labyrinth.Contexts;
    using Labyrinth.Enums;
    
    /// <summary>
    /// A Factory interface that will create all commands.
    /// </summary>
    public interface ICommandFactory
    {
        IContext Context { get; }

        ICommand CreateCommand(CommandType input);
    }
}
