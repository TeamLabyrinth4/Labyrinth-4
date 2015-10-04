namespace Labyrinth
{
    using Labyrinth.ObjectBuilder;

    public static class AppStart
    {
        public static void Main()
        {
            var constructor = new GameConstructor();
            var gameBuilder = new SimpleConsoleGameBuilder();
            constructor.SetupGame(gameBuilder);
            var game = constructor.InitGame();
            game.GameRun();
        }
    }
}
