namespace Labyrinth
{
    using Labyrinth.Renderer;
    using System;

    public static class AppStart
    {
        public static void Main()
        {
           
            IRenderer renderer = new ConsoleRenderer();
            LabyrinthProcesor processor = new LabyrinthProcesor(renderer);
            while (true)
            {
                renderer.ShowLabyrinth(processor.Matrix);
                processor.ShowInputMessage();
                string input;
                input = renderer.AddInput();
                processor.HandleInput(input);
            }
        }
    }
}
