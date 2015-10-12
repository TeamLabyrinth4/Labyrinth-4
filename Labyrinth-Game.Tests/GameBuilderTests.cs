using System;
using Labyrinth.Model;
using Labyrinth.ObjectBuilder;
using Labyrinth.Renderer;
using Labyrinth.Scoreboard;
using Labyrinth.Users;
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

        [TestMethod]
        public void TestCreateScoreBoardHanlerToReturnScoreboardHandler()
        {
            var simpleConsoleGameBuilder = new SimpleConsoleGameBuilder();
            var scoreboard = simpleConsoleGameBuilder.CreateScoreboard();
            var ScoreBoardHandler = simpleConsoleGameBuilder.CreteScoreBoardHanler(scoreboard);
            Assert.IsTrue(ScoreBoardHandler.GetType() == typeof(ScoreBoardHandler));
        }

        [TestMethod]
        public void TestConsoleSizeableToChangeConsoleWindowSIze()
        {
            var simpleConsoleGameBuilder = new SimpleConsoleGameBuilder();
            var consoleSizeable = new ConsoleSizeableGameBuilder(simpleConsoleGameBuilder);
            consoleSizeable.ChangeConsoleWindowSize();
            var consoleWidth = Console.WindowWidth;
            var consoleHeight = Console.WindowHeight;
            Assert.AreEqual(consoleHeight, 50);
            Assert.AreEqual(consoleWidth, 100);
        }

        [TestMethod]
        public void TestConsoleColorableToChangeConsoleColor()
        {
            var simpleConsoleGameBuilder = new SimpleConsoleGameBuilder();
            var consoleColorable = new ConsoleColorableGameBuilder(simpleConsoleGameBuilder);
            consoleColorable.ChangeConsoleColor();
            var consoleColor = Console.ForegroundColor;           
            Assert.AreEqual(consoleColor, ConsoleColor.Cyan);            
        }     
    }
}
