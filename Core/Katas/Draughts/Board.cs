using Core.Utils;
using System.Collections.Generic;
using System.Linq;

namespace Core.Katas.Draughts
{
    public class Board
    {
        public List<Piece> Pieces { get; set; } = new List<Piece>();

        public void Add(Piece pawn) => Pieces.Add(pawn);

        public void Add(IEnumerable<Piece> pawns) => Pieces.AddRange(pawns);

        public IEnumerable<Square> GetPossibleMoves(Piece piece)
        {
            int y = piece.Color == Color.Black ? piece.Y - 1 : piece.Y + 1;
            int x1 = piece.X - 1;
            int x2 = piece.X + 1;

            if (IsFree(x1, y)) yield return new Square(x1, y);
            if (IsFree(x2, y)) yield return new Square(x2, y);
        }

        public IEnumerable<Square> GetPossibleTakings(Piece piece)
        {
            Color enemyColor = piece.Color == Color.Black ? Color.White : Color.Black;

            int enemyY = piece.Color == Color.Black ? piece.Y - 1 : piece.Y + 1;
            int enemyX1 = piece.X - 1;
            int enemyX2 = piece.X + 1;

            int destinationY = piece.Color == Color.Black ? enemyY - 1 : enemyY + 1;
            int destinationX1 = enemyX1 - 1;
            int destinationX2 = enemyX2 + 1;

            if (ContainsPawn(enemyX1, enemyY, enemyColor) && IsFree(destinationX1, destinationY))
            {
                ////TakePiece(destinationX1, destinationY);
                yield return new Square(destinationX1, destinationY);
            }

            if (ContainsPawn(enemyX2, enemyY, enemyColor) && IsFree(destinationX2, destinationY))
            {
                ////TakePiece(destinationX2, destinationY);
                yield return new Square(destinationX2, destinationY);
            }
        }

        private void TakePiece(int x, int y)
        {
            Piece piece = Pieces.SingleOrDefault(p => p.Square == new Square(x, y));
            if (piece != null) Pieces.Remove(piece);
        }

        private bool ContainsPawn(int x, int y, Color? color = null) => x.In(0, 9) && y.In(0, 9) && Pieces.Where(p => p.Square == new Square(x, y)).Any(p => (color == null) || (p.Color == color.Value));

        private bool IsFree(int x, int y) => x.In(0, 9) && y.In(0, 9) && Pieces.All(p => p?.Square != new Square(x, y));
    }
}
