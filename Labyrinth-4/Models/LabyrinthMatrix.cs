namespace Labyrinth
{
    using System;

    public class LabyrinthMatrix
    {
        public const int MatrixRows = 11;
        public const int MatrixCols = 11;

        private char[][] matrix;
        private Random random = new Random();

        public LabyrinthMatrix()
        {
            this.matrix = this.CreateMatrix();
        }

        public char[][] Matrix
        {
            get
            {
                return this.matrix;
            }
        }

        private char[][] CreateMatrix()
        {
            var matrix = new char[MatrixRows][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new char[MatrixCols];
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = this.GetRandomSymbol();
                }
            }

            return matrix;
        }

        private char GetRandomSymbol()
        {
            int randomNumber = this.random.Next(0, 3);

            if (randomNumber == 1)
            {               
                return 'X';
            }
            else
            {
                return '-';
            }
        }
    }
}
