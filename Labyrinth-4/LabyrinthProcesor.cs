namespace Labyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class LabyrinthProcesor
    {
        public const int MaximalHorizontalPosition = 6;
        public const int MinimalHorizontalPosition = 0;
        public const int MaximalVerticalPosition = 6;
        public const int MinimalVerticalPosition = 0;

        private LabyrinthMatrix matrix;
        private uint moveCount;
        private Top5Scoreboard scoreboard;       

        public LabyrinthProcesor()
        {
            this.scoreboard = new Top5Scoreboard();
            this.Restart();
        }

        public LabyrinthMatrix Matrix
        {
            get { return this.matrix; }
            set { this.matrix = value; }
        }

        public void ShowInputMessage()
        {
            Console.Write("Enter your move (L=left, R-right, U=up, D=down): ");
        }

        public void HandleInput(string input)
        {
            string lowerInput = input.ToLower();

            switch (lowerInput)
            {
                case "l":
                    if (!this.MoveLeft())
                    {
                        Console.WriteLine("Invalid move!");
                    }

                break;

                case "r":
                    if (!this.MoveRight())
                    {
                        Console.WriteLine("Invalid move!");
                    }

                break;

                case "u":
                    if (!this.MoveUp())
                    {
                        Console.WriteLine("Invalid move!");
                    }

                break;

                case "d":
                    if (!this.MoveDown())
                    {
                        Console.WriteLine("Invalid move!");
                    }

                break;

                case "top":
                    this.scoreboard.ShowScoreboard();
                break;

                case "restart":
                    this.Restart();
                break;

                case "exit":
                    Console.WriteLine("Good bye!");
                    System.Environment.Exit(0);
                break;

                default:
                    Console.WriteLine("Invalid command!");
                break;
            }

            this.IsFinished();
        }

        private void IsFinished()
        {
            if (this.matrix.MyPostionHorizontal == MinimalHorizontalPosition ||
                this.matrix.MyPostionHorizontal == MaximalHorizontalPosition ||
                this.matrix.MyPostionVertical == MinimalVerticalPosition ||
                this.matrix.MyPostionVertical == MaximalVerticalPosition)
            {
                Console.WriteLine("Congratulations! You escaped in " + this.moveCount.ToString() + " moves.");
                this.scoreboard.HandleScoreboard(this.moveCount);
                this.Restart();
            }
        }

        private void Restart()
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to “Labirinth” game. Please try to escape. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.");

            this.matrix = new LabyrinthMatrix();
            this.moveCount = 0;
        }

        private bool MoveDown()
        {
            if (!(this.matrix.MyPostionVertical == MaximalVerticalPosition) &&
                this.matrix.Matrix[this.matrix.MyPostionHorizontal][this.matrix.MyPostionVertical + 1] == '-')
            {
                this.matrix.MyPostionVertical++;
                this.moveCount++;
                return true;
            }

            return false;
        }

        private bool MoveUp()
        {
            if (!(this.matrix.MyPostionVertical == MinimalVerticalPosition) &&
                this.matrix.Matrix[this.matrix.MyPostionHorizontal][this.matrix.MyPostionVertical - 1] == '-')
            {
                this.matrix.MyPostionVertical--;
                this.moveCount++;
                return true;
            }

            return false;
        }

        private bool MoveRight()
        {
            if (!(this.matrix.MyPostionHorizontal == MaximalHorizontalPosition) &&
                 this.matrix.Matrix[this.matrix.MyPostionHorizontal + 1][this.matrix.MyPostionVertical] == '-')
            {
                this.matrix.MyPostionHorizontal++;
                this.moveCount++;
                return true;
            }

            return false;
        }

        private bool MoveLeft()
        {
            if (!(this.matrix.MyPostionHorizontal == MinimalHorizontalPosition) &&
                this.matrix.Matrix[this.matrix.MyPostionHorizontal - 1][this.matrix.MyPostionVertical] == '-')
            {
                this.matrix.MyPostionHorizontal--;
                this.moveCount++;
                return true;
            }

            return false;
        }
    }
}
