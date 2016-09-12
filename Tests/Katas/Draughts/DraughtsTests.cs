using System;
using Core.Katas.Draughts;
using Core.Katas.Draughts.Exceptions;
using Core.Katas.Draughts.Helpers;
using NUnit.Framework;

namespace Tests.Katas.Draughts
{
    public class DraughtsTests
    {
        private Board _board;
        private int _initialPiecesCount;

        private Piece _pw1;
        private Piece _pw2;
        private Piece _pw3;
        private Piece _pw4;
        private Piece _pw5;

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
            _pw5 = new Piece(7, 5, Color.White);

            _pb1 = new Piece(2, 2, Color.Black);
            _pb2 = new Piece(5, 1, Color.Black);
            _pb3 = new Piece(6, 6, Color.Black);
            _pb4 = new Piece(4, 4, Color.Black);

            var whitePieces = new[] { _pw1, _pw2, _pw3, _pw4, _pw5 };
            var blackPieces = new[] { _pb1, _pb2, _pb3, _pb4 };

            _board.Add(whitePieces);
            _board.Add(blackPieces);

            _initialPiecesCount = _board.Pieces.Count;
        }

        [Test]
        public void A_Piece_Can_Detremine_Its_Possible_Moves_Without_Taking_On_A_Board()
        {
            var pw1Mouves = new[] { new Square(0, 2) };
            var pw2Mouves = new Square[0];
            var pw3Mouves = new[] { new Square(2, 6), new Square(4, 6) };
            var pw4Mouves = new[] { new Square(8, 1) };

            var pb1Mouves = new[] { new Square(3, 1) };
            var pb2Mouves = new[] { new Square(4, 0), new Square(6, 0) };
            var pb3Mouves = new[] { new Square(5, 5) };
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
        public void A_Piece_Can_Determine_Its_Possible_Takings()
        {
            var pw1Takings = new[] { new Square(2, 2) };
            var pw2Takings = new Square[0];
            var pw3Takings = new[] { new Square(4, 4) };
            var pw4Takings = new Square[0];

            var pb1Takings = new[] { new Square(1, 1) };
            var pb2Takings = new Square[0];
            var pb3Takings = new[] { new Square(7, 5) };
            var pb4Takings = new[] { new Square(3, 5) };

            Assert.That(_board.GetPossibleTakings(_pw1), Is.EquivalentTo(pw1Takings));
            Assert.That(_board.GetPossibleTakings(_pw2), Is.EquivalentTo(pw2Takings));
            Assert.That(_board.GetPossibleTakings(_pw3), Is.EquivalentTo(pw3Takings));
            Assert.That(_board.GetPossibleTakings(_pw4), Is.EquivalentTo(pw4Takings));

            Assert.That(_board.GetPossibleTakings(_pb1), Is.EquivalentTo(pb1Takings));
            Assert.That(_board.GetPossibleTakings(_pb2), Is.EquivalentTo(pb2Takings));
            Assert.That(_board.GetPossibleTakings(_pb3), Is.EquivalentTo(pb3Takings));
            Assert.That(_board.GetPossibleTakings(_pb4), Is.EquivalentTo(pb4Takings));
        }

        [Test]
        public void A_Piece_Can_Take_An_Enemy()
        {
            _board.Take(_pw1, _pb1);

            Assert.That(_board.Pieces.Count == _initialPiecesCount - 1);
            Assert.That(_board.Pieces, Does.Not.Contains(_pb1));
            Assert.That(_pw1.X, Is.EqualTo(3));
            Assert.That(_pw1.Y, Is.EqualTo(3));

            _board.Take(_pb3, _pw5);

            Assert.That(_board.Pieces.Count == _initialPiecesCount - 2);
            Assert.That(_board.Pieces, Does.Not.Contains(_pw5));
            Assert.That(_pb3.X, Is.EqualTo(8));
            Assert.That(_pb3.Y, Is.EqualTo(4));

            Setup();

            _board.Take(_pb1, _pw1);

            Assert.That(_board.Pieces.Count == _initialPiecesCount - 1);
            Assert.That(_board.Pieces, Does.Not.Contains(_pw1));
            Assert.That(_pb1.X, Is.EqualTo(0));
            Assert.That(_pb1.Y, Is.EqualTo(0));
        }

        [Test]
        public void A_Piece_Can_Not_Take_A_Friend()
        {
            _pw1 = new Piece(0, 0, Color.White);
            _pw2 = new Piece(1, 1, Color.White);
            _board = new Board(_pw1, _pw2);

            Assert.Throws<FriendlyAttackException>(() => _board.Take(_pw1, _pw2));
        }

        [Test]
        public void A_Piece_Can_Not_Take_If_No_Piece_To_Take()
        {
            _pw1 = new Piece(0, 0, Color.White);
            _pb1 = new Piece(1, 1, Color.Black);
            _pb2 = new Piece(9, 9, Color.Black);
            _board = new Board(_pw1, _pb2);

            Assert.Throws<PieceNotOnBoardException>(() => _board.Take(_pw1, _pb1));
            Assert.Throws<InvalidMoveException>(() => _board.Take(_pw1, _pb2));
        }

        [Test]
        public void A_Piece_Can_Not_Take_If_Destination_Not_Free()
        {
            _pw1 = new Piece(0, 0, Color.White);
            _pb1 = new Piece(1, 1, Color.Black);
            _pb2 = new Piece(2, 2, Color.Black);
            _board = new Board(_pw1, _pb1, _pb2);

            Assert.Throws<OccupiedSquareException>(() => _board.Take(_pw1, _pb1));
        }

        [Test]
        [Category("Dummy")]
        public void DummyBotTest()
        {
            throw new NotImplementedException();
        }
    }
}
