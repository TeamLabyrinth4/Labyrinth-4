namespace Labyrinth.Model
{
    using Utilities;
    using System;

    /// <summary>
    /// Generates the playfield of the game.
    /// It uses jagged array, because in The .NET Framework enables faster accesses to them compare to 2D arrays.
    /// </summary>
    public class LabyrinthMatrix
    {
        private char[][] matrix;
        private Random random = new Random();

        /// <summary>
        /// Creates a new playfield for the game.
        /// </summary>
        public LabyrinthMatrix()
        {
            this.matrix = this.CreateMatrix();
        }

        /// <summary>
        /// Gets a jagged array with the playfield.
        /// </summary>
        public char[][] Matrix
        {
            get
            {
                return this.matrix;
            }
        }

        /// <summary>
        /// Generates the playfield.
        /// </summary>
        /// <returns>Returns a jagged array of chars.</returns>
        private char[][] CreateMatrix()
        {
            var matrix = new char[Constants.MatrixRows][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new char[Constants.MatrixCols];
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

        /// <summary>
        /// Creates random generated chars for the playfiled.
        /// </summary>
        /// <returns>Char symbol.</returns>
        private char GetRandomSymbol()
        {
            int randomNumber = this.random.Next(0, 3);

            if (randomNumber == 1)
            {               
                return Constants.BlockedField;
            }
            else
            {
                return Constants.EmptyField;
            }
        }
    }
}
