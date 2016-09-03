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
        public Board()
        {
        }

        public Board(params Piece[] pieces)
        {
            Pieces.AddRange(pieces);
        }

        /// <summary>
        /// Gets the pieces on the board.
        /// </summary>
        public List<Piece> Pieces { get; } = new List<Piece>();
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
        public IEnumerable<Square> GetPossibleMoves(Piece piece) => piece.ForwardSquares().Where(IsFree);

        /// <summary>
        /// Gets the possible takings for a specified piece.
        /// </summary>
        /// <param name="piece">The piece to consider.</param>
        /// <returns>The position of the pieces the considered piece can take.</returns>
        public IEnumerable<Square> GetPossibleTakings(Piece piece) => piece.ForwardSquares().Where(square => SquareContainsPiece(square, ~piece.Color) && IsFree(piece.Over(square)));

        public void Take(Piece attacker, Piece target)
        {
            Guard.Requires<InvalidMoveException>(attacker.AdjacentDiagonalTo(target));
            Guard.Requires<PieceNotOnBoardException>(Pieces.Contains(attacker));
            Guard.Requires<PieceNotOnBoardException>(Pieces.Contains(target));
            Guard.Requires<FriendlyAttackException>(SquareContainsPiece(target, ~attacker.Color));
            Guard.Requires<OccupiedSquareException>(() => IsFree(attacker.Over(target)));

            Pieces.Remove(target);
            attacker.Square = attacker.Over(target);
        }

        private bool SquareContainsPiece(IPosition square, Color? color = null) => SquareContainsPiece(square.X, square.Y, color);

        private bool SquareContainsPiece(int x, int y, Color? color = null) => x.In(0, 9) && y.In(0, 9) && Pieces.Where(p => p.Square == new Square(x, y)).Any(p => (color == null) || (p.Color == color.Value));

        private bool IsFree(Square square) => IsFree(square.X, square.Y);

        private bool IsFree(int x, int y) => x.In(0, 9) && y.In(0, 9) && Pieces.All(p => p?.Square != new Square(x, y));
    }
}