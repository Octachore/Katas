using System;

namespace Core.Katas.Draughts.Exceptions
{
    public class InvalidMoveException : Exception
    {
        public InvalidMoveException(string message) : base(message)
        {
            
        }
    }
}
