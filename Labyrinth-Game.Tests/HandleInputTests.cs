namespace Labyrinth_Game.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Labyrinth.Users;
    using Labyrinth.Renderer;
    using Labyrinth.Scoreboard;
    using Labyrinth.Model;
    using Labyrinth.Utilities;
    using Labyrinth;
    using Labyrinth.Factories;
    using Labyrinth.Contexts;


    [TestClass]
    public class GameEngineHandleInputTests
    {

        [TestMethod]
        public void HandleInputWithArgumentU()
        {
            IScoreboard localScoreBoard = new LocalScoreBoard();
            IScoreBoardObserver scoreBoard = new ScoreBoardHandler(localScoreBoard);
            IRenderer renderer = new ConsoleRenderer();
            IPlayer player = new Player("Ivo");
            LabyrinthMatrix matrix = new LabyrinthMatrix();
            GameEngine game = GameEngine.Instance(player, renderer, scoreBoard, matrix);
            IContext context = game.GetCurrentContext();

            game.HandleInput("U");

            Assert.AreEqual(7, context.Player.PositionRow);
        }
    }
}
