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
            var labyrinthMatrix = new LabyrinthMatrix();

            var game = GameEngine.Instance(mockedPlayer.Object, mockedRenderer.Object, mockedScoreBoardObserver.Object, labyrinthMatrix);

            Assert.IsTrue(game is GameEngine);
        }

        [TestMethod]
        public void IntanceAlwaysReturnsTheSameGameEngineIntance()
        {
            var mockedPlayer = new Mock<IPlayer>();
            var mockedRenderer = new Mock<IRenderer>();
            var mockedScoreBoardObserver = new Mock<IScoreBoardObserver>();
            var labyrinthMatrix = new LabyrinthMatrix();

            mockedPlayer.SetupProperty(x => x.Name, "Stamat");

            var initialGameIntance = GameEngine.Instance(mockedPlayer.Object, mockedRenderer.Object, mockedScoreBoardObserver.Object, labyrinthMatrix);

            mockedPlayer = new Mock<IPlayer>();
            mockedPlayer.SetupProperty(x => x.Name, "Pesho");

            var secondGameInstance = GameEngine.Instance(mockedPlayer.Object, mockedRenderer.Object, mockedScoreBoardObserver.Object, labyrinthMatrix);

            Assert.AreEqual(initialGameIntance, secondGameInstance);
        }
    }
}
