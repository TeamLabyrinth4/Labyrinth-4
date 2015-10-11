namespace Labyrinth.ObjectBuilder
{
    using System;

    /// <summary>
    /// Setups a colorful console this is a Concrete Decorator class.
    /// </summary>
    public class ConsoleColorableGameBuilder : Decorator
    {
        public ConsoleColorableGameBuilder(IGameObjectBuilder gameObjectBuilder) : base(gameObjectBuilder)
        {
            this.ChangeConsoleColor();
        }     

        private void ChangeConsoleColor()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
    }
}
