using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth.ObjectBuilder
{
    public abstract class Decorator : IGameObjectBuilder
    {
        protected IGameObjectBuilder gameObjectBuilder { get; set; }
        protected Decorator(IGameObjectBuilder gameObjectBuilder)
        {
            this.gameObjectBuilder = gameObjectBuilder;
        }
        public Renderer.IRenderer CreteRenderer()
        {
            return this.gameObjectBuilder.CreteRenderer();
        }

        public Users.IPlayer CreatePlayer()
        {
            return this.gameObjectBuilder.CreatePlayer();
        }

        public IScoreBoardObserver CreteScoreBoardHanler()
        {
            return this.gameObjectBuilder.CreteScoreBoardHanler();
        }

        public LabyrinthMatrix CreateLabyrinthMatrix()
        {
            return this.gameObjectBuilder.CreateLabyrinthMatrix();
        }

        public Messages CreateMessages()
        {
            return this.gameObjectBuilder.CreateMessages();
        }

        public string GetUserName()
        {
            return this.gameObjectBuilder.GetUserName();
        }
    }
}
