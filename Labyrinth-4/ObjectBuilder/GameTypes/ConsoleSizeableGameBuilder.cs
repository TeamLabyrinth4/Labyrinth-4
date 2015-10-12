namespace Labyrinth.ObjectBuilder
{
    using System;

    /// <summary>
    /// Setups a console game with a fixed window size this is a Concrete Decorator class.
    /// </summary>
    public class ConsoleSizeableGameBuilder : Decorator
    {
        /// <summary>
        /// Creates instance of GameObjectBuilder class.
        /// </summary>
        /// <param name="gameObjectBuilder">Can accepts any type of IGameObjectBuilder object.</param>
        public ConsoleSizeableGameBuilder(IGameObjectBuilder gameObjectBuilder)
            : base(gameObjectBuilder)
        {
            this.ChangeConsoleWindowSize();
        }

        public void ChangeConsoleWindowSize()
        {
            Console.SetWindowSize(100, 50);
        }
    }
}
