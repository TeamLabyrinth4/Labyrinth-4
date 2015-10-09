namespace Labyrinth
{
    using Labyrinth.ObjectBuilder;

    /// <summary>
    /// The start point of the Labyrinth Game.
    /// </summary>
    public static class AppStart
    {
        public static void Main()
        {
            var constructor = new GameConstructor();
            var gameBuilder = new ConsoleSizeableGameBuilder(new SimpleConsoleGameBuilder());

            var game = constructor.SetupGame(gameBuilder);
            game.GameRun();
        }
    }
}
