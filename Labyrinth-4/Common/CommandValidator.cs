namespace Labyrinth
{
    using System;
    using System.Linq;

    /// <summary>
    /// The class helps to handle the input from the client and to validate it if it's in the correct format.
    /// </summary>
    /// <typeparam name="T">A Generic Type Parameter for the input.</typeparam>
    public class CommandValidator<T>
    {
        /// <summary>
        /// Gets an instance of a command validator.
        /// </summary>
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
