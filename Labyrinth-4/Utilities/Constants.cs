﻿namespace Labyrinth.Utilities
{
    /// <summary>
    /// The class holds shared in-game constants which may be used by other classes.
    /// </summary>
    public class Constants
    {
        public const int MaximalHorizontalPosition = 16;
        public const int MinimalHorizontalPosition = 0;
        public const int MaximalVerticalPosition = 16;
        public const int MinimalVerticalPosition = 0;

        public const int StartPositionVertical = 8;
        public const int StartPositionHorizontal = 8;

        public const int MatrixRows = 17;
        public const int MatrixCols = 17;
        public const char BlockedField = 'X';
        public const char EmptyField = '-';
    }
}
