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
        private int moveCount;
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
            
            bool hasDownSideDashNeighbour = this.matrix.Matrix[this.matrix.MyPostionHorizontal][this.matrix.MyPostionVertical + 1] == '-';
            bool hasUpSideDashNeighbour = this.matrix.Matrix[this.matrix.MyPostionHorizontal][this.matrix.MyPostionVertical - 1] == '-';
            bool hasRightSideDashNeighbour = this.matrix.Matrix[this.matrix.MyPostionHorizontal + 1][this.matrix.MyPostionVertical] == '-';
            bool hasLefttSideDashNeighbour = this.matrix.Matrix[this.matrix.MyPostionHorizontal - 1][this.matrix.MyPostionVertical] == '-';
            
            if (lowerInput == "d" && 
                this.matrix.MyPostionVertical != MaximalVerticalPosition &&
                hasDownSideDashNeighbour)
            {
                this.matrix.MyPostionVertical++;
                this.moveCount++;
            } 
            else if (lowerInput == "u" &&
                    this.matrix.MyPostionVertical != MinimalVerticalPosition &&
                    hasUpSideDashNeighbour)
            {                
                this.matrix.MyPostionVertical--;
                this.moveCount++;
            }
            else if (lowerInput == "r" &&
                    this.matrix.MyPostionHorizontal != MaximalHorizontalPosition &&
                    hasRightSideDashNeighbour)
            {
                this.matrix.MyPostionHorizontal++;
                this.moveCount++;
            }
            else if (lowerInput == "l" &&
                  this.matrix.MyPostionHorizontal != MaximalHorizontalPosition &&
                  hasLefttSideDashNeighbour)
            {
                this.matrix.MyPostionHorizontal--;
                this.moveCount++;
            }
            else if (lowerInput == "top")
            {
                    this.scoreboard.ShowScoreboard();
            }
            else if (lowerInput == "restart")
            {
                    this.Restart();
            }
            else if (lowerInput == "exit")
            {
                    Console.WriteLine("Good bye!");
                    System.Environment.Exit(0);
            }
            else 
            {
                Console.WriteLine("Invalid move!");
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

        // private bool MovePlayer(int playerHorizontalPosition, int playerVerticalPosition,int directionBoundary)
        // {
        //    if (!(playerHorizontalPosition == directionBoundary) &&
        //        this.matrix.Matrix[playerHorizontalPosition][playerVerticalPosition + 1] == '-')
        //    {
        //        this.matrix.MyPostionVertical++;
        //        this.moveCount++;
        //        return true;
        //    }
        //
        //    return false;
        //
        // }
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
