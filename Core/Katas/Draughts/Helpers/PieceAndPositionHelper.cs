using Core.Utils;
using Core.Utils.Defense;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Katas.Draughts.Helpers
{
    public static class PieceAndPositionHelper
    {
        public static bool AdjacentDiagonalTo(this IPosition p1, IPosition p2) => (Math.Abs(p1.X - p2.X) == 1) && (Math.Abs(p1.Y - p2.Y) == 1);

        public static bool AdjacentTo(this IPosition p1, IPosition p2) => Math.Abs(p1.X - p2.X).In(0, 1) && Math.Abs(p1.Y - p2.Y).In(0, 1);

        public static IEnumerable<Square> BackwardSquares(this Piece piece)
        {
            Guard.Requires(piece != null);

            int y = piece.Color == Color.White ? piece.Y - 1 : piece.Y + 1;

            yield return new Square(piece.X - 1, y);
            yield return new Square(piece.X + 1, y);
        }

        public static IEnumerable<Square> ForwardSquares(this Piece piece)
        {
            Guard.Requires(piece != null);

            int y = piece.Color == Color.Black ? piece.Y - 1 : piece.Y + 1;

            yield return new Square(piece.X - 1, y);
            yield return new Square(piece.X + 1, y);
        }

        public static IEnumerable<Piece> GetPiecesOfColor(this IEnumerable<Piece> pieces, Color color) => pieces.Where(p => p.Color == color);

        public static bool IsInBoard(this IPosition position)
        {
            Guard.Requires(position != null);

            return position.X.In(0, Board.DEFAULT_SIZE - 1) && position.Y.In(0, Board.DEFAULT_SIZE - 1);
        }

        public static Square Over(this IPosition origin, IPosition obstacle)
        {
            Guard.Requires(origin.AdjacentTo(obstacle));

            return new Square(2 * obstacle.X - origin.X, 2 * obstacle.Y - origin.Y);
        }
    }
}