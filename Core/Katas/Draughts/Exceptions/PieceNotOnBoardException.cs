using System;

namespace Core.Katas.Draughts.Exceptions
{
    public class PieceNotOnBoardException : Exception
    {
        public PieceNotOnBoardException(string message) : base(message)
        {
            
        }
    }
}
