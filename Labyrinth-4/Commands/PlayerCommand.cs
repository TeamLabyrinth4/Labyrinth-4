namespace Labyrinth.Commands
{
    using Labyrinth.Users;

    public class PlayerCommand : Command
    {
        private IPlayerCloneable player;
        private string command;
        private char[][] matrix;

        public PlayerCommand(IPlayerCloneable player, char[][] matrix, string command)
        {
            this.player = player;
            this.command = command;
            this.matrix = matrix;
        }

        public override void Execute()
        {
            switch (this.command)
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

        public void UnExecute()
        {
            switch (this.command)
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
                this.player.PositionRow++;
                this.player.Score++;
                return true;
            }

            return false;
        }

        private bool MoveUp()
        {
            if (!(this.player.PositionRow == LabyrinthProcesor.MinimalVerticalPosition) &&
                this.matrix[this.player.PositionCol][this.player.PositionRow - 1] == '-')
            {
                this.player.PositionRow--;
                this.player.Score++;
                return true;
            }

            return false;
        }

        private bool MoveRight()
        {
            if (!(this.player.PositionCol == LabyrinthProcesor.MaximalHorizontalPosition) &&
                 this.matrix[this.player.PositionCol + 1][this.player.PositionRow] == '-')
            {
                this.player.PositionCol++;
                this.player.Score++;
                return true;
            }

            return false;
        }

        private bool MoveLeft()
        {
            if (!(this.player.PositionCol == LabyrinthProcesor.MinimalHorizontalPosition) &&
                 this.matrix[this.player.PositionCol - 1][this.player.PositionRow] == '-')
            {
                this.player.PositionCol--;
                this.player.Score++;
                return true;
            }

            return false;
        }
    }
}
