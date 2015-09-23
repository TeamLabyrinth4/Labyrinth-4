namespace Labyrinth
{
    using Labyrinth.Renderer;
    using Labyrinth.Users;
    using System;

    public class Game
    {
        private static Game gameInstance;
        private IRenderer renderer;
        private IPlayerCloneable player;
        private LabyrinthProcesor processor;
        private IScoreBoardObserver scoreBoardHandler;

        private Game()
        {
            this.renderer = new ConsoleRenderer();
            string username = GetUserName();
            this.player = new Player(username);            
            this.scoreBoardHandler = new ScoreBoardHandler();
            this.processor = new LabyrinthProcesor(renderer, player, scoreBoardHandler);
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
                renderer.ShowLabyrinth(processor.Matrix, player);
                processor.ShowInputMessage();
                string input;
                input = renderer.AddInput();
                processor.HandleInput(input);
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
