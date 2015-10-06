namespace Labyrinth
{
    //TODO:
    //StyleCop formatting 
    //fix ObservePattern
    //fix command 'restart' to generate new matrix not the same;
    //rename class Subject and move it to folder

    using System;
    using Renderer;
    using Users;
    using Factories;
    using Contexts;
    using Commands;
    using Enums;
    using Common;

    public sealed class Game : Subject
    {
        private static volatile Game gameInstance;
        private static object syncLock = new object();
 
        private LabyrinthMatrix matrix;
        private IRenderer renderer;
        private IPlayer player;
        private IScoreBoardObserver scoreBoardHandler;
        private Messages messenger;
        private ICommandFactory factory;
        private IContext context;
        private string input;

        private Game(IPlayer player, IRenderer renderer, IScoreBoardObserver scoreboard)
        {
            this.Attach(scoreBoardHandler);
            this.renderer = renderer;
            this.player = player;
            this.scoreBoardHandler = scoreboard;
            this.messenger = new Messages();

            this.context = new Context(this.scoreBoardHandler, this.renderer, this.player, this.matrix);
            this.factory = new CommandFactory(this.context);
            this.Restart();
        }

        public static Game Instance(IPlayer player, IRenderer renderer, IScoreBoardObserver scoreboard)
        {
            if (gameInstance == null)
            {
                lock (syncLock)
                {
                    if (gameInstance == null)
                    {
                        gameInstance = new Game(player, renderer, scoreboard);
                    }
                }
            }

            return gameInstance;
        }

        public void GameRun()
        {
            while (true)
            {
                this.renderer.ShowLabyrinth(this.matrix, this.player);
                this.ShowInputMessage();
                this.input = this.renderer.AddInput();
                this.HandleInput(this.input);
            }
        }

        public void ShowInputMessage()
        {
            this.renderer.ShowMessage(Messages.InputMessage);
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

            else if (MoveValidator.IsValidComandDir(lowerInput))
            {
                command = new PlayerCommand(this.player, this.matrix.Matrix, lowerInput);
                command.Execute();
            }
            else
            {
                Console.WriteLine("Invalid Command");
            }

            this.IsFinished();
        }

        public void Restart()
        {
            this.renderer.ShowMessage(Messages.WelcomeMessage);
            this.matrix = new LabyrinthMatrix();
            this.player.Score = 0;
            this.player.PositionCol = Constants.StartPositionHorizontal;
            this.player.PositionRow = Constants.StartPositionVertical;
        }

        public override void Notify(IPlayer player)
        {
            foreach (IScoreBoardObserver observer in this.Observers)
            {
               // observer.Update(player);
            }
        }

        private void IsFinished()
        {
            if (this.player.PositionCol == Constants.MinimalHorizontalPosition ||
                this.player.PositionCol == Constants.MaximalHorizontalPosition ||
                this.player.PositionRow == Constants.MinimalVerticalPosition ||
                this.player.PositionRow == Constants.MaximalVerticalPosition)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                this.renderer.ShowMessage(this.messenger.WriteFinalMessage(this.player.Score));
                Console.ResetColor();
                var clone = (IPlayer)this.player.Clone();
                this.Notify(clone);
                this.Restart();
            }
        }
    }
}
