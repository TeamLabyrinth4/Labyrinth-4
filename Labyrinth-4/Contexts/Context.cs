namespace Labyrinth.Contexts
{
    using System;
    using Labyrinth.Renderer;
    using Labyrinth.Users;
    using Common;

    internal class Context : IContext
    {
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

        public void Restart()
        {
            this.Renderer.ShowMessage(Messages.Restarted);
            this.Matrix = new LabyrinthMatrix();
            this.Player.Score = 0;
            this.Player.PositionCol = Constants.StartPositionHorizontal;
            this.Player.PositionRow = Constants.StartPositionVertical;
        }
    }
}
