namespace Labyrinth
{
    public class Messenger
    {
        public const string GoodBye = "Good bye!";
        public const string InvalidMoveMessage = "Ups, wrong command!";
        public const string WelcomeMessage = " Welcome to “Labirinth” game.Just try to escape from out Labirinth ! You can use next commands:\n -'top' to view the top scoreboard\n -'restart' to start a new game\n -'save' to save current position\n -'load' to restore saved position\n -'newplayer' to set a new player\n -'exit' to quit the game.";
        public const string InputMessage = "\nEnter your move (L=left, R-right, U=up, D=down): ";
        public const string ChangePlayer = "Please Enter a new Name for the Player";
        public const string Save = "Position Saved!";
        public const string Load = "Position Restored!";
        public const string Positions = "At position: X:{0},Y:{1}";

        public string WriteFinalMessage(int moves)
        {
            return "Congratulations! You escaped in " + moves.ToString() + " moves.";
        }
    }
}
