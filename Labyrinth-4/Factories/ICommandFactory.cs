using Labyrinth.Commands;
using Labyrinth.Contexts;
using Labyrinth.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth.Factories
{
    public interface ICommandFactory
    {
        IContext Context { get; }

        ICommand CreateCommand(CommandType input);
    }
}
