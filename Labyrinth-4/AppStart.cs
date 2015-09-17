namespace Labyrinth
{
    using Labyrinth.Renderer;
    using System;

    public static class AppStart
    {
        public static void Main()
        {
            LabyrinthProcesor processor = new LabyrinthProcesor();
            IRenderer renderer = new ConsoleRenderer();

            while (true)
            {
                renderer.ShowLabyrinth(processor.Matrix);
                processor.ShowInputMessage();
                string input;
                input = Console.ReadLine();
                processor.HandleInput(input);
            }
        }
    }
}
