using System;

namespace Core.Katas.Draughts.Exceptions
{
    public class OccupiedSquareException : Exception
    {
        public OccupiedSquareException(string message) : base(message)
        {
            
        }
    }
}
