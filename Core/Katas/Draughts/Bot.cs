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

        private Square PickDestination(Piece piece) => Board.GetPossibleMoves(piece).ToList().PickRandom();

        private void Attack(List<Piece> attackers, List<Piece> enemies)
        {
            Piece attacker = attackers.PickRandom(); // TODO: add logic (i.e. pick the attacker that can take the more enemies
            while (Board.GetPossibleTakings(attacker).Any())
            {
                Piece target = PickTarget(attacker);
                Board.Take(attacker, target);
            }
        }

        private Piece PickTarget(Piece attacker) => Board.GetPossibleTakings(attacker).Select(s => new Piece(s.X, s.Y, ~attacker.Color)).ToList().PickRandom();

        private IEnumerable<Piece> GetAttackers(IEnumerable<Piece> pieces) => pieces.Where(p => Board.GetPossibleTakings(p).Any());

        private IEnumerable<Piece> GetMovablePieces(IEnumerable<Piece> pieces) => pieces.Where(p => Board.GetPossibleMoves(p).Any());
    }
}
