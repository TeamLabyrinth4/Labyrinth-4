namespace Labyrinth
{
    using Labyrinth.Commands;
    using Labyrinth.Renderer;
    using Labyrinth.Users;

    public class LabyrinthProcesor : Subject
    {
        public const int MaximalHorizontalPosition = 6;
        public const int MinimalHorizontalPosition = 0;
        public const int MaximalVerticalPosition = 6;
        public const int MinimalVerticalPosition = 0;

        private LabyrinthMatrix matrix;
        private IRenderer renderer;
        private IPlayer player;
        private Messenger messenger;
        private IScoreBoardObserver scoreBoardHandler;
        internal StateMemory memory = new StateMemory();

        public LabyrinthProcesor(IRenderer renderer, IPlayer player, IScoreBoardObserver scoreBoardHandler)
        {
            this.Attach(scoreBoardHandler);
            this.messenger = new Messenger();
            this.scoreBoardHandler = scoreBoardHandler;
            this.renderer = renderer;
            this.player = player;
            this.Restart();
        }

        public LabyrinthMatrix Matrix
        {
            get { return this.matrix; }
            set { this.matrix = value; }
        }

        public void ShowInputMessage()
        {
            this.renderer.ShowMessage(Messenger.InputMessage);
        }

        public void HandleInput(string input)
        {
            string lowerInput = input.ToLower();
            Command command;

            if (lowerInput.Length == 1)
            {
                command = new PlayerCommand(this.player, this.matrix.Matrix, lowerInput);
            }
            else
            {
                command = new GameCommand(this, this.scoreBoardHandler, this.renderer, this.player, lowerInput);
            }

            command.Execute();

            this.IsFinished();
        }

        public void Restart()
        {
            this.renderer.ShowMessage(Messenger.WelcomeMessage);
            this.matrix = new LabyrinthMatrix();
            this.player.Score = 0;
            this.player.PositionCol = 3;
            this.player.PositionRow = 3;
        }

        public override void Notify(IPlayer player)
        {
            foreach (IScoreBoardObserver observer in this.Observers)
            {
                observer.Update(player);
            }
        }

        private void IsFinished()
        {
            if (this.player.PositionCol == MinimalHorizontalPosition ||
                this.player.PositionCol == MaximalHorizontalPosition ||
                this.player.PositionRow == MinimalVerticalPosition ||
                this.player.PositionRow == MaximalVerticalPosition)
            {
                this.renderer.ShowMessage(this.messenger.WriteFinalMessage(this.player.Score));
                var clone = (IPlayer)this.player.Clone();
                this.Notify(clone);
                this.Restart();
            }
        }
    }
}
