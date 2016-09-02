using Core.Katas.Draughts.Exceptions;
using Core.Utils;
using Core.Utils.Defense;
using System.Collections.Generic;
using System.Linq;

namespace Core.Katas.Draughts
{
    /// <summary>
    /// Represents a draughts board. It is, basically, a 10 x 10 grid with 0 or 1 pawn on each square.
    /// </summary>
    public class Board
    {
        /// <summary>
        /// Gets the pieces on the board.
        /// </summary>
        public List<Piece> Pieces { get; } = new List<Piece>();

        public Board()
        {

        }

        public Board(params Piece[] pieces)
        {
            Pieces.AddRange(pieces);
        }

        /// <summary>
        /// Adds a piece to the board.
        /// </summary>
        /// <param name="piece">The piece to add.</param>
        public void Add(Piece piece) => Pieces.Add(piece);

        /// <summary>
        /// Add pieces to the board.
        /// </summary>
        /// <param name="pieces">The pieces to add.</param>
        public void Add(IEnumerable<Piece> pieces) => Pieces.AddRange(pieces);

        /// <summary>
        /// Gets the possibles moves (without taking an enemy piece) for a specified piece.
        /// </summary>
        /// <param name="piece">The piece to consider.</param>
        /// <returns>The possible destinations.</returns>
        public IEnumerable<Square> GetPossibleMoves(Piece piece)
        {
            int y = piece.Color == Color.Black ? piece.Y - 1 : piece.Y + 1;
            int x1 = piece.X - 1;
            int x2 = piece.X + 1;

            if (IsFree(x1, y)) yield return new Square(x1, y);
            if (IsFree(x2, y)) yield return new Square(x2, y);
        }

        /// <summary>
        /// Gets the possible takings for a specified piece.
        /// </summary>
        /// <param name="piece">The piece to consider.</param>
        /// <returns>The position of the pieces the considered piece can take.</returns>
        public IEnumerable<Square> GetPossibleTakings(Piece piece)
        {
            Color enemyColor = ~piece.Color;

            int enemyY = piece.Color == Color.Black ? piece.Y - 1 : piece.Y + 1;
            int enemyX1 = piece.X - 1;
            int enemyX2 = piece.X + 1;

            int destinationY = piece.Color == Color.Black ? enemyY - 1 : enemyY + 1;
            int destinationX1 = enemyX1 - 1;
            int destinationX2 = enemyX2 + 1;

            if (ContainsPiece(enemyX1, enemyY, enemyColor) && IsFree(destinationX1, destinationY))
            {
                ////TakePiece(destinationX1, destinationY);
                yield return new Square(enemyX1, enemyY);
            }

            if (ContainsPiece(enemyX2, enemyY, enemyColor) && IsFree(destinationX2, destinationY))
            {
                ////TakePiece(destinationX2, destinationY);
                yield return new Square(enemyX2, enemyY);
            }
        }

        public void Take(Piece attacker, Piece target) => Take(attacker, target.X, target.Y);

        public void Take(Piece attacker, int x, int y)
        {
            Guard.Requires<NoEnemyException>(() => ContainsPiece(x, y));
            Guard.Requires<FriendlyAttackException>(() => ContainsPiece(x, y, ~attacker.Color));

            Piece target = Pieces.SingleOrDefault(p => p.Square == new Square(x, y));
            int destinationX = attacker.X + (target.X - attacker.X) * 2;
            int destinationY = attacker.Y + (target.Y - attacker.Y) * 2;

            Guard.Requires<OccupiedSquareException>(() => IsFree(destinationX, destinationY));

            Pieces.Remove(target);
            attacker.Square = new Square(destinationX, destinationY);
        }

        private bool ContainsPiece(int x, int y, Color? color = null) => x.In(0, 9) && y.In(0, 9) && Pieces.Where(p => p.Square == new Square(x, y)).Any(p => (color == null) || (p.Color == color.Value));

        private bool IsFree(int x, int y) => x.In(0, 9) && y.In(0, 9) && Pieces.All(p => p?.Square != new Square(x, y));
    }
}