namespace Labyrinth
{
    using System;

    using Commands;
    using Common;
    using Contexts;
    using Enums;
    using Factories;
    using Renderer;
    using Scoreboard;
    using Users;

    /// <summary>
    /// The Game Engine class, which implements thread safe Singleton pattern.
    /// Its is a Facade as well, hiding all the complex logic of the game within its methods.
    /// Implements Observer pattern to handle the end game event.
    /// </summary>
    public sealed class GameEngine : ObserverSubject
    {
        private static volatile GameEngine gameInstance;
        private static object syncLock = new object();

        private Messages messenger;
        private ICommandFactory factory;
        private IContext context;
        private string input;

        private GameEngine(IPlayer player, IRenderer renderer, IScoreBoardObserver scoreboard, LabyrinthMatrix matrix, Messages messages)
        {
            this.messenger = messages;

            this.context = new Context(scoreboard, renderer, player, matrix);
            this.factory = new CommandFactory(this.context);

            this.Attach(this.context.ScoreboardHandler);
            this.context.StartNewGame();
        }

        public static GameEngine Instance(IPlayer player, IRenderer renderer, IScoreBoardObserver scoreboard, LabyrinthMatrix matrix, Messages messages)
        {
            if (gameInstance == null)
            {
                lock (syncLock)
                {
                    if (gameInstance == null)
                    {
                        gameInstance = new GameEngine(player, renderer, scoreboard, matrix, messages);
                    }
                }
            }

            return gameInstance;
        }

        public void GameRun()
        {
            while (true)
            {
                this.context.Renderer.ShowLabyrinth(this.context.Matrix, this.context.Player);
                this.ShowInputMessage();
                this.input = this.context.Renderer.AddInput();
                this.HandleInput(this.input);
            }
        }

        public void ShowInputMessage()
        {
            this.context.Renderer.ShowMessage(Messages.InputMessage);
        }

        public void HandleInput(string input)
        {
            var lowerInput = input.ToLower();
            var commandsValidator = new CommandValidator<CommandType>();
            ICommand command;

            if (commandsValidator.IsValidCommand(input))
            {
                command = this.factory.CreateCommand(commandsValidator.GetType(input));
                command.Execute();
            }
            else
            {
                Console.WriteLine("Invalid Command");
            }

            this.IsFinished();
        }

        public override void Notify(IPlayer player)
        {
            foreach (IScoreBoardObserver observer in this.Observers)
            {
                observer.Update(player);
            }
        }

        private void IsFinished()
        {
            if (this.context.Player.PositionCol == Constants.MinimalHorizontalPosition ||
                this.context.Player.PositionCol == Constants.MaximalHorizontalPosition ||
                this.context.Player.PositionRow == Constants.MinimalVerticalPosition ||
                this.context.Player.PositionRow == Constants.MaximalVerticalPosition)
            {
                this.context.Renderer.ShowMessage(this.messenger.WriteFinalMessage(this.context.Player.Score));
                var clone = (IPlayer)this.context.Player.Clone();
                this.Notify(clone);
                this.context.StartNewGame();
            }
        }
    }
}
