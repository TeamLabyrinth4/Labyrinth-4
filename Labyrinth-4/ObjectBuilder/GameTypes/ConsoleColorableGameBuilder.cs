namespace Labyrinth.ObjectBuilder
{
    using System;

    /// <summary>
    /// Setups a colorful console this is a Concrete Decorator class.
    /// </summary>
    public class ConsoleColorableGameBuilder : Decorator
    {
        /// <summary>
        /// Creates instance of GameObjectBuilder class.
        /// </summary>
        /// <param name="gameObjectBuilder">Can accepts any type of IGameObjectBuilder object.</param>
        public ConsoleColorableGameBuilder(IGameObjectBuilder gameObjectBuilder) : base(gameObjectBuilder)
        {
            this.ChangeConsoleColor();
        }     

        public void ChangeConsoleColor()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
    }
}
