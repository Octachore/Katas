using System;

namespace Core.Katas.Draughts.Exceptions
{
    public class OccupiedSquareException : Exception
    {
        public IPosition Position { get; set; }

        public OccupiedSquareException(string message, IPosition position) : base(message)
        {
            Position = position;
        }
    }
}