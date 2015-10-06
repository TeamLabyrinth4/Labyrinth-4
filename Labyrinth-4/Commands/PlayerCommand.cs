namespace Labyrinth.Commands
{
    using System;
    using Contexts;
    using Labyrinth.Users;
    using Common;

    public class PlayerCommand : ICommand
    {
        private IPlayer player;
        private char[][] matrix;

<<<<<<< HEAD
        public IContext Context { get; set; }

        public PlayerCommand(IPlayer player, char[][] matrix, string command)
=======
        public PlayerCommand(IPlayer player, char[][] matrix)
>>>>>>> origin/master
        {
            this.player = player;
            this.matrix = matrix;
        }

<<<<<<< HEAD
        public void Execute()
=======
        public override void Execute(string command)
>>>>>>> origin/master
        {
            switch (command)
            {
                case "d":
                    this.MoveDown();
                    break;

<<<<<<< HEAD
                case "u":
                    this.MoveUp();
=======
                case "l": this.MoveLeft();
                    break;

                case "r": this.MoveRight();
                    break;
            }
        }

        public void UnExecute(string command)
        {
            switch (command)
            {
                case "d": this.MoveUp();
                    break;
                      
                case "u": this.MoveDown();
>>>>>>> origin/master
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
