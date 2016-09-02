using Core.Katas.Draughts;
using NUnit.Framework;

namespace Tests.Katas
{
    public class DraughtsTests
    {
        private Board _board;

        private Piece _pw1;
        private Piece _pw2;
        private Piece _pw3;
        private Piece _pw4;

        private Piece _pb1;
        private Piece _pb2;
        private Piece _pb3;
        private Piece _pb4;

        [SetUp]
        public void Setup()
        {
            _board = new Board();

            _pw1 = new Piece(1, 1, Color.White);
            _pw2 = new Piece(3, 9, Color.White);
            _pw3 = new Piece(3, 5, Color.White);
            _pw4 = new Piece(9, 0, Color.White);

            _pb1 = new Piece(2, 2, Color.Black);
            _pb2 = new Piece(5, 1, Color.Black);
            _pb3 = new Piece(6, 6, Color.Black);
            _pb4 = new Piece(4, 4, Color.Black);

            var whitePawns = new[] { _pw1, _pw2, _pw3, _pw4 };
            var blackPawns = new[] { _pb1, _pb2, _pb3, _pb4 };

            _board.Add(whitePawns);
            _board.Add(blackPawns);
        }

        [Test]
        public void A_Pawn_Can_Detremine_Its_Possible_Moves_Without_Taking_On_A_Board()
        {
            var pw1Mouves = new[] { new Square(0, 2) };
            var pw2Mouves = new Square[0];
            var pw3Mouves = new[] { new Square(2, 6), new Square(4, 6) };
            var pw4Mouves = new[] { new Square(8, 1) };

            var pb1Mouves = new[] { new Square(3, 1) };
            var pb2Mouves = new[] { new Square(4, 0), new Square(6, 0) };
            var pb3Mouves = new[] { new Square(5, 5), new Square(7, 5) };
            var pb4Mouves = new[] { new Square(3, 3), new Square(5, 3) };

            Assert.That(_board.GetPossibleMoves(_pw1), Is.EquivalentTo(pw1Mouves));
            Assert.That(_board.GetPossibleMoves(_pw2), Is.EquivalentTo(pw2Mouves));
            Assert.That(_board.GetPossibleMoves(_pw3), Is.EquivalentTo(pw3Mouves));
            Assert.That(_board.GetPossibleMoves(_pw4), Is.EquivalentTo(pw4Mouves));

            Assert.That(_board.GetPossibleMoves(_pb1), Is.EquivalentTo(pb1Mouves));
            Assert.That(_board.GetPossibleMoves(_pb2), Is.EquivalentTo(pb2Mouves));
            Assert.That(_board.GetPossibleMoves(_pb3), Is.EquivalentTo(pb3Mouves));
            Assert.That(_board.GetPossibleMoves(_pb4), Is.EquivalentTo(pb4Mouves));
        }

        [Test]
        public void A_Pawn_Can_Determine_Its_Possible_Takings()
        {
            var pw1Takings = new[] { new Square(3, 3) };
            var pw2Takings = new Square[0];
            var pw3Takings = new Square[0];
            var pw4Takings = new Square[0];

            var pb1Takings = new[] { new Square(0, 0) };
            var pb2Takings = new Square[0];
            var pb3Takings = new Square[0];
            var pb4Takings = new Square[0];

            Assert.That(_board.GetPossibleTakings(_pw1), Is.EquivalentTo(pw1Takings));
            Assert.That(_board.GetPossibleTakings(_pw2), Is.EquivalentTo(pw2Takings));
            Assert.That(_board.GetPossibleTakings(_pw3), Is.EquivalentTo(pw3Takings));
            Assert.That(_board.GetPossibleTakings(_pw4), Is.EquivalentTo(pw4Takings));

            Assert.That(_board.GetPossibleTakings(_pb1), Is.EquivalentTo(pb1Takings));
            Assert.That(_board.GetPossibleTakings(_pb2), Is.EquivalentTo(pb2Takings));
            Assert.That(_board.GetPossibleTakings(_pb3), Is.EquivalentTo(pb3Takings));
            Assert.That(_board.GetPossibleTakings(_pb4), Is.EquivalentTo(pb4Takings));
        }
    }
}
