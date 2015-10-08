﻿namespace Labyrinth.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class MoveValidator
    {
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