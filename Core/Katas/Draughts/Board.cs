using Core.Katas.Draughts.Exceptions;
using Core.Katas.Draughts.Helpers;
using Core.Utils;
using Core.Utils.Defense;
using System.Collections.Generic;
using System.Linq;

namespace Core.Katas.Draughts
{
    /// <summary>
    /// Represents a draughts board.
    /// </summary>
    public class Board
    {
        public const int DEFAULT_SIZE = 10;
        private readonly List<Piece> _pieces = new List<Piece>();

        /// <summary>
        /// Gets the pieces on the board.
        /// </summary>
        public IReadOnlyList<Piece> Pieces => _pieces.AsReadOnly();

        /// <summary>
        /// Initializes a new instance of the <see cref="Board"/> class.
        /// </summary>
        /// <param name="pieces">The pieces on the board.</param>
        public Board(params Piece[] pieces)
        {
            _pieces.AddRange(pieces);
        }

        /// <summary>
        /// Adds a piece to the board.
        /// </summary>
        /// <param name="piece">The piece to add.</param>
        public void Add(Piece piece) => _pieces.Add(piece);

        /// <summary>
        /// Add pieces to the board.
        /// </summary>
        /// <param name="pieces">The pieces to add.</param>
        public void Add(IEnumerable<Piece> pieces) => _pieces.AddRange(pieces);

        /// <summary>
        /// Creates a shallow copy of the current <see cref="Board"/>.
        /// </summary>
        /// <returns>The clone.</returns>
        public Board Clone() => MemberwiseClone() as Board;

        /// <summary>
        /// Gets the possible moves for a specified piece.
        /// </summary>
        /// <param name="piece">The piece to consider.</param>
        /// <returns>The possible moves</returns>
        public IEnumerable<Move> GetPossibleMoves(Piece piece) => GetPossibleSimpleMoves(piece).Union(GetPossibleTakingsMoves(piece));

        /// <summary>
        /// Gets the possibles simple moves (without taking an enemy piece) for a specified piece.
        /// </summary>
        /// <param name="piece">The piece to consider.</param>
        /// <returns>The possible simple moves.</returns>
        public IEnumerable<Move> GetPossibleSimpleMoves(Piece piece) => piece.ForwardSquares().Where(IsFree).Select(s => new SimpleMove(piece, s));
        ////public IEnumerable<Square> GetPossibleDestinations(Piece piece) => GetPossibleSimpleMoves(piece).Union(GetPossibleTakingsMoves(piece).Select(piece.Over));

        /// <summary>
        /// Gets the possible takings moves for a specified piece.
        /// </summary>
        /// <param name="piece">The piece to consider.</param>
        /// <returns>The possible taking moves.</returns>
        public IEnumerable<Move> GetPossibleTakingsMoves(Piece piece)
            => piece.ForwardSquares().Union(piece.BackwardSquares()).Where(square => PositionContainsPiece(square, ~piece.Color) && IsFree(piece.Over(square)))
                    .Select(s =>
                            {
                                Piece p = Pieces.FirstOrDefault(pi => pi.Square == s);
                                return new TakingMove(piece, p);
                            });

        /// <summary>
        /// Make the <see cref="attacker"/> take the <see cref="target"/>. The <see cref="attacker"/> 'jumps' over the <see cref="target"/>. The <see cref="target"/> is removed from the board.
        /// </summary>
        /// <param name="attacker">The attacker.</param>
        /// <param name="target">The target.</param>
        public void Take(Piece attacker, Piece target)
        {
            Guard.Requires(attacker.AdjacentDiagonalTo(target), new InvalidMoveException("The attacker must be adjacent diagonal to target.", attacker, target));
            Guard.Requires(Pieces.Contains(attacker), new PieceNotOnBoardException("The attacker must be on the board.", attacker));
            Guard.Requires(Pieces.Contains(target), new PieceNotOnBoardException("The target must be on the board.", target));
            Guard.Requires(PositionContainsPiece(target, ~attacker.Color), new FriendlyAttackException("The target must be of the opposite color.", attacker, target));
            Guard.Requires(() => IsFree(attacker.Over(target)), new OccupiedSquareException("The destination must be empty.", target));

            _pieces.RemoveAll(p => (p.X == target.X) && (p.Y == target.Y));
            attacker.Square = attacker.Over(target);
        }

        /// <summary>
        /// Checks if a position of the board is free.
        /// </summary>
        /// <param name="pos">The position.</param>
        /// <returns><c>true</c> if the position is free, <c>false</c> otherwise.</returns>
        private bool IsFree(IPosition pos) => IsFree(pos.X, pos.Y);

        /// <summary>
        /// Checks if a position of the board is free.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <returns><c>true</c> if the position is free, <c>false</c> otherwise.</returns>
        private bool IsFree(int x, int y) => x.In(0, DEFAULT_SIZE - 1) && y.In(0, DEFAULT_SIZE - 1) && Pieces.All(p => p?.Square != new Square(x, y));

        /// <summary>
        /// Check if a position on the board contains a piece of a specific color.
        /// </summary>
        /// <param name="pos">The position.</param>
        /// <param name="color">The color.</param>
        /// <returns><c>true</c> if the confition is fullfiled, <c>false</c> otherwise.</returns>
        private bool PositionContainsPiece(IPosition pos, Color? color = null) => PositionContainsPiece(pos.X, pos.Y, color);

        /// <summary>
        /// Check if a position on the board contains a piece of a specific color.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="color">The color.</param>
        /// <returns><c>true</c> if the confition is fullfiled, <c>false</c> otherwise.</returns>
        private bool PositionContainsPiece(int x, int y, Color? color = null) => x.In(0, DEFAULT_SIZE - 1) && y.In(0, DEFAULT_SIZE - 1) && Pieces.Where(p => p.Square == new Square(x, y)).Any(p => (color == null) || (p.Color == color.Value));
    }
}