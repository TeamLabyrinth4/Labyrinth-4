namespace Labyrinth_Game.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Labyrinth.Commands;
    using Labyrinth.Enums;
    using Labyrinth.Factories;
    using Labyrinth.Contexts;
    using Labyrinth.Scoreboard;
    using Labyrinth.Renderer;
    using Labyrinth.Users;
    using Labyrinth.Model;

    [TestClass]
    public class CommandFactoryTests
    {
        private ICommandFactory factory;
        private static IScoreboard localScoreBoard = new LocalScoreBoard();
        private static IScoreBoardObserver scoreBoard = new ScoreBoardHandler(localScoreBoard);
        private static IRenderer renderer = new ConsoleRenderer();
        private static IPlayer player = new Player("Ivo");
        private static LabyrinthMatrix matrix = new LabyrinthMatrix();
        private IContext context = new Context(scoreBoard, renderer, player, matrix);

        public CommandFactoryTests()
        {
            this.factory = new CommandFactory(this.context);
        }        

        [TestMethod]
        public void CreateCommandWithExitShouldCreateExitCommand()
        {
            ICommand command = this.factory.CreateCommand(CommandType.Exit);

            Assert.IsTrue(command.GetType() == typeof(ExitCommand));
        }
       

        [TestMethod]
        public void CreateCommandWithRestartShouldCreateRestartCommand()
        {
            ICommand command = this.factory.CreateCommand(CommandType.Restart);

            Assert.IsTrue(command.GetType() == typeof(RestartCommand));
        }

        [TestMethod]
        public void CreateCommandWithRestoreShouldCreateRestoreCommand()
        {
            ICommand command = this.factory.CreateCommand(CommandType.Restore);

            Assert.IsTrue(command.GetType() == typeof(LoadCommand));
        }

        [TestMethod]
        public void CreateCommandWithTopShouldCreateTopScoreCommand()
        {
            ICommand command = this.factory.CreateCommand(CommandType.Top);

            Assert.IsTrue(command.GetType() == typeof(TopCommand));
        }

        [TestMethod]
        public void CreateCommandWithNewPlayerShouldCreateNewPlayerCommand()
        {
            ICommand command = this.factory.CreateCommand(CommandType.Newplayer);

            Assert.IsTrue(command.GetType() == typeof(NewPlayerCommand));
        }

        [TestMethod]
        public void CreateCommandWithSaveShouldCreateSaveCommand()
        {
            ICommand command = this.factory.CreateCommand(CommandType.Save);

            Assert.IsTrue(command.GetType() == typeof(SaveCommand));
        }   
        
        [TestMethod]
        public void CreateCommandWithUShouldCreateMoveUpCommand()
        {
            ICommand command = this.factory.CreateCommand(CommandType.U);

            Assert.IsTrue(command.GetType() == typeof(MoveUpCommand));
        }    
    }
}
