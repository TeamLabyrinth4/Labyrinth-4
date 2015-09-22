using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
{
    public class Messenger
    {
        public const string GoodBye = "Good bye!";
        public const string InvalidMoveMessage = "Good bye!";
        public const string WelcomeMessage = "Welcome to “Labirinth” game. Please try to escape. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.";
        public const string InputMessage = "Enter your move (L=left, R-right, U=up, D=down): ";
        public string WriteFinalMessage(int moves) 
        {
            return "Congratulations! You escaped in " + moves.ToString() + " moves.";
        }
    }
}
