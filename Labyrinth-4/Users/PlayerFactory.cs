namespace Labyrinth.Users
{
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
