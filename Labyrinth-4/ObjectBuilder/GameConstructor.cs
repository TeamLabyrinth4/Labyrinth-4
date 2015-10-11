namespace Labyrinth.ObjectBuilder
{
    using Utilities;
    using Renderer;
    using Scoreboard;
    using Users;
    using Model;

    /// <summary>
    /// The 'Director' class who puts the creating of all game objects in the right order.
    /// taking in mind all dependencies.
    /// </summary>
    public class GameConstructor
    {
        private IRenderer renderer;
        private IPlayer player;
        private IScoreBoardObserver scoreBoardHandler;
        private LabyrinthMatrix matrix;
        private Messages messages;
        private IScoreboard scoreboard;

        /// <summary>
        /// The methods put the creation of the initial game objects in the correct order.
        /// </summary>
        /// <param name="objectBuilder">Gets a concrete builder, which will provide the needed objects.</param>
        /// <returns>Instance of the game engine.</returns>
        public GameEngine SetupGame(IGameObjectBuilder objectBuilder)
        {
            this.renderer = objectBuilder.CreteRenderer();
            this.player = objectBuilder.CreatePlayer();
            this.scoreboard = objectBuilder.CreateScoreboard();
            this.scoreBoardHandler = objectBuilder.CreteScoreBoardHanler(this.scoreboard);
            this.matrix = objectBuilder.CreateLabyrinthMatrix();

            return GameEngine.Instance(this.player, this.renderer, this.scoreBoardHandler, this.matrix);
        }
    }
}
