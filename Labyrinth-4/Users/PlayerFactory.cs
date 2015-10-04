using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth.Users
{
    public class PlayerFactory
    {

        private static PlayerMovement playerMovement;

        public static PlayerMovement getPlayer()
        {
            if (playerMovement == null)
            {
                playerMovement = new PlayerMovement();
            }

            return playerMovement;
        }
    }
}
