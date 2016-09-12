using System;
using System.Linq;
using System.Text;
using System.Threading;
using Core.Utils;

namespace Core.Katas.Draughts.Helpers
{
    public static class BoardHelper
    {
        public static string GetEmptyBoardString(string emptySquareRepresentation, int size = Board.DEFAULT_SIZE)
            => (emptySquareRepresentation.Repeat(size) + Environment.NewLine).Repeat(size);

        public static int GetPositionInString(int x, int y, int size = Board.DEFAULT_SIZE) => (Board.DEFAULT_SIZE - y - 1) * (Board.DEFAULT_SIZE + Environment.NewLine.Length) + x;

        private static int GetStringSize(int boardSize) => boardSize * (boardSize + Environment.NewLine.Length);

        public static string Print(this Board board, string emptySquareRepresentation = ".")
        {
            var builder = new StringBuilder(GetEmptyBoardString(emptySquareRepresentation));

            foreach (Piece piece in board.Pieces)
            {
                builder[GetPositionInString(piece.X, piece.Y)] = piece.Color.ToString().First();
            }

            return builder.ToString();
        }
    }
}
