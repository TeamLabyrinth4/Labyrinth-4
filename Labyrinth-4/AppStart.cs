namespace Labyrinth
{
    using Labyrinth.Renderer;
    using Labyrinth.Users;
    using System;

    public static class AppStart
    {
        public static void Main()
        {
            var game = Game.Instance;
            game.GameRun();
        }
    }
}
