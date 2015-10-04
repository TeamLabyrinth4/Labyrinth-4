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
            this.player = objectBuilder.CreatePlayer();
            this.scoreBoardHandler = objectBuilder.CreteScoreBoardHanler();
            this.procesor = new LabyrinthProcesor(this.renderer, this.player, this.scoreBoardHandler);
            return Game.Instance(this.player, this.renderer, this.scoreBoardHandler, this.procesor);
        }
    }
}
