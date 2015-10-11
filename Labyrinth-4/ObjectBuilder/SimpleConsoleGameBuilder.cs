namespace Labyrinth.ObjectBuilder
{
    using System;

    using Renderer;
    using Scoreboard;
    using Users;
    using Model;
    using Utilities;

    /// <summary>
    /// The 'ConcreteBuilder' class, it creates all needed object for a simple console game.
    /// </summary>
    public class SimpleConsoleGameBuilder : IGameObjectBuilder
    {
        public IPlayer CreatePlayer()
        {
            string username = this.GetUserName();
            return new Player(username);
        }

        public IRenderer CreteRenderer()
        {
            return new ConsoleRenderer();
        }

        public IScoreBoardObserver CreteScoreBoardHanler(IScoreboard scoreboard)
        {
            return new ScoreBoardHandler(scoreboard);
        }

        public LabyrinthMatrix CreateLabyrinthMatrix()
        {
            return new LabyrinthMatrix();
        }

        public string GetUserName()
        {
            Console.Write("Please enter your name for the top scoreboard: ");
            string userName = Console.ReadLine();
            return userName;
        }

        public Messages CreateMessages()
        {
            return new Messages();
        }

        public IScoreboard CreateScoreboard()
        {
            return new LocalScoreBoard();
        }
    }
}
