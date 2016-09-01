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

            var whitePawn = new Piece(1, 1, Color.White);

            var blackPawns = new[]
                             {
                                 new Piece(2, 2, Color.Black),
                                 new Piece(5, 1, Color.Black)
                             };

            var expectedPossibleMoves = new[]
                                        {
                                            new Square(0,2)
                                        };

            board.Add(whitePawn);
            board.Add(blackPawns);

            Assert.That(board.GetPossibleMoves(whitePawn), Is.EquivalentTo(expectedPossibleMoves));
        }
    }
}
