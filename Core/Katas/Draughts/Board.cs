using Core.Katas.Draughts.Exceptions;
using Core.Utils;
using Core.Utils.Defense;
using System.Collections.Generic;
using System.Linq;
using Core.Katas.Draughts.Helpers;

namespace Core.Katas.Draughts
{
    /// <summary>
    /// Represents a draughts board. It is, basically, a 10 x 10 grid with 0 or 1 pawn on each square.
    /// </summary>
    public class Board
    {
        public const int DEFAULT_SIZE = 10;

        public Bot Bot { get; }

        /// <summary>
        /// Gets the pieces on the board.
        /// </summary>
        public List<Piece> Pieces { get; } = new List<Piece>();

        public Board()
        {
            Bot = new Bot(this);
        }

        public Board(params Piece[] pieces) : this()
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

        public Board Clone() => MemberwiseClone() as Board;

        /// <summary>
        /// Gets the possibles moves (without taking an enemy piece) for a specified piece.
        /// </summary>
        /// <param name="piece">The piece to consider.</param>
        /// <returns>The possible destinations.</returns>
        public IEnumerable<Mouve> GetPossibleSimpleMoves(Piece piece) => piece.ForwardSquares().Where(IsFree).Select(s => new Mouve(piece.Square, s, MouveType.Simple));

        public IEnumerable<Mouve> GetPossibleMoves(Piece piece) => GetPossibleSimpleMoves(piece).Union(GetPossibleTakingsMouves(piece));

        ////public IEnumerable<Square> GetPossibleDestinations(Piece piece) => GetPossibleSimpleMoves(piece).Union(GetPossibleTakingsMouves(piece).Select(piece.Over));

        /// <summary>
        /// Gets the possible takings for a specified piece.
        /// </summary>
        /// <param name="piece">The piece to consider.</param>
        /// <returns>The position of the pieces the considered piece can take.</returns>
        public IEnumerable<Mouve> GetPossibleTakingsMouves(Piece piece)
            => piece.ForwardSquares().Union(piece.BackwardSquares()).Where(square => SquareContainsPiece(square, ~piece.Color) && IsFree(piece.Over(square)))
                .Select(s => new Mouve(piece.Square, s, MouveType.Taking));

        public void Take(Piece attacker, IPosition target)
        {
            Guard.Requires(attacker.AdjacentDiagonalTo(target), new InvalidMoveException("The attacker must be adjacent diagonal to target."));
            Guard.Requires(Pieces.Contains(attacker), new PieceNotOnBoardException("The attacker must be on the board."));
            Guard.Requires(Pieces.Contains(target), new PieceNotOnBoardException("The target must be on the board."));
            Guard.Requires(SquareContainsPiece(target, ~attacker.Color), new FriendlyAttackException("The target must be of the opposite color."));
            Guard.Requires(() => IsFree(attacker.Over(target)), new OccupiedSquareException("The destination must be empty."));

            Pieces.RemoveAll(p => (p.X == target.X) && (p.Y == target.Y));
            attacker.Square = attacker.Over(target);
        }

        private bool IsFree(Square square) => IsFree(square.X, square.Y);

        private bool IsFree(int x, int y) => x.In(0, DEFAULT_SIZE - 1) && y.In(0, DEFAULT_SIZE - 1) && Pieces.All(p => p?.Square != new Square(x, y));

        private bool SquareContainsPiece(IPosition square, Color? color = null) => SquareContainsPiece(square.X, square.Y, color);

        private bool SquareContainsPiece(int x, int y, Color? color = null) => x.In(0, DEFAULT_SIZE - 1) && y.In(0, DEFAULT_SIZE - 1) && Pieces.Where(p => p.Square == new Square(x, y)).Any(p => (color == null) || (p.Color == color.Value));
    }
}