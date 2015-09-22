namespace Labyrinth
{
    using Labyrinth.Renderer;
    using Labyrinth.Users;
    using System;

    public static class AppStart
    {
        public static void Main()
        {
           
            IRenderer renderer = new ConsoleRenderer();
            IPlayer player = new Player("Test User", 0);
            LabyrinthProcesor processor = new LabyrinthProcesor(renderer, player);
            while (true)
            {
                renderer.ShowLabyrinth(processor.Matrix, player);
                processor.ShowInputMessage();
                string input;
                input = renderer.AddInput();
                processor.HandleInput(input);
            }
        }
    }
}
