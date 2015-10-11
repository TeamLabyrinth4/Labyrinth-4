namespace Labyrinth.Renderer
{
    using System;
    using Model;    
    using Users;

    /// <summary>
    /// A simple renderer used to the display all game information and messages to the client via the console.
    /// </summary>
    public class ConsoleRenderer : IRenderer
    {
        public void ShowLabyrinth(LabyrinthMatrix labyrinth, IPlayer player)
        {
            Console.WriteLine();
            char[][] myMatrix = labyrinth.Matrix;
            for (int i = 0; i < myMatrix.Length; i++)
            {
                for (int j = 0; j < myMatrix[i].Length; j++)
                {
                    if (i == player.PositionRow && j == player.PositionCol)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("*");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(myMatrix[j][i]);
                    }
                }

                Console.WriteLine();
            }
        }

        public void ShowInvalidMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public string AddPlayersName()
        {
            string input = Console.ReadLine();
            return input;
        }

        public string AddInput()
        {
            string input = Console.ReadLine();
            Console.Clear();
            return input;
        }

        /// <summary>
        /// Generates the message with the final result from the game.
        /// </summary>
        /// <param name="moves">The actual result from the game.</param>
        /// <returns>A message to be displayed to the client.</returns>
        public string WriteFinalMessage(int moves)
        {
            return "Congratulations! You escaped in " + moves.ToString() + " moves.";
        }
    }
}
