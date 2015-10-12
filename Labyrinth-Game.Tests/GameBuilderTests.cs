using System;
using Labyrinth.Model;
using Labyrinth.ObjectBuilder;
using Labyrinth.Renderer;
using Labyrinth.Scoreboard;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace Labyrinth_Game.Tests
{
    [TestClass]
    public class GameBuilderTests
    {
        [TestMethod]
        public void TestMethodCreateRendererToReturnConsoleRenderer()
        {
            var simpleConsoleGameBuilder = new SimpleConsoleGameBuilder();
            var renderer = simpleConsoleGameBuilder.CreteRenderer();
            Assert.IsTrue(renderer.GetType() == typeof(ConsoleRenderer));
        }

        [TestMethod]
        public void TestCreateLabyrinthMatrixToReturnLabyrintMatrix()
        {
            var simpleConsoleGameBuilder = new SimpleConsoleGameBuilder();
            var labyrinthMatrix = simpleConsoleGameBuilder.CreateLabyrinthMatrix();
            Assert.IsTrue(labyrinthMatrix.GetType() == typeof(LabyrinthMatrix));
        }

        [TestMethod]
        public void TestCreateScoreboardToReturnScoreboard()
        {
            var simpleConsoleGameBuilder = new SimpleConsoleGameBuilder();
            var scoreboard = simpleConsoleGameBuilder.CreateScoreboard();
            Assert.IsTrue(scoreboard.GetType() == typeof(LocalScoreBoard));
        }

        // [TestMethod]
        // public void TestGetUsernameToReturnUsername()
        // {
        //     var simpleConsoleGameBuilder = new SimpleConsoleGameBuilder();           
        //     Assert.IsTrue(username.GetType() == typeof(string));
        // }
    }
}
