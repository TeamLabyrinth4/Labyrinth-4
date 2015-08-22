﻿namespace Labyrinth
{
    using System;

    public class LabyrinthMatrix
    {
        private char[][] matrix;
        private int myPostionVertical;
        private int myPostionHorizontal;
        private Random random = new Random();

        public LabyrinthMatrix()
        {
            this.myPostionHorizontal = 3;
            this.myPostionVertical = 3;
            this.matrix = new char[7][];

            for (int i = 0; i < this.matrix.Length; i++)
            {
                this.matrix[i] = new char[7];
            }

            for (int i = 0; i < this.matrix.Length; i++)
            {
                for (int j = 0; j < this.matrix[i].Length; j++)
                {
                    this.matrix[i][j] = this.GetRandomSymbol();
                }
            }

            this.matrix[3][3] = '-';
        }

        public LabyrinthMatrix(LabyrinthMatrix labirinth)
        {
        }

        public char[][] Matrix
        {
            get
            {
                return this.matrix;
            }
        }

        public int MyPostionVertical
        {
            get
            {
                return this.myPostionVertical;
            }

            set
            {
                this.myPostionVertical = value;
            }
        }

        public int MyPostionHorizontal
        {
            get
            {
                return this.myPostionHorizontal;
            }

            set
            {
                this.myPostionHorizontal = value;
            }
        }

        private char GetRandomSymbol()
        {
            int random1 = this.random.Next(0, 2);

            if (random1 == 1)
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
