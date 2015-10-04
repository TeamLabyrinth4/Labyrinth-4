namespace Labyrinth
{
    using System;

    using Labyrinth.Renderer;
    using Labyrinth.Users;

    public sealed class Game
    {
        private static volatile Game gameInstance;
        private IRenderer renderer;
        private IPlayer player;
        private LabyrinthProcesor processor;
        private IScoreBoardObserver scoreBoardHandler;
        private string input;
        private static object syncLock = new object();

        private Game(IPlayer player, IRenderer renderer, IScoreBoardObserver scoreboard, LabyrinthProcesor processor)
        {
            this.renderer = renderer;
            this.player = player;
            this.scoreBoardHandler = scoreboard;
            this.processor = processor;
        }

        public static Game Instance(IPlayer player, IRenderer renderer, IScoreBoardObserver scoreboard, LabyrinthProcesor processor)
        {           
            if (gameInstance == null)
            {
                lock (syncLock)
                {
                    if (gameInstance == null)
                    {
                        gameInstance = new Game(player, renderer, scoreboard, processor);
                    }
                }
            }

            return gameInstance;
        }

        public void GameRun()
        {
            while (true)
            {
                this.renderer.ShowLabyrinth(this.processor.Matrix, this.player);
                this.processor.ShowInputMessage();
                this.input = this.renderer.AddInput();
                this.processor.HandleInput(input);
            }
        }
    }
}
