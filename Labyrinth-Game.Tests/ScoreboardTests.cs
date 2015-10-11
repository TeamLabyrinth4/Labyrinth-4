using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Labyrinth_Game.Tests
{
    using Labyrinth.Scoreboard;
    using Labyrinth.Users;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System.Collections.Generic;
    using System;
    using System.Text;

    [TestClass]
    public class ScoreboardTests
    {
        private IList<IPlayer> fakeDb = new List<IPlayer>()
        {
            new Player("Test One") { Score = 5 },
            new Player("Test Two") { Score = 7 },
            new Player("Test Three") { Score = 8 },
            new Player("Test Four") { Score = 10 },
        };

        [TestMethod]
        public void TestScoreboardToAddNewPlayer()
        {
            var mockedScoreboard = new Mock<IScoreboard>();
            mockedScoreboard.Setup(x => x.AddToScoreBoard(It.IsAny<IPlayer>()))
                .Callback((IPlayer player) => fakeDb.Add((Player)player));

            var scoreboard = mockedScoreboard.Object;

            var playerToAdd = new Player("Test Five") { Score = 12 };

            scoreboard.AddToScoreBoard(playerToAdd);
            var expectedCount = 5;
            Assert.AreEqual(expectedCount, fakeDb.Count);            
        }

        [TestMethod]
        public void TestScoreboardToReturnCorrectListOfPlayers()
        {
            var mockedScoreboard = new Mock<IScoreboard>();
            
            mockedScoreboard.Setup(x => x.AddToScoreBoard(It.IsAny<IPlayer>()))
                .Callback((IPlayer player) => fakeDb.Add((Player)player));
            mockedScoreboard.Setup(x => x.ReturnCurrentScoreBoard()).Returns(fakeDb);

            var scoreboard = mockedScoreboard.Object;
            var playerToAdd = new Player("Test Five") { Score = 12 };
            scoreboard.AddToScoreBoard(playerToAdd);
            var expectedDb = scoreboard.ReturnCurrentScoreBoard();
            Assert.AreEqual(expectedDb.Count, fakeDb.Count);
        }
    }
}
