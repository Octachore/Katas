using Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Katas.Draughts.Helpers
{
    /// <summary>
    /// Provides helper methods for <see cref="Board"/>.
    /// </summary>
    public static class BoardHelper
    {
        /// <summary>
        /// Gets a <see cref="string"/> representing an empty <see cref="Board"/>.
        /// </summary>
        /// <param name="emptySquareRepresentation">The representation for each empty square.</param>
        /// <param name="size">The board size.</param>
        /// <returns>The <see cref="string"/> representation.</returns>
        public static string GetEmptyBoardString(string emptySquareRepresentation, int size = Board.DEFAULT_SIZE)
            => (emptySquareRepresentation.Repeat(size) + Environment.NewLine).Repeat(size);

        /// <summary>
        /// Gets the position of a <see cref="IPosition"/> in the representation <see cref="string"/>.
        /// </summary>
        /// <param name="x">The <see cref="IPosition"/> horizontal position coordinate.</param>
        /// <param name="y">The <see cref="IPosition"/> vertical position coordinate.</param>
        /// <param name="size">The board size.</param>
        /// <returns>The position in the <see cref="string"/>.</returns>
        public static int GetPositionInString(int x, int y, int size = Board.DEFAULT_SIZE) => (Board.DEFAULT_SIZE - y - 1) * (Board.DEFAULT_SIZE + Environment.NewLine.Length) + x;

        /// <summary>
        /// Gets a <see cref="string"/> representing a <see cref="Board"/>.
        /// </summary>
        /// <param name="board">The board.</param>
        /// <param name="emptySquareRepresentation">The representation for each empty square.</param>
        /// <returns>The <see cref="string"/> representation.</returns>
        public static string Print(this Board board, string emptySquareRepresentation = ".")
        {
            var builder = new StringBuilder(GetEmptyBoardString(emptySquareRepresentation));

            foreach (Piece piece in board.Pieces)
            {
                builder[GetPositionInString(piece.X, piece.Y)] = piece.Color.ToString().First();
            }

            return builder.ToString();
        }

        /// <summary>
        /// Gets the white pieces of a board.
        /// </summary>
        /// <param name="board">The board.</param>
        /// <returns>The white pieces.</returns>
        public static List<Piece> GetWhitePieces(this Board board) => board.Pieces.Where(p => p.Color == Color.White).ToList();

        /// <summary>
        /// Gets the black pieces of a board.
        /// </summary>
        /// <param name="board">The board.</param>
        /// <returns>The black pieces.</returns>
        public static List<Piece> GetBlackPieces(this Board board) => board.Pieces.Where(p => p.Color == Color.Black).ToList();
    }
}