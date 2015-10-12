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
    public class GameEngineHandleInputTests
    {
        [TestMethod]
        public void HandleInputWithArgumentU()
        {
            var mockedPlayer = new Mock<IPlayer>();
            var mockedRenderer = new Mock<IRenderer>();
            var mockedScoreBoardObserver = new Mock<IScoreBoardObserver>();
            var labyrinthMatrix = new LabyrinthMatrix();

            mockedPlayer.SetupProperty(x => x.PositionCol, 3);
            mockedPlayer.SetupProperty(x => x.PositionRow, 3);
            mockedPlayer.SetupProperty(x => x.Score, 0);

            var playerObject = mockedPlayer.Object;

            var mockedGameInstance = new Mock<GameEngine>();
            mockedGameInstance.Setup(x => x.HandleInput(It.Is<string>(s => s.StartsWith("U")))).Verifiable("Up Move Invoked");
            var fakeeGame = mockedGameInstance.Object;

            var fakeGameIntance = GameEngine.Instance(playerObject, mockedRenderer.Object, mockedScoreBoardObserver.Object, labyrinthMatrix);
            

            fakeGameIntance.HandleInput("U");

            
        }
    }
}
