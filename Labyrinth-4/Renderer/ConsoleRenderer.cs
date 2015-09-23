namespace Labyrinth.Renderer
{
    using System;
    using Labyrinth.Users;

    public class ConsoleRenderer : IRenderer
    {
        public ConsoleRenderer()
        {
        }

        public void ShowLabyrinth(LabyrinthMatrix labyrinth, IPlayerCloneable player)
        {
            Console.WriteLine();
            char[][] myMatrix = labyrinth.Matrix;
            for (int i = 0; i < myMatrix.Length; i++)
            {
                for (int j = 0; j < myMatrix[i].Length; j++)
                {
                    if (i == player.PositionRow && j == player.PositionCol)
                    {
                        Console.Write("*");
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
            return input;
        }  
    }
}
