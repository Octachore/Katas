using System;

namespace Core.Katas.Draughts.Exceptions
{
    public class PieceNotOnBoardException : Exception
    {
        public Piece Piece { get; set; }

        public PieceNotOnBoardException(string message, Piece piece) : base(message)
        {
            Piece = piece;
        }
    }
}
