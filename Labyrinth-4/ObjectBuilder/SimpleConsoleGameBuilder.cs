namespace Labyrinth.ObjectBuilder
{
    using System;
    using Labyrinth.Renderer;
    using Labyrinth.Users;

    public class SimpleConsoleGameBuilder
    {
        public IPlayer CreatePlayer()
        {
            string username = this.GetUserName();
            return new Player(username);
        }

        public IRenderer CreteRenderer()
        {
            var renderer = new RendererColorable(new ConsoleRenderer());
            renderer.ChangeConsoleColor();
            return renderer;
        }

        public IScoreBoardObserver CreteScoreBoardHanler()
        {
            return new ScoreBoardHandler();
        }

        public string GetUserName()
        {
            Console.Write("Please enter your name for the top scoreboard: ");
            string userName = Console.ReadLine();
            return userName;
        }
    }
}
