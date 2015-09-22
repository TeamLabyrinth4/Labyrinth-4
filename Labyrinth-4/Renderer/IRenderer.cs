namespace Labyrinth.Renderer
{
    using Labyrinth.Users;

    public interface IRenderer
    {
        void ShowLabyrinth(LabyrinthMatrix labyrinth, IPlayer player);
        string AddInput();
        void ShowWelcomeMessage();
        void ShowInputMessage();
        void ShowGoodByeMessage();
        void ShowInvalidMoveMessage();
        void ShowEscapeLabyrinthMessage(int moves);
    }
}
