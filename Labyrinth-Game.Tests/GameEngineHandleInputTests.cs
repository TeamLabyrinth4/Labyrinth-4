﻿namespace Labyrinth_Game.Tests
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

            var gameIntance = GameEngine.Instance(playerObject, mockedRenderer.Object, mockedScoreBoardObserver.Object, labyrinthMatrix);

            gameIntance.HandleInput("U");

            Assert.AreEqual(1, playerObject.Score);
        }
    }
}