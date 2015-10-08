namespace Labyrinth
{
    using Labyrinth.ObjectBuilder;

    public static class AppStart
    {
        public static void Main()
        {
            var constructor = new GameConstructor();
            var gameBuilder = new ConsoleSizeableGameBuilder(new SimpleConsoleGameBuilder());

            // var gameBuilder = new ColorConsoleGameBuilder();           
            var game = constructor.SetupGame(gameBuilder);
            game.GameRun();
        }
    }
}
