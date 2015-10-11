namespace Labyrinth.Utilities
{
    /// <summary>
    /// The class holds all possible in-game messages, which may be displayed to the player.
    /// </summary>
    public class Messages
    {
        public const string GoodBye = "--- Good bye :) ---";
        public const string InvalidMoveMessage = "Ups, wrong command!";
        public const string WelcomeMessage = " Welcome to “Labirinth” game.Just try to escape from out Labirinth ! You can use next commands:\n -'top' to view the top scoreboard\n -'restart' to start a new game\n -'save' to save current position\n -'restore' to restore saved position\n -'newplayer' to set a new player\n -'exit' to quit the game.";
        public const string InputMessage = "\nEnter your move (L=left, R=right, U=up, D=down): ";
        public const string ChangePlayer = "Please Enter a new name for the Player";
        public const string Save = "Position Saved!";
        public const string Load = "Position Restored!";
        public const string Positions = "At position: X:{0},Y:{1}";
        public const string StartNewGame = "\nNew game started !\n\n" + WelcomeMessage;
        public const string EmptyScoreBoard = "The scoreboard is empty.";
        public const string ScoreBoardHeader = "---TOP 5 SCOREBOARD---\n";
    }
}
