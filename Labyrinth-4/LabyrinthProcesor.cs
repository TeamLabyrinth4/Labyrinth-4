namespace Labyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Labyrinth.Renderer;
    using Labyrinth.Users;

    public class LabyrinthProcesor
    {
        public const int MaximalHorizontalPosition = 6;
        public const int MinimalHorizontalPosition = 0;
        public const int MaximalVerticalPosition = 6;
        public const int MinimalVerticalPosition = 0;

        private LabyrinthMatrix matrix;
        private IScoreBoardHandler scoreboard;
        private IRenderer renderer;
        private IPlayerCloneable player;
        private Messenger messenger;

        public LabyrinthProcesor(IRenderer renderer, IPlayerCloneable player)
        {
            this.scoreboard = new ScoreBoardHandler();
            this.messenger = new Messenger();
            this.renderer = renderer;
            this.player = player;
            this.Restart();
        }

        public LabyrinthMatrix Matrix
        {
            get { return this.matrix; }
            set { this.matrix = value; }
        }

        public void ShowInputMessage()
        {
            renderer.ShowMessage(Messenger.InputMessage);
        }

        public void HandleInput(string input)
        {
            string lowerInput = input.ToLower();
            
            bool hasDownSideDashNeighbour = this.matrix.Matrix[this.player.PositionCol][this.player.PositionRow + 1] == '-';
            bool hasUpSideDashNeighbour = this.matrix.Matrix[this.player.PositionCol][this.player.PositionRow - 1] == '-';
            bool hasRightSideDashNeighbour = this.matrix.Matrix[this.player.PositionCol + 1][this.player.PositionRow] == '-';
            bool hasLefttSideDashNeighbour = this.matrix.Matrix[this.player.PositionCol - 1][this.player.PositionRow] == '-';
            
            if (lowerInput == "d" && 
                this.player.PositionRow != MaximalVerticalPosition &&
                hasDownSideDashNeighbour)
            {
                this.player.PositionRow++;
                this.player.Score++;
            } 
            else if (lowerInput == "u" &&
                    this.player.PositionRow != MinimalVerticalPosition &&
                    hasUpSideDashNeighbour)
            {
                this.player.PositionRow--;
                this.player.Score++;
            }
            else if (lowerInput == "r" &&
                    this.player.PositionCol != MaximalHorizontalPosition &&
                    hasRightSideDashNeighbour)
            {
                this.player.PositionCol++;
                this.player.Score++;
            }
            else if (lowerInput == "l" &&
                  this.player.PositionCol != MaximalHorizontalPosition &&
                  hasLefttSideDashNeighbour)
            {
                this.player.PositionCol--;
                this.player.Score++;
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
                renderer.ShowMessage(Messenger.GoodBye);
                System.Environment.Exit(0);
            }
            else 
            {
                renderer.ShowMessage(Messenger.InvalidMoveMessage);
            }

            this.IsFinished();
        }

        private void IsFinished()
        {
            if (this.player.PositionCol == MinimalHorizontalPosition ||
                this.player.PositionCol == MaximalHorizontalPosition ||
                this.player.PositionRow == MinimalVerticalPosition ||
                this.player.PositionRow == MaximalVerticalPosition)
            {
                renderer.ShowMessage(this.messenger.WriteFinalMessage(this.player.Score));
                var clone = (IPlayerCloneable)this.player.Clone();
                this.scoreboard.HandleScoreboard(clone);
                this.Restart();
            }
        }

        private void Restart()
        {
            this.renderer.ShowMessage(Messenger.WelcomeMessage);  
            this.matrix = new LabyrinthMatrix();
            this.player.Score = 0;
            this.player.PositionCol = 3;
            this.player.PositionRow = 3;
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
            if (!(this.player.PositionRow == MaximalVerticalPosition) &&
                this.matrix.Matrix[this.player.PositionCol][this.player.PositionRow + 1] == '-')
            {
                this.player.PositionRow++;
                this.player.Score++;
                return true;
            }

            return false;
        }

        private bool MoveUp()
        {
            if (!(this.player.PositionRow == MinimalVerticalPosition) &&
                this.matrix.Matrix[this.player.PositionCol][this.player.PositionRow - 1] == '-')
            {
                this.player.PositionRow--;
                this.player.Score++;
                return true;
            }

            return false;
        }

        private bool MoveRight()
        {
            if (!(this.player.PositionCol == MaximalHorizontalPosition) &&
                 this.matrix.Matrix[this.player.PositionCol + 1][this.player.PositionRow] == '-')
            {
                this.player.PositionCol++;
                this.player.Score++;
                return true;
            }

            return false;
        }

        private bool MoveLeft()
        {
            if (!(this.player.PositionCol == MinimalHorizontalPosition) &&
                this.matrix.Matrix[this.player.PositionCol - 1][this.player.PositionRow] == '-')
            {
                this.player.PositionCol--;
                this.player.Score++;
                return true;
            }

            return false;
        }
    }
}
