namespace Labyrinth.Contexts
{
    using Labyrinth.Model;
    using Labyrinth.Renderer;
    using Labyrinth.Scoreboard;
    using Labyrinth.Users;

    /// <summary>
    /// Interface setting up all requirements for the context class.
    /// </summary>
    public interface IContext
    {
        LabyrinthMatrix Matrix { get; set; }

        IPlayer Player { get; }

        IRenderer Renderer { get; }

        IScoreBoardObserver ScoreboardHandler { get; }

        StateMemory Memory { get; }

        void StartNewGame();
    }
}
