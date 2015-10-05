using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth.Renderer
{
    class RendererSizeable : Decorator
    {
        public RendererSizeable(IRenderer renderer)
            : base(renderer)
        {
        }
        public void ShowLabyrinth(LabyrinthMatrix labyrinth, Users.IPlayer player)
        {
            base.ShowLabyrinth(labyrinth, player);
        }

        public string AddInput()
        {
            return base.AddInput();
        }

        public void ShowMessage(string message)
        {
            base.ShowMessage(message);
        }

        public void ChangeConsoleWIndowSize()
        {
            Console.SetWindowSize(150, 60);
        }
    }
}
