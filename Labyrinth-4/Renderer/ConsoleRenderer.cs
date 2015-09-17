namespace Labyrinth.Renderer
{
    using System;

    public class ConsoleRenderer : IRenderer
    {
        public ConsoleRenderer()
        {
        }

        public void ShowLabyrinth(LabyrinthMatrix labyrinth)
        {
            Console.WriteLine();
            char[][] myMatrix = labyrinth.Matrix;
            for (int i = 0; i < myMatrix.Length; i++)
            {
                for (int j = 0; j < myMatrix[i].Length; j++)
                {
                    if (i == labyrinth.MyPostionVertical && j == labyrinth.MyPostionHorizontal)
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
    }
}
