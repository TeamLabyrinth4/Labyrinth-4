namespace Labyrinth.Common
{
    /// <summary>
    /// Check if the given command is a valid one for moving the player in a certain direction.
    /// </summary>
    public static class MoveValidator
    {
        /// <summary>
        /// Validates the player movement command.
        /// </summary>
        /// <param name="command">Get as input a command form the client.</param>
        /// <returns>A boolean value if the input was correct or not.</returns>
        public static bool IsValidComandDir(string command)
        {
            var lowerCommand = command.ToLower();
            if (command == "d" || command == "u" || command == "l" || command == "r")
            {
                return true;
            }

            return false;
        }
    }
}
