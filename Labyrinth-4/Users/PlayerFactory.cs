namespace Labyrinth.Users
{
    /// <summary>
    /// A flyweight factory class for all possible player command movements.
    /// </summary>
    public class PlayerFactory
    {
        private static PlayerMovement playerMovement;

        public static PlayerMovement GetPlayer()
        {
            if (playerMovement == null)
            {
                playerMovement = new PlayerMovement();
            }

            return playerMovement;
        }
    }
}
