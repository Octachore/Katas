﻿using Core.Katas.Draughts;
using Core.Katas.Draughts.Exceptions;
using NUnit.Framework;
using System;

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
            var pw1Moves = new[] { new SimpleMove(_pw1, new Square(0, 2)) };
            var pw2Moves = new Move[0];
            var pw3Moves = new[] { new SimpleMove(_pw3, new Square(2, 6)), new SimpleMove(_pw3, new Square(4, 6)) };
            var pw4Moves = new[] { new SimpleMove(_pw4, new Square(8, 1)) };

            var pb1Moves = new[] { new SimpleMove(_pb1, new Square(3, 1)) };
            var pb2Moves = new[] { new SimpleMove(_pb2, new Square(4, 0)), new SimpleMove(_pb2, new Square(6, 0)) };
            var pb3Moves = new[] { new SimpleMove(_pb3, new Square(5, 5)) };
            var pb4Moves = new[] { new SimpleMove(_pb4, new Square(3, 3)), new SimpleMove(_pb4, new Square(5, 3)) };

            Assert.That(_board.GetPossibleSimpleMoves(_pw1), Is.EquivalentTo(pw1Moves));
            Assert.That(_board.GetPossibleSimpleMoves(_pw2), Is.EquivalentTo(pw2Moves));
            Assert.That(_board.GetPossibleSimpleMoves(_pw3), Is.EquivalentTo(pw3Moves));
            Assert.That(_board.GetPossibleSimpleMoves(_pw4), Is.EquivalentTo(pw4Moves));

            Assert.That(_board.GetPossibleSimpleMoves(_pb1), Is.EquivalentTo(pb1Moves));
            Assert.That(_board.GetPossibleSimpleMoves(_pb2), Is.EquivalentTo(pb2Moves));
            Assert.That(_board.GetPossibleSimpleMoves(_pb3), Is.EquivalentTo(pb3Moves));
            Assert.That(_board.GetPossibleSimpleMoves(_pb4), Is.EquivalentTo(pb4Moves));
        }

        [Test]
        public void A_Piece_Can_Determine_Its_Possible_Takings()
        {
            var pw1Takings = new[] { new TakingMove(_pw1, _pb1) };
            var pw2Takings = new TakingMove[0];
            var pw3Takings = new[] { new TakingMove(_pw3, _pb4) };
            var pw4Takings = new TakingMove[0];

            var pb1Takings = new[] { new TakingMove(_pb1, _pw1) };
            var pb2Takings = new TakingMove[0];
            var pb3Takings = new[] { new TakingMove(_pb3, _pw5) };
            var pb4Takings = new[] { new TakingMove(_pb4, _pw3) };

            Assert.That(_board.GetPossibleTakingsMoves(_pw1), Is.EquivalentTo(pw1Takings));
            Assert.That(_board.GetPossibleTakingsMoves(_pw2), Is.EquivalentTo(pw2Takings));
            Assert.That(_board.GetPossibleTakingsMoves(_pw3), Is.EquivalentTo(pw3Takings));
            Assert.That(_board.GetPossibleTakingsMoves(_pw4), Is.EquivalentTo(pw4Takings));

            Assert.That(_board.GetPossibleTakingsMoves(_pb1), Is.EquivalentTo(pb1Takings));
            Assert.That(_board.GetPossibleTakingsMoves(_pb2), Is.EquivalentTo(pb2Takings));
            Assert.That(_board.GetPossibleTakingsMoves(_pb3), Is.EquivalentTo(pb3Takings));
            Assert.That(_board.GetPossibleTakingsMoves(_pb4), Is.EquivalentTo(pb4Takings));
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