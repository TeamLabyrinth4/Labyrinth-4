using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Labyrinth.Commands;
using Labyrinth.Enums;
using Labyrinth.Factories;
using Labyrinth.Contexts;
using Labyrinth.Scoreboard;
using Labyrinth.Renderer;
using Labyrinth.Users;
using Labyrinth.Model;

namespace Labyrinth_Game.Tests
{
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
            this.factory = new CommandFactory(context);
        }        

        [TestMethod]
        public void CreateCommand_WithExit_ShouldCreateExitCommand()
        {
            ICommand command = this.factory.CreateCommand(CommandType.Exit);

            Assert.IsTrue(command.GetType() == typeof(ExitCommand));
        }
       

        [TestMethod]
        public void CreateCommand_WithRestart_ShouldCreateRestartCommand()
        {
            ICommand command = this.factory.CreateCommand(CommandType.Restart);

            Assert.IsTrue(command.GetType() == typeof(RestartCommand));
        }

        [TestMethod]
        public void CreateCommand_WithRestore_ShouldCreateRestoreCommand()
        {
            ICommand command = this.factory.CreateCommand(CommandType.Restore);

            Assert.IsTrue(command.GetType() == typeof(LoadCommand));
        }

        [TestMethod]
        public void CreateCommand_WithTop_ShouldCreateTopScoreCommand()
        {
            ICommand command = this.factory.CreateCommand(CommandType.Top);

            Assert.IsTrue(command.GetType() == typeof(TopCommand));
        }

        [TestMethod]
        public void CreateCommand_WithUndo_ShouldCreateUndoCommand()
        {
            ICommand command = this.factory.CreateCommand(CommandType.Newplayer);

            Assert.IsTrue(command.GetType() == typeof(NewPlayerCommand));
        }

        [TestMethod]
        public void CreateCommand_WithSave_ShouldCreateSaveCommand()
        {
            ICommand command = this.factory.CreateCommand(CommandType.Save);

            Assert.IsTrue(command.GetType() == typeof(SaveCommand));
        }       
    }
}
