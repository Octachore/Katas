using Core.Katas.Draughts.Helpers;
using Core.Utils;
using System.Collections.Generic;
using System.Linq;

namespace Core.Katas.Draughts
{
    public class Bot
    {
        public Bot(Board board)
        {
            Board = board;
        }

        public Board Board { get; }

        /// <summary>
        /// Plays a turn.
        /// </summary>
        /// <param name="color">The (bot) player color.</param>
        /// <returns>The played mouve.</returns>
        public IEnumerable<Mouve> PlayTurn(Color color)
        {
            List<Piece> pieces = Board.Pieces.GetPiecesOfColor(color).ToList();
            ////IEnumerable<Piece> enemies = Board.Pieces.GetPiecesOfColor(~color);
            List<Piece> attackers = GetAttackers(pieces).ToList();
            List<Piece> movers = GetMovablePieces(pieces).ToList();

            return attackers.Any() ? PlayTakingMouve(attackers) : PlaySimpleMove(movers);
        }

        private IEnumerable<Mouve> PlaySimpleMove(ICollection<Piece> pieces)
        {
            Piece piece = pieces.PickRandom();
            Square origin = piece.Square;

            IPosition position = PickDestination(piece);
            piece.Square = new Square(position.X, position.Y);

            yield return new SimpleMouve(origin, piece, piece.Color);
        }

        private IPosition PickDestination(Piece piece) => Board.GetPossibleSimpleMoves(piece).ToList().PickRandom().Target;

        private IEnumerable<Mouve> PlayTakingMouve(ICollection<Piece> attackers)
        {
            Piece attacker = attackers.PickRandom(); // TODO: add logic (i.e. pick the attacker that can take the more enemies
            Piece target = PickTarget(attacker);

            return PlayTakingMouve(attacker, target);
        }

        public IEnumerable<Mouve> PlayTakingMouve(Piece attacker, Piece target)
        {
            var mouves = new List<Mouve>();
            Piece origin = attacker.Clone();

            Board.Take(attacker, target);

            mouves.Add(new TakingMouve(origin, target, attacker.Color));

            if (Board.GetPossibleTakingsMouves(attacker).Any()) mouves.AddRange(PlayTakingMouve(attacker, target));

            return mouves;
        }

        private Piece PickTarget(Piece attacker) => Board.GetPossibleTakingsMouves(attacker).Select(m => new Piece(m.Target.X, m.Target.Y, ~attacker.Color)).ToList().PickRandom();

        private IEnumerable<Piece> GetAttackers(IEnumerable<Piece> pieces) => pieces.Where(p => Board.GetPossibleTakingsMouves(p).Any());

        private IEnumerable<Piece> GetMovablePieces(IEnumerable<Piece> pieces) => pieces.Where(p => Board.GetPossibleSimpleMoves(p).Any());
    }
}