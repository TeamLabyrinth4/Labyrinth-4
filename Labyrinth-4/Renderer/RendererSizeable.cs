namespace Labyrinth.Renderer
{
    using System;

    public class RendererSizeable : Decorator
    {
        public RendererSizeable(IRenderer renderer)
            : base(renderer)
        {
        }

        public void ChangeConsoleWIndowSize()
        {
            Console.SetWindowSize(150, 60);
        }
    }
}
