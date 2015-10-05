namespace Labyrinth.ObjectBuilder
{
    using Labyrinth.Renderer;
    using Labyrinth.Users;

    public class GameConstructor
    {
        private IRenderer renderer;
        private IPlayer player;
        private IScoreBoardObserver scoreBoardHandler;
        private LabyrinthProcesor procesor;

        public Game SetupGame(SimpleConsoleGameBuilder objectBuilder)
        {
            this.renderer = objectBuilder.CreteRenderer();
            var rendererColoured = new RendererColorable(this.renderer);
            rendererColoured.ChangeConsoleColor();
            this.player = objectBuilder.CreatePlayer();
            this.scoreBoardHandler = objectBuilder.CreteScoreBoardHanler();
            this.procesor = new LabyrinthProcesor(rendererColoured, this.player, this.scoreBoardHandler);
            return Game.Instance(this.player, rendererColoured, this.scoreBoardHandler, this.procesor);
        }
    }
}
