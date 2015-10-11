namespace Labyrinth.ObjectBuilder
{
    using System;

    /// <summary>
    /// Setups a console game with a fixed window size this is a Concrete Decorator class.
    /// </summary>
    public class ConsoleSizeableGameBuilder : Decorator
    {
        public ConsoleSizeableGameBuilder(IGameObjectBuilder gameObjectBuilder)
            : base(gameObjectBuilder)
        {
            this.ChangeConsoleWindowSize();
        }

        private void ChangeConsoleWindowSize()
        {
            Console.SetWindowSize(100, 50);
        }
    }
}
