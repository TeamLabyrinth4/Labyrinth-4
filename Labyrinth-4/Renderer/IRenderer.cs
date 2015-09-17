using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth.Renderer
{
    public interface IRenderer
    {
        void ShowLabyrinth(LabyrinthMatrix labyrinth);
    }
}
