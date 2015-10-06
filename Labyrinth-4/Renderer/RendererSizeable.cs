namespace Labyrinth.Renderer
{
    using System;

    public class RendererSizeable : Decorator
    {
        public RendererSizeable(IRenderer renderer)
            : base(renderer)
        {
            this.ChangeConsoleWIndowSize();
        }

        private void ChangeConsoleWIndowSize()
        {
            Console.SetWindowSize(150, 60);
        }
    }
}
