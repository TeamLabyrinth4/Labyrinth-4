namespace Labyrinth_Game.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Labyrinth.Users;
    using Labyrinth.Renderer;
    using Labyrinth.Scoreboard;
    using Labyrinth.Model;
    using Labyrinth;
    using Labyrinth.Contexts;

    [TestClass]
    public class GameEngineInstanceTests
    {
        private IScoreboard localScoreBoard;
        private IScoreBoardObserver scoreBoard;
        private IRenderer renderer;
        private IPlayer player;
        private LabyrinthMatrix matrix;
        private GameEngine game;
        private IContext context;

        [TestMethod]
        public void IntanceReturnsGameEngineObject()
        {
            this.localScoreBoard = new LocalScoreBoard();
            this.scoreBoard = new ScoreBoardHandler(localScoreBoard);
            this.renderer = new ConsoleRenderer();
            this.player = new Player("Goshou");
            this.matrix = new LabyrinthMatrix();

            this.game = GameEngine.Instance(this.player, this.renderer, this.scoreBoard, this.matrix);
            this.context = this.game.GetCurrentContext();

            Assert.IsTrue(game is GameEngine);
            Assert.AreEqual(8, this.player.PositionRow);
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

        [TestMethod]
        public void IntanceAlwaysReturnsTheSamePlayerNameAsFirstCreational()
        {
            var mockedPlayer = new Mock<IPlayer>();
            var mockedRenderer = new Mock<IRenderer>();
            var mockedScoreBoardObserver = new Mock<IScoreBoardObserver>();
            var labyrinthMatrix = new LabyrinthMatrix();

            mockedPlayer.SetupProperty(x => x.Name, "Ivo");

            var initialGameIntance = GameEngine.Instance(mockedPlayer.Object, mockedRenderer.Object, mockedScoreBoardObserver.Object, labyrinthMatrix);
            var context = initialGameIntance.GetCurrentContext();

            Assert.AreNotEqual(mockedPlayer.Object.Name, context.Player.Name);
            Assert.AreEqual("Goshou", context.Player.Name);
        }

        [TestMethod]
        public void HandleInputWithArgumentRestart()
        {
            var game = GameEngine.Instance(this.player, this.renderer, this.scoreBoard, this.matrix);
            var context = game.GetCurrentContext();

            game.HandleInput("restart");

            Assert.AreEqual(8, context.Player.PositionRow);
            Assert.AreEqual(8, context.Player.PositionCol);
            Assert.AreEqual(0, context.Player.Score);
        }

        [TestMethod]
        public void HandleInputWithArgumentD()
        {
            var game = GameEngine.Instance(this.player, this.renderer, this.scoreBoard, this.matrix);
            var context = game.GetCurrentContext();

            game.HandleInput("D");

            Assert.AreEqual(9, context.Player.PositionRow);
        }

        [TestMethod]
        public void HandleInputWithArgumentR()
        {
            var game = GameEngine.Instance(this.player, this.renderer, this.scoreBoard, this.matrix);
            var context = game.GetCurrentContext();

            game.HandleInput("R");

            Assert.AreEqual(9, context.Player.PositionCol);
        }
    }
}
