namespace Labyrinth.Renderer
{
    using System;

    class RendererColorable : Decorator
    {
        public RendererColorable(IRenderer renderer)
            : base(renderer)
        {
            this.ChangeConsoleColor();
        }

        private void ChangeConsoleColor()
        {
           Console.ForegroundColor = ConsoleColor.Cyan;
        }
    }
}
