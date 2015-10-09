namespace Labyrinth.ObjectBuilder
{
    using System;
    using Labyrinth.Renderer;
    using Labyrinth.Users;

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
