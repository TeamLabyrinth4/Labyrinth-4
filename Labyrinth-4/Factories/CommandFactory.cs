namespace Labyrinth.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Labyrinth.Commands;
    using Labyrinth.Contexts;
    using Labyrinth.Enums;

    public class CommandFactory : ICommandFactory
    {
        // Flyweight pattern
        private readonly Dictionary<CommandType, ICommand> commands = new Dictionary<CommandType, ICommand>();

        public CommandFactory(IContext context)
        {
            this.Context = context;
        }

        public IContext Context { get; private set; }

        public ICommand CreateCommand(CommandType input)
        {
            if (this.commands.ContainsKey(input))
            {
                return this.commands[input];
            }

            switch (input)
            {
                case CommandType.U:
                    this.commands[CommandType.U] = new MoveUpCommand(this.Context); 
                    break;
                case CommandType.D:
                    this.commands[CommandType.D] = new MoveDownCommand(this.Context); 
                    break;
                case CommandType.R:
                    this.commands[CommandType.R] = new MoveRightCommand(this.Context); 
                    break;
                case CommandType.L:
                    this.commands[CommandType.L] = new MoveLeftCommand(this.Context);
                    break;
                case CommandType.Exit:
                    this.commands[CommandType.Exit] = new ExitCommand(this.Context);
                    break;
                case CommandType.Restart:
                    this.commands[CommandType.Restart] = new RestartCommand(this.Context); 
                    break;
                case CommandType.Top:
                    this.commands[CommandType.Top] = new TopCommand(this.Context); 
                    break;
                case CommandType.Save:
                    this.commands[CommandType.Save] = new SaveCommand(this.Context); 
                    break;
                case CommandType.Restore:
                    this.commands[CommandType.Restore] = new LoadCommand(this.Context); 
                    break;
                case CommandType.Newplayer:
                    this.commands[CommandType.Newplayer] = new NewPlayerCommand(this.Context); 
                    break;
                default:
                    this.commands[CommandType.Restore] = null; 
                    break;
            }

            return this.commands[input];
        }
    }
}
