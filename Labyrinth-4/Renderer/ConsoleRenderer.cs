namespace Labyrinth.Renderer
{
    using System;
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

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public string AddInput()
        {
            string input = Console.ReadLine();
            Console.Clear();
            return input;
        }
    }
}
