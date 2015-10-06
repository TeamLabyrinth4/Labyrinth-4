namespace Labyrinth.Commands
{
    using Labyrinth.Users;

    public class PlayerCommand : Command
    {
        private IPlayer player;
        private char[][] matrix;

        public PlayerCommand(IPlayer player, char[][] matrix)
        {
            this.player = player;
            this.matrix = matrix;
        }

        public override void Execute(string command)
        {
            switch (command)
            {
                case "d": this.MoveDown();
                    break;

                case "u": this.MoveUp();
                    break;

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
                    break;

                case "l": this.MoveRight();
                    break;

                case "r": this.MoveLeft();
                    break;
            }
        }

        private bool MoveDown()
        {
            if (!(this.player.PositionRow == LabyrinthProcesor.MinimalVerticalPosition) &&
                this.matrix[this.player.PositionCol][this.player.PositionRow + 1] == '-')
            {
                this.player.MoveDown();
                return true;
            }

            return false;
        }

        private bool MoveUp()
        {
            if (!(this.player.PositionRow == LabyrinthProcesor.MinimalVerticalPosition) &&
                this.matrix[this.player.PositionCol][this.player.PositionRow - 1] == '-')
            {
                this.player.MoveUp();
                return true;
            }

            return false;
        }

        private bool MoveRight()
        {
            if (!(this.player.PositionCol == LabyrinthProcesor.MaximalHorizontalPosition) &&
                 this.matrix[this.player.PositionCol + 1][this.player.PositionRow] == '-')
            {
                this.player.MoveRight();
                return true;
            }

            return false;
        }

        private bool MoveLeft()
        {
            if (!(this.player.PositionCol == LabyrinthProcesor.MinimalHorizontalPosition) &&
                 this.matrix[this.player.PositionCol - 1][this.player.PositionRow] == '-')
            {
                this.player.MoveLeft();
                return true;
            }

            return false;
        }
    }
}
