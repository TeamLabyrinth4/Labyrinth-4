namespace Labyrinth
{
    using System;

    /// <summary>
    /// Generates the playfield of the game.
    /// It uses jagged array, because in The .NET Framework enables faster accesses to them compare to 2D arrays.
    /// </summary>
    public class LabyrinthMatrix
    {
        public const int MatrixRows = 17;
        public const int MatrixCols = 17;
        public const char BlockedField = 'X';
        public const char EmptyField = '-';

        private char[][] matrix;
        private Random random = new Random();

        /// <summary>
        /// Creates a new playfield for the game.
        /// </summary>
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
                return BlockedField;
            }
            else
            {
                return EmptyField;
            }
        }
    }
}
