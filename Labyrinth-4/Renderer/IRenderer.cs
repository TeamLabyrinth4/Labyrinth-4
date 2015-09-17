namespace Labyrinth.Renderer
{
    public interface IRenderer
    {
        void ShowLabyrinth(LabyrinthMatrix labyrinth);
        string AddInput();
    }
}
