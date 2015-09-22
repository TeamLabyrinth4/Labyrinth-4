namespace Labyrinth.Renderer
{
    using Labyrinth.Users;

    public interface IRenderer
    {
        void ShowLabyrinth(LabyrinthMatrix labyrinth, IPlayer player);

        string AddInput();

        void ShowMessage(string message);         
    }
}
