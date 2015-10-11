namespace Labyrinth
{
    using Labyrinth.ObjectBuilder;

    /// <summary>
    /// The start point of the Labyrinth Game.
    /// </summary>
    public static class AppStart
    {
        /// <summary>
        /// The method initializes the games and then starts it.
        /// </summary>
        public static void Main()
        {
            var constructor = new GameConstructor();
            var gameBuilder = new ConsoleSizeableGameBuilder(new SimpleConsoleGameBuilder());

            var game = constructor.SetupGame(gameBuilder);
            game.GameRun();
        }
    }
}
