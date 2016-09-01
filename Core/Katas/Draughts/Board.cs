using Core.Utils;
using System.Collections.Generic;
using System.Linq;

namespace Core.Katas.Draughts
{
    public class Board
    {
        public List<Piece> Pieces { get; set; } = new List<Piece>();

        public IEnumerable<Square> GetPossibleMoves(Piece piece)
        {
            int y = piece.Color == Color.Black ? piece.Y - 1 : piece.Y + 1;
            int x1 = piece.X - 1;
            int x2 = piece.X + 1;

            if (CanMove(piece, x1, y)) yield return new Square(x1, y);
            if (CanMove(piece, x2, y)) yield return new Square(x2, y);
        }

        private bool CanMove(Piece piece, int x, int y) => x.In(0, 9) && Pieces.All(p => p?.Square != new Square(x, y));

        public void Add(Piece pawn) => Pieces.Add(pawn);

        public void Add(IEnumerable<Piece> pawns) => Pieces.AddRange(pawns);
    }
}
