namespace Labyrinth.ObjectBuilder
{
    using Scoreboard;

    /// <summary>
    /// A Decorator class which wrap the IGameObjectBuilder interface in order to add new functionality.
    /// </summary>
    public abstract class Decorator : IGameObjectBuilder
    {
        /// <summary>
        /// Creates instance of the basic Decorator class.
        /// </summary>
        /// <param name="gameObjectBuilder">Can accepts any type of IGameObjectBuilder object.</param>
        protected Decorator(IGameObjectBuilder gameObjectBuilder)
        {
            this.GameObjectBuilder = gameObjectBuilder;
        }

        protected IGameObjectBuilder GameObjectBuilder { get; set; }

        public Renderer.IRenderer CreteRenderer()
        {
            return this.GameObjectBuilder.CreteRenderer();
        }

        public Users.IPlayer CreatePlayer()
        {
            return this.GameObjectBuilder.CreatePlayer();
        }

        public IScoreBoardObserver CreteScoreBoardHanler(IScoreboard scoreboard)
        {
            return this.GameObjectBuilder.CreteScoreBoardHanler(scoreboard);
        }

        public LabyrinthMatrix CreateLabyrinthMatrix()
        {
            return this.GameObjectBuilder.CreateLabyrinthMatrix();
        }

        public Messages CreateMessages()
        {
            return this.GameObjectBuilder.CreateMessages();
        }

        public string GetUserName()
        {
            return this.GameObjectBuilder.GetUserName();
        }

        public IScoreboard CreateScoreboard()
        {
            return new LocalScoreBoard();
        }
    }
}
