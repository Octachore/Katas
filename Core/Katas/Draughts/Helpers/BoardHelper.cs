using System;
using System.Linq;
using System.Text;
using Core.Utils;

namespace Core.Katas.Draughts.Helpers
{
    public static class BoardHelper
    {
        public static string GetEmptyBoardString(string emptySquareRepresentation, int size = Board.DEFAULT_SIZE)
            => (emptySquareRepresentation.Repeat(size) + Environment.NewLine).Repeat(size);

        public static int GetPositionInString(int x, int y, int size = Board.DEFAULT_SIZE) => y * (size + Environment.NewLine.Length) + x;

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
