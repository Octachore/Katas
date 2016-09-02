using Core.Katas.Draughts;
using NUnit.Framework;

namespace Tests.Katas
{
    public class DraughtsTests
    {
        [Test]
        public void A_Pawn_Can_Detremine_Its_Possible_Moves_Without_Taking_On_A_Board()
        {
            var board = new Board();


            var pw1 = new Piece(1, 1, Color.White);
            var pw2 = new Piece(3, 9, Color.White);
            var pw3 = new Piece(3, 5, Color.White);
            var pw4 = new Piece(0, 0, Color.White);

            var pb1 = new Piece(2, 2, Color.Black);
            var pb2 = new Piece(5, 1, Color.Black);
            var pb3 = new Piece(6, 6, Color.Black);
            var pb4 = new Piece(4, 4, Color.Black);

            var whitePawns = new[] { pw1, pw2, pw3, pw4 };
            var blackPawns = new[] { pb1, pb2, pb3, pb4 };

            board.Add(whitePawns);
            board.Add(blackPawns);


            var pw1Mouves = new[] { new Square(0, 2) };
            var pw2Mouves = new Square[0];
            var pw3Mouves = new[] { new Square(2, 6), new Square(4, 6) };
            var pw4Mouves = new Square[0];

            var pb1Mouves = new[] { new Square(3, 1) };
            var pb2Mouves = new[] { new Square(4, 0), new Square(6, 0) };
            var pb3Mouves = new[] { new Square(5, 5), new Square(7, 5) };
            var pb4Mouves = new[] { new Square(3, 3), new Square(5, 3) };

            Assert.That(board.GetPossibleMoves(pw1), Is.EquivalentTo(pw1Mouves));
            Assert.That(board.GetPossibleMoves(pw2), Is.EquivalentTo(pw2Mouves));
            Assert.That(board.GetPossibleMoves(pw3), Is.EquivalentTo(pw3Mouves));
            Assert.That(board.GetPossibleMoves(pw4), Is.EquivalentTo(pw4Mouves));

            Assert.That(board.GetPossibleMoves(pb1), Is.EquivalentTo(pb1Mouves));
            Assert.That(board.GetPossibleMoves(pb2), Is.EquivalentTo(pb2Mouves));
            Assert.That(board.GetPossibleMoves(pb3), Is.EquivalentTo(pb3Mouves));
            Assert.That(board.GetPossibleMoves(pb4), Is.EquivalentTo(pb4Mouves));
        }
    }
}
