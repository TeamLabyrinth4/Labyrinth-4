namespace Labyrinth.Factories
{
    using System;
    using Labyrinth.Commands;
    using Labyrinth.Contexts;
    using Labyrinth.Enums;
    
    public interface ICommandFactory
    {
        IContext Context { get; }

        ICommand CreateCommand(CommandType input);
    }
}
