namespace Labyrinth.Renderer
{
    using Labyrinth.Model;
    using Labyrinth.Users;

    /// <summary>
    /// The interface defines all methods which will display information to the client.
    /// </summary>
    public interface IRenderer
    {
        void ShowLabyrinth(LabyrinthMatrix labyrinth, IPlayer player);

        string AddInput();

        string AddPlayersName();

        void ShowMessage(string message);

        void ShowInvalidMessage(string message);

        string WriteFinalMessage(int moves);
    }
}
