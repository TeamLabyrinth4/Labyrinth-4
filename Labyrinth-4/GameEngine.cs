namespace Labyrinth
{
    using System;

    using Commands;
    using Contexts;
    using Enums;
    using Factories;
    using Renderer;
    using Scoreboard;
    using Users;
    using Utilities;
    using Model;

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

        /// <summary>
        /// Creates instance of the game engine object.
        /// </summary>
        /// <param name="player">Accepts any instance of IPlayer.</param>
        /// <param name="renderer">Accepts any instance of IRenderer.</param>
        /// <param name="scoreboard">Accepts any instance of IScoreBoardObserver.</param>
        /// <param name="matrix">Accepts instance of the class LabyrinthMatrix.</param>
        /// <param name="messages">Accepts instance of the class Messages.</param>
        private GameEngine(IPlayer player, IRenderer renderer, IScoreBoardObserver scoreboard, LabyrinthMatrix matrix, Messages messages)
        {
            this.messenger = messages;

            this.context = new Context(scoreboard, renderer, player, matrix);
            this.factory = new CommandFactory(this.context);

            this.Attach(this.context.ScoreboardHandler);
            this.context.StartNewGame();
        }

        /// <summary>
        /// Creates a thread safety Singleton instance of the GameEngine. 
        /// </summary>
        /// <param name="player">Accepts any instance of IPlayer.</param>
        /// <param name="renderer">Accepts any instance of IRenderer.</param>
        /// <param name="scoreboard">Accepts any instance of IScoreBoardObserver.</param>
        /// <param name="matrix">Accepts instance of the class LabyrinthMatrix.</param>
        /// <param name="messages">Accepts instance of the class Messages.</param>
        /// <returns>Instance of the GameEngine class.</returns>
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

        /// <summary>
        /// The method performs the core game logic.
        /// </summary>
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

        /// <summary>
        /// Method for displaying messages to the client.
        /// </summary>
        public void ShowInputMessage()
        {
            this.context.Renderer.ShowMessage(Messages.InputMessage);
        }

        /// <summary>
        /// Method to handle the commands coming from the client.
        /// </summary>
        /// <param name="input">A string input from the client.</param>
        public void HandleInput(string input)
        {
            var lowerInput = input.ToLower();
            ICommand command;

            if (CommandValidator<CommandType>.IsValidCommand(input))
            {
                command = this.factory.CreateCommand(CommandValidator<CommandType>.GetType(input));
                command.Execute();
            }
            else
            {
                this.context.Renderer.ShowMessage(Messages.InvalidMoveMessage);
            }

            this.IsFinished();
        }

        /// <summary>
        /// Method used in Observer pattern to call the update to all attached objects.
        /// </summary>
        /// <param name="player">Instance of IPLayer.</param>
        public override void Notify(IPlayer player)
        {
            foreach (IScoreBoardObserver observer in this.Observers)
            {
                observer.Update(player);
            }
        }

        /// <summary>
        /// Method that handles the ending of the current game.
        /// </summary>
        private void IsFinished()
        {
            if (this.context.Player.PositionCol == Constants.MinimalHorizontalPosition ||
                this.context.Player.PositionCol == Constants.MaximalHorizontalPosition ||
                this.context.Player.PositionRow == Constants.MinimalVerticalPosition ||
                this.context.Player.PositionRow == Constants.MaximalVerticalPosition)
            {
                this.context.Renderer.ShowMessage(this.context.Renderer.WriteFinalMessage(this.context.Player.Score));
                var clone = (IPlayer)this.context.Player.Clone();
                this.Notify(clone);
                this.context.StartNewGame();
            }
        }
    }
}
