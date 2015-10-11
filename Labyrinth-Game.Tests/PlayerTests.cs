namespace Labyrinth_Game.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    using Labyrinth.Users;

    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void TestsToCreateAValidPlayer()
        {
            var player = new Player("Test");
            var expectedName = "Test";
            Assert.AreEqual(expectedName, player.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestInvalidPlayerNameShouldThrow()
        {
            var player = new Player(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestInvalidPlayerScoreShouldThrow()
        {
            var player = new Player("Test");
            player.Score = -1;
        }

        [TestMethod]
        public void TestsPlayerMovementUpToChangeThePosition()
        {
            var player = new Player("Test");
            player.PositionCol = 3;
            player.PositionRow = 3;
            player.MoveUp();
            var expetedRowPosition = 2;
            Assert.AreEqual(expetedRowPosition, player.PositionRow);
        }

        [TestMethod]
        public void TestsPlayerMovementDownToChangeThePosition()
        {
            var player = new Player("Test");
            player.PositionCol = 3;
            player.PositionRow = 3;
            player.MoveDown();
            var expetedRowPosition = 4;
            Assert.AreEqual(expetedRowPosition, player.PositionRow);
        }

        [TestMethod]
        public void TestsPlayerMovementLeftToChangeThePosition()
        {
            var player = new Player("Test");
            player.PositionCol = 3;
            player.PositionRow = 3;
            player.MoveLeft();
            var expetedColPosition = 2;
            Assert.AreEqual(expetedColPosition, player.PositionCol);
        }

        [TestMethod]
        public void TestsPlayerMovementRightToChangeThePosition()
        {
            var player = new Player("Test");
            player.PositionCol = 3;
            player.PositionRow = 3;
            player.MoveRight();
            var expetedColPosition = 4;
            Assert.AreEqual(expetedColPosition, player.PositionCol);
        }

        [TestMethod]
        public void TestsIfScoreIsValidAfterMoveingThePLayer()
        {
            var player = new Player("Test");
            player.PositionCol = 3;
            player.PositionRow = 3;
            player.MoveRight();
            player.MoveRight();
            player.MoveRight();
            player.MoveUp();
            var expectedScore = 4;
            Assert.AreEqual(expectedScore, player.Score);
        }
    }
}
