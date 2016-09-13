using System.Collections.Generic;

namespace Core.Katas.SudokuSolver
{
    /// <summary>
    /// Represents a cell in a sudoku grid.
    /// </summary>
    internal class SudokuCell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SudokuCell"/> class.
        /// </summary>
        /// <param name="value">The cell value.</param>
        public SudokuCell(int? value = null)
        {
            Value = value;
            Possibilities = new List<int>();
        }

        /// <summary>
        /// Gets a value indicating whether the cell is solved or not.
        /// </summary>
        public bool IsSolved => Value != null;

        /// <summary>
        /// Gets or sets the possible values for the cell.
        /// </summary>
        public IEnumerable<int> Possibilities { get; set; }

        /// <summary>
        /// Gets or sets the cell value.
        /// </summary>
        public int? Value { get; set; }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj) => Value == (obj as SudokuCell)?.Value;

        /// <summary>
        /// Retrieves the hash code of the object.
        /// </summary>
        /// <returns>The hash code of the object.</returns>
        public override int GetHashCode() => Value.GetHashCode();
    }
}