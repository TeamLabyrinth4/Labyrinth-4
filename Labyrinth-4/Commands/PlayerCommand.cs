namespace Labyrinth.Commands
{
    using System;
    using Contexts;
    using Labyrinth.Users;
    using Common;

    public class PlayerCommand : ICommand
    {
        private IPlayer player;
        private string command;
        private char[][] matrix;

        public IContext Context { get; set; }

        public PlayerCommand(IPlayer player, char[][] matrix, string command)
        {
            this.player = player;
            this.command = command;
            this.matrix = matrix;
        }

        public void Execute()
        {
            switch (this.command)
            {
                case "d":
                    this.MoveDown();
                    break;

                case "u":
                    this.MoveUp();
                    break;

                case "l":
                    this.MoveLeft();
                    break;

                case "r":
                    this.MoveRight();
                    break;
            }
        }

        private bool MoveDown()
        {
            if (!(this.player.PositionRow == Constants.MinimalVerticalPosition) &&
                this.matrix[this.player.PositionCol][this.player.PositionRow + 1] == '-')
            {
                this.player.MoveDown();
                return true;
            }

            return false;
        }

        private bool MoveUp()
        {
            if (!(this.player.PositionRow == Constants.MinimalVerticalPosition) &&
                this.matrix[this.player.PositionCol][this.player.PositionRow - 1] == '-')
            {
                this.player.MoveUp();
                return true;
            }

            return false;
        }

        private bool MoveRight()
        {
            if (!(this.player.PositionCol == Constants.MaximalHorizontalPosition) &&
                 this.matrix[this.player.PositionCol + 1][this.player.PositionRow] == '-')
            {
                this.player.MoveRight();
                return true;
            }

            return false;
        }

        private bool MoveLeft()
        {
            if (!(this.player.PositionCol == Constants.MinimalHorizontalPosition) &&
                 this.matrix[this.player.PositionCol - 1][this.player.PositionRow] == '-')
            {
                this.player.MoveLeft();
                return true;
            }

            return false;
        }
    }
}
