namespace Labyrinth.Enums
{
    /// <summary>
    /// Enumeration for all possible commands in the game.
    /// </summary>
    public enum CommandType
    {
        /// <summary>
        /// Terminates the game.
        /// </summary>
        Exit,

        /// <summary>
        /// Starts the game over.
        /// </summary>
        Restart,

        /// <summary>
        /// Shows the best players.
        /// </summary>
        Top,

        /// <summary>
        /// Saves the game. 
        /// </summary>
        Save,

        /// <summary>
        /// Load the saved game.
        /// </summary>
        Restore,

        /// <summary>
        /// Changes the player.
        /// </summary>
        Newplayer,

        /// <summary>
        /// Moves the player in direction down.
        /// </summary>
        D,

        /// <summary>
        /// Moves the player in direction up.
        /// </summary>
        U,

        /// <summary>
        /// Moves the player in direction right.
        /// </summary>
        R,

        /// <summary>
        /// Moves the player in direction left.
        /// </summary>
        L
    }
}
