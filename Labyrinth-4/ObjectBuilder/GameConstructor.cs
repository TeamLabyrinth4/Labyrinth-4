namespace Labyrinth.ObjectBuilder
{
    using Renderer;
    using Scoreboard;
    using Users;

    public class GameConstructor
    {
        private IRenderer renderer;
        private IPlayer player;
        private IScoreBoardObserver scoreBoardHandler;
        private LabyrinthMatrix matrix;
        private Messages messages;
        IScoreboard scoreboard;

        public GameEngine SetupGame(IGameObjectBuilder objectBuilder)
        {
            this.renderer = objectBuilder.CreteRenderer();
            this.player = objectBuilder.CreatePlayer();
            this.scoreboard = objectBuilder.CreateScoreboard();
            this.scoreBoardHandler = objectBuilder.CreteScoreBoardHanler(this.scoreboard);
            this.matrix = objectBuilder.CreateLabyrinthMatrix();
            this.messages = objectBuilder.CreateMessages();

            return GameEngine.Instance(this.player, this.renderer, this.scoreBoardHandler, this.matrix, this.messages);
        }
    }
}
