namespace Labyrinth.Contexts
{
    using System;
    using Labyrinth.Model;
    using Labyrinth.Renderer;
    using Labyrinth.Scoreboard;
    using Labyrinth.Users;
    using Labyrinth.Utilities;

    /// <summary>
    /// Implemets the IContext interface
    /// </summary>
    internal class Context : IContext
    {
        /// <summary>
        /// Creates instance of the context object.
        /// </summary>
        /// <param name="player">Accepts any instance of IPlayer.</param>
        /// <param name="renderer">Accepts any instance of IRenderer.</param>
        /// <param name="scoreboard">Accepts any instance of IScoreBoardObserver.</param>
        /// <param name="matrix">Accepts instance of the class LabyrinthMatrix.</param>
        public Context(IScoreBoardObserver scoreboardHandler, IRenderer renderer, IPlayer player, LabyrinthMatrix matrix)
        {
            this.ScoreboardHandler = scoreboardHandler;
            this.Renderer = renderer;
            this.Player = player;
            this.Matrix = matrix;
            this.Memory = new StateMemory();
        }

        public StateMemory Memory { get; set; }

        public LabyrinthMatrix Matrix { get; set; }

        public IPlayer Player { get; set; }

        public IRenderer Renderer { get; set; }

        public IScoreBoardObserver ScoreboardHandler { get; set; }


        /// <summary>
        /// Void method used for start new game.Returns player position into start position and zero score.
        /// </summary>
        public void StartNewGame()
        {
            this.Renderer.ShowMessage(Messages.StartNewGame);
            this.Matrix = new LabyrinthMatrix();
            this.Player.Score = 0;
            this.Player.PositionCol = Constants.StartPositionHorizontal;
            this.Player.PositionRow = Constants.StartPositionVertical;
        }
    }
}
