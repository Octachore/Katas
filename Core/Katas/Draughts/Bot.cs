using Core.Utils;
using System.Collections.Generic;
using System.Linq;
using Core.Katas.Draughts.Helpers;

namespace Core.Katas.Draughts
{
    public class Bot
    {
        public Bot(Board board)
        {
            Board = board;
        }

        public Board Board { get; }
        public void PlayTurn(Color color)
        {
            List<Piece> pieces = Board.Pieces.GetPiecesOfColor(color).ToList();
            List<Piece> enemies = Board.Pieces.GetPiecesOfColor(~color).ToList();
            List<Piece> attackers = GetAttackers(pieces).ToList();
            List<Piece> movers = GetMovablePieces(pieces).ToList();

            if (attackers.Any())
            {
                Attack(attackers, enemies);
            }
            else
            {
                Move(movers);
            }
        }

        private void Move(List<Piece> pieces)
        {
            Piece piece = pieces.PickRandom();
            piece.Square = PickDestination(piece);
        }

        private Square PickDestination(Piece piece) => Board.GetPossibleSimpleMoves(piece).ToList().PickRandom().Target;

        private void Attack(List<Piece> attackers, List<Piece> enemies)
        {
            Piece attacker = attackers.PickRandom(); // TODO: add logic (i.e. pick the attacker that can take the more enemies
            while (Board.GetPossibleTakingsMouves(attacker).Any())
            {
                Piece target = PickTarget(attacker);
                Board.Take(attacker, target);
            }
        }

        private Piece PickTarget(Piece attacker) => Board.GetPossibleTakingsMouves(attacker).Select(m => new Piece(m.Target.X, m.Target.Y, ~attacker.Color)).ToList().PickRandom();

        private IEnumerable<Piece> GetAttackers(IEnumerable<Piece> pieces) => pieces.Where(p => Board.GetPossibleTakingsMouves(p).Any());

        private IEnumerable<Piece> GetMovablePieces(IEnumerable<Piece> pieces) => pieces.Where(p => Board.GetPossibleSimpleMoves(p).Any());
    }
}
