namespace Labyrinth
{
    using System;

    using Labyrinth.Renderer;
    using Labyrinth.Users;

    public class Game
    {
        private static Game gameInstance;
        private IRenderer renderer;
        private IPlayer player;
        private LabyrinthProcesor processor;
        private IScoreBoardObserver scoreBoardHandler;

        private Game()
        {
            this.renderer = new ConsoleRenderer();
            string username = this.GetUserName();
            this.player = new Player(username);            
            this.scoreBoardHandler = new ScoreBoardHandler();
            this.processor = new LabyrinthProcesor(this.renderer, this.player, this.scoreBoardHandler);
        }

        public static Game Instance
        {
            get
            {
                if (gameInstance == null)
                {
                    gameInstance = new Game();
                }

                return gameInstance;
            }            
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

        private string GetUserName()
        {
            Console.Write("Please enter your name for the top scoreboard: ");
            string userName = Console.ReadLine();
            return userName;
        }
    }
}
