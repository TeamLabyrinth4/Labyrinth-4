namespace Labyrinth.ObjectBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Decorator : IGameObjectBuilder
    {
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

        public IScoreBoardObserver CreteScoreBoardHanler()
        {
            return this.GameObjectBuilder.CreteScoreBoardHanler();
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
    }
}
