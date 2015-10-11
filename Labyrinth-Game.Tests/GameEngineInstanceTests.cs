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

    [TestClass]
    public class GameEngineInstanceTests
    {
        [TestMethod]
        public void IntanceReturnsGameEngineObject()
        {
            var mockedPlayer = new Mock<IPlayer>();
            var mockedRenderer = new Mock<IRenderer>();
            var mockedScoreBoardObserver = new Mock<IScoreBoardObserver>();
            var mockedLabyrinthMatrix = new LabyrinthMatrix();

            var game = GameEngine.Instance(mockedPlayer.Object, mockedRenderer.Object, mockedScoreBoardObserver.Object, mockedLabyrinthMatrix);

            Assert.IsTrue(game is GameEngine);
        }
    }
}
