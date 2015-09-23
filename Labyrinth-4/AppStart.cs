namespace Labyrinth
{
    public static class AppStart
    {
        public static void Main()
        {
            var game = Game.Instance;
            game.GameRun();
        }
    }
}
