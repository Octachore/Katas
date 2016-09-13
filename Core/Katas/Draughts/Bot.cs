using Core.Katas.Draughts.Helpers;
using Core.Utils;
using System.Collections.Generic;
using System.Linq;

namespace Core.Katas.Draughts
{
    /// <summary>
    /// Provides logic to automaticly play a turn.
    /// </summary>
    public class Bot
    {
        private readonly Board _board;

        /// <summary>
        /// Initializes a new instance of the <see cref="Bot"/> class.
        /// </summary>
        /// <param name="board"></param>
        public Bot(Board board)
        {
            _board = board;
        }

        /// <summary>
        /// Playes a taking move.
        /// </summary>
        /// <param name="attacker">The attacker.</param>
        /// <param name="target">The target.</param>
        /// <returns></returns>
        public IEnumerable<Move> PlayTakingMove(Piece attacker, Piece target)
        {
            var moves = new List<Move>();
            Piece origin = attacker.Clone();

            _board.Take(attacker, target);

            moves.Add(new TakingMove(origin, target));

            if (_board.GetPossibleTakingsMoves(attacker).Any()) moves.AddRange(PlayTakingMove(attacker, target));

            return moves;
        }

        /// <summary>
        /// Plays a turn.
        /// </summary>
        /// <param name="color">The (bot) player color.</param>
        /// <returns>The played move.</returns>
        public IEnumerable<Move> PlayTurn(Color color)
        {
            List<Piece> pieces = _board.Pieces.GetPiecesOfColor(color).ToList();
            ////IEnumerable<Piece> enemies = _board.Pieces.GetPiecesOfColor(~color);
            List<Piece> attackers = GetAttackers(pieces).ToList();
            List<Piece> movers = GetMovablePieces(pieces).ToList();

            return attackers.Any() ? PlayTakingMove(attackers) : PlaySimpleMove(movers);
        }

        /// <summary>
        /// Gets the pieces that can attack.
        /// </summary>
        /// <param name="pieces">The pieces pool.</param>
        /// <returns>The attackers.</returns>
        private IEnumerable<Piece> GetAttackers(IEnumerable<Piece> pieces) => pieces.Where(p => _board.GetPossibleTakingsMoves(p).Any());

        /// <summary>
        /// Gets the pieces that can move.
        /// </summary>
        /// <param name="pieces">The pieces pool.</param>
        /// <returns>The mouvable pieces.</returns>
        private IEnumerable<Piece> GetMovablePieces(IEnumerable<Piece> pieces) => pieces.Where(p => _board.GetPossibleSimpleMoves(p).Any());

        /// <summary>
        /// Picks a destination among the possible ones for a specific piece.
        /// </summary>
        /// <param name="piece">The piece.</param>
        /// <returns>The destination.</returns>
        private IPosition PickDestination(Piece piece) => _board.GetPossibleSimpleMoves(piece).ToList().PickRandom().Target;

        /// <summary>
        /// Picks a target among the possible ones for a specific piece.
        /// </summary>
        /// <param name="attacker">The piece.</param>
        /// <returns>The target.</returns>
        private Piece PickTarget(Piece attacker) => _board.GetPossibleTakingsMoves(attacker).Select(m => new Piece(m.Target.X, m.Target.Y, ~attacker.Color)).ToList().PickRandom();

        /// <summary>
        /// Playes a simple move. Picks a piece and make it do a simple move.
        /// </summary>
        /// <param name="pieces">The pieces pool.</param>
        /// <returns>The played moves.</returns>
        private IEnumerable<Move> PlaySimpleMove(ICollection<Piece> pieces)
        {
            Piece piece = pieces.PickRandom();
            Piece origin = piece.Clone();

            IPosition position = PickDestination(piece);
            piece.Square = new Square(position.X, position.Y);

            yield return new SimpleMove(origin, piece);
        }

        /// <summary>
        /// Plays a taking move. Chooses an attacker among potential attackers and then chooses a target among its potential targets.
        /// </summary>
        /// <param name="attackers">The potential attackers.</param>
        /// <returns>The played moves.</returns>
        private IEnumerable<Move> PlayTakingMove(ICollection<Piece> attackers)
        {
            Piece attacker = attackers.PickRandom(); // TODO: add logic (i.e. pick the attacker that can take the more enemies
            Piece target = PickTarget(attacker);

            return PlayTakingMove(attacker, target);
        }
    }
}