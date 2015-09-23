using Labyrinth.Renderer;
using Labyrinth.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
{
    public class Game
    {
        private static Game gameInstance;
        private IRenderer renderer;
        private IPlayer player;
        private LabyrinthProcesor processor;

        private Game()
        {
            this.renderer = new ConsoleRenderer();
            string username = GetUserName();
            this.player = new Player(username);
            this.processor = new LabyrinthProcesor(renderer, player);
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
