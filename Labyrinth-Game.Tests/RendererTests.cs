namespace Labyrinth_Game.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    using Labyrinth.Renderer;

    [TestClass]
    public class RendererTests
    {
        [TestMethod]
        public void TestIfConsoleRendererReturnsCorrectFinalMessage()
        {
            var render = new ConsoleRenderer();
            var result = render.WriteFinalMessage(5);
            var expected = "Congratulations! You escaped in 5 moves.";
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void TestIfConsoleRendererReturnsCorrectPlayersName()
        {
            var mockedRender = new Mock<IRenderer>();
            mockedRender.Setup(x => x.AddPlayersName()).Returns("Test");
            var render = mockedRender.Object;
            var result = render.AddPlayersName();
            var expected = "Test";
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void TestIfConsoleRendererReturnsCorrectInput()
        {
            var mockedRender = new Mock<IRenderer>();
            mockedRender.Setup(x => x.AddInput()).Returns("Restart");
            var render = mockedRender.Object;
            var result = render.AddInput();
            var expected = "Restart";
            Assert.AreEqual(result, expected);
        }
    }
}
