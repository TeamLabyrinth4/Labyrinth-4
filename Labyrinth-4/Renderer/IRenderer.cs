namespace Labyrinth.Renderer
{
    public interface IRenderer
    {
        void ShowLabyrinth(LabyrinthMatrix labyrinth);
        string AddInput();
        void ShowWelcomeMessage();
        void ShowInputMessage();
        void ShowGoodByeMessage();
        void ShowInvalidMoveMessage();
        void ShowEscapeLabyrinthMessage(int moves);
    }
}
