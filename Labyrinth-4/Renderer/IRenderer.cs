namespace Labyrinth.Renderer
{
    using Labyrinth.Users;

    /// <summary>
    /// The interface defines all methods which will display information to the client.
    /// </summary>
    public interface IRenderer
    {
        void ShowLabyrinth(LabyrinthMatrix labyrinth, IPlayer player);

        string AddInput();

        void ShowMessage(string message);         
    }
}
