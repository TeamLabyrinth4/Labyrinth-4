namespace Labyrinth.Contexts
{
    using Labyrinth.Renderer;
    using Labyrinth.Users;

    public interface IContext
    {
        LabyrinthMatrix Matrix { get; set; }

        IPlayer Player { get; }

        IRenderer Renderer { get; }

        IScoreBoardObserver ScoreboardHandler { get; }

        StateMemory Memory { get; }

        void Restart();
    }
}
