namespace Labyrinth.ObjectBuilder
{
    using Labyrinth.Renderer;
    using Labyrinth.Users;

    public class GameConstructor
    {
        private IRenderer renderer;
        private IPlayer player;
        private IScoreBoardObserver scoreBoardHandler;

        public void SetupGame(SimpleConsoleGameBuilder objectBuilder)
        {
            this.renderer = objectBuilder.CreteRenderer();
            this.player = objectBuilder.CreatePlayer();
            this.scoreBoardHandler = objectBuilder.CreteScoreBoardHanler();

        }

        public Game InitGame()
        {
            return Game.Instance(this.player, this.renderer, this.scoreBoardHandler);
        }
    }
}
