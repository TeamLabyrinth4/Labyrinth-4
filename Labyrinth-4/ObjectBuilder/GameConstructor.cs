namespace Labyrinth.ObjectBuilder
{
    using Labyrinth.Renderer;
    using Labyrinth.Users;

    public class GameConstructor
    {
        private IRenderer renderer;
        private IPlayer player;
        private IScoreBoardObserver scoreBoardHandler;
        private LabyrinthMatrix matrix;
        private Messages messages;

        public GameEngine SetupGame(IGameObjectBuilder objectBuilder)
        {
            this.renderer = objectBuilder.CreteRenderer();
            this.player = objectBuilder.CreatePlayer();
            this.scoreBoardHandler = objectBuilder.CreteScoreBoardHanler();
            this.matrix = objectBuilder.CreateLabyrinthMatrix();
            this.messages = objectBuilder.CreateMessages();

            return GameEngine.Instance(this.player, this.renderer, this.scoreBoardHandler, this.matrix, this.messages);
        }
    }
}
