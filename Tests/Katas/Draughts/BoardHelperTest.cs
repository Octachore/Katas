using System;
using Core.Katas.Draughts;
using Core.Katas.Draughts.Helpers;
using NUnit.Framework;

namespace Tests.Katas.Draughts
{
    public class BoardHelperTest
    {
        [Test]
        [TestCase(1, 1)]
        [TestCase(2, 4)]
        [TestCase(3, 9)]
        [TestCase(4, 16)]
        [TestCase(5, 25)]
        [TestCase(10, 100)]
        public void GetEmptyBoardString_Gets_Empty_Board_String_Representation(int boardSize, int stringLength)
        {
            string representation = BoardHelper.GetEmptyBoardString(".", boardSize);

            Assert.That(representation.Length, Is.EqualTo(stringLength + Environment.NewLine.Length * boardSize));
        }

        [Test]
        [TestCase(0, 0, 108)]
        [TestCase(1, 0, 109)]
        [TestCase(2, 0, 110)]
        [TestCase(5, 0, 113)]
        [TestCase(0, 1, 96)]
        [TestCase(0, 2, 84)]
        [TestCase(0, 5, 48)]
        [TestCase(1, 5, 49)]
        [TestCase(2, 5, 50)]
        [TestCase(5, 5, 53)]
        public void GetPositionInString_Gets_The_position_Of_The_Character_Representing_A_Position_In_The_Board(int x, int y, int expectedPosition)
        {
            var board = new Board();

            int position = BoardHelper.GetPositionInString(x, y);

            Assert.That(position, Is.EqualTo(expectedPosition));
        }

        [Test]
        [TestCaseSource(typeof(TestsData.Kata.Draughts.BoardExtensions.PrintBoard), nameof(TestsData.Kata.Draughts.BoardExtensions.PrintBoard.Data))]
        public void Print_Prints_Board(Board board, string expectedRepresentation)
        {
            string representation = board.Print();

            Assert.That(representation, Is.EqualTo(expectedRepresentation));
        }
    }
}
