namespace Labyrinth.ObjectBuilder
{
    using Labyrinth.Renderer;
    using Labyrinth.Users;

    public class GameConstructor
    {
        private IRenderer renderer;
        private IPlayer player;
        private IScoreBoardObserver scoreBoardHandler;
        private Messages messages;

        public Game SetupGame(IGameObjectBuilder objectBuilder)
        {
            this.renderer = objectBuilder.CreteRenderer();
            this.player = objectBuilder.CreatePlayer();
            this.scoreBoardHandler = objectBuilder.CreteScoreBoardHanler();
            this.messages = objectBuilder.CreateMessages();
            return Game.Instance(this.player, this.renderer, this.scoreBoardHandler, this.messages);
        }
    }
}
