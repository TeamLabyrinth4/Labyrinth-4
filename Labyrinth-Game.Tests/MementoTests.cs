using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Labyrinth.Users;

namespace Labyrinth_Game.Tests
{
    [TestClass]
    public class MementoTests
    {
        [TestMethod]
        public void TestMementoScore()
        {
            var testedMemento = new Memento(10, 5, 5);
            Assert.AreEqual(testedMemento.Score, 10);
            Assert.AreEqual(testedMemento.PositionCol, 5);
            Assert.AreEqual(testedMemento.PositionRow, 5);
        }
    }
}
