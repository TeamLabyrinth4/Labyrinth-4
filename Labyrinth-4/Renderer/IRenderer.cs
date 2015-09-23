namespace Labyrinth.Renderer
{
    using Labyrinth.Users;

    public interface IRenderer
    {
        void ShowLabyrinth(LabyrinthMatrix labyrinth, IPlayerCloneable player);

        string AddInput();

        void ShowMessage(string message);         
    }
}
