namespace Labyrinth.Renderer
{
    using System;

    class RendererColorable : Decorator
    {
        public RendererColorable(IRenderer renderer)
            : base(renderer)
        {
        }

        public void ChangeConsoleColor()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
    }
}
