using System;

namespace Core.Katas.Draughts.Exceptions
{
    public class InvalidMoveException : Exception
    {
        public Piece Piece { get; set; }

        public IPosition Destination { get; set; }

        public InvalidMoveException(string message, Piece piece, IPosition destination) : base(message)
        {
            Piece = piece;
            Destination = destination;
        }
    }
}