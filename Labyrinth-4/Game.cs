namespace Labyrinth
{
    using System;

    using Labyrinth.Renderer;
    using Labyrinth.Users;

    public sealed class Game
    {
        private static Game gameInstance;
        private IRenderer renderer;
        private IPlayer player;
        private LabyrinthProcesor processor;
        private IScoreBoardObserver scoreBoardHandler;

        private Game(IPlayer player, IRenderer renderer, IScoreBoardObserver scoreboard)
        {
            this.renderer = renderer;
            this.player = player;
            this.scoreBoardHandler = scoreboard;
            this.processor = new LabyrinthProcesor(this.renderer, this.player, this.scoreBoardHandler);
        }

        public static Game Instance(IPlayer player, IRenderer renderer, IScoreBoardObserver scoreboard)
        {
            if (gameInstance == null)
            {
                gameInstance = new Game(player, renderer, scoreboard);
            }

            return gameInstance;
        }

        public void GameRun()
        {
            while (true)
            {
                this.renderer.ShowLabyrinth(this.processor.Matrix, this.player);
                this.processor.ShowInputMessage();
                string input;
                input = this.renderer.AddInput();
                this.processor.HandleInput(input);
            }
        }
    }
}
