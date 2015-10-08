﻿namespace Labyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CommandValidator<T>
    {
        public CommandValidator()
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("should pass enumaration");
            }
        }

        internal bool IsValidCommand(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                // transform the string into string with first uppercase letter.
                input = input.First().ToString().ToUpper() + string.Join(string.Empty, input.Skip(1));
            }

            if (!Enum.IsDefined(typeof(T), input))
            {
                return false;
            }

            return true;
        }

        internal T GetType(string input)
        {
            T type = (T)Enum.Parse(typeof(T), input, true);
            return type;
        }
    }
}
