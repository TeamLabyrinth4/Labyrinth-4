namespace Labyrinth.ObjectBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

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
