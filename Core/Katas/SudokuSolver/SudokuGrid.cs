using Core.Utils;
using Core.Utils.Defense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Katas.SudokuSolver
{
    /// <summary>
    /// Represents a sudoku grid.
    /// </summary>
    internal class SudokuGrid
    {
        private SudokuCell[,] _cells;
        private IEnumerable<int> _possibleValues;
        private int _size;

        /// <summary>
        /// Initializes a new instance of the <see cref="SudokuGrid"/> class. All the cells are "empty" (their value is <c>null</c>).
        /// </summary>
        /// <param name="size">The grid size. Must be a square.</param>
        public SudokuGrid(int size) : this(new int[size, size])
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SudokuGrid"/> class. All the cells are "empty" (their value is <c>null</c>).
        /// </summary>
        /// <param name="grid">The values grid. Must be a square.</param>
        public SudokuGrid(int[,] grid)
        {
            Guard.That(grid.Length, Is.Square);

            int size = (int)Math.Sqrt(grid.Length);
            Guard.That(size, Is.Square);

            _size = size;
            _cells = new SudokuCell[size, size];
            _possibleValues = Producer.ProduceIntegers(1, size);

            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    int value = grid[i, j];
                    _cells[i, j] = new SudokuCell();
                    _cells[i, j].Value = value > 0 && value <= grid.Length ? value : (int?)null;
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether the grid is solved or not.
        /// </summary>
        public bool IsSolved
        {
            get
            {
                for (int i = 0; i < _size; i++)
                {
                    for (int j = 0; j < _size; j++)
                    {
                        if (!_cells[i, j].IsSolved) return false;
                    }
                }
                return true;
            }
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            var grid = obj as SudokuGrid;
            return (grid != null) && Comparer.AreSequenceEqual(_cells, grid._cells);
        }

        /// <summary>
        /// Retrieves the hash code of the object.
        /// </summary>
        /// <returns>The hash code of the object.</returns>
        public override int GetHashCode()
        {
            return _cells.GetHashCode();
        }

        /// <summary>
        /// Solves the grid.
        /// </summary>
        public void Solve()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (!_cells[i, j].IsSolved) SolveCell(i, j);
                }
            }

            if (!IsSolved) Solve();
        }

        /// <summary>
        /// Solves a cell.
        /// </summary>
        /// <param name="i">The easting coordinate.</param>
        /// <param name="j">The northing coordinate.</param>
        public void SolveCell(int i, int j)
        {
            SudokuCell cell = _cells[i, j];

            int initialPossibilitiesNumber = cell.Possibilities.Count();

            if (cell.IsSolved) return;

            IEnumerable<int> freeInSquare = GetFreeInSquare(i, j);
            IEnumerable<int> freeInLine = GetFreeInLine(i, j);
            IEnumerable<int> freeInColumn = GetFreeInColumn(i, j);

            IEnumerable<int> possibilities = freeInSquare.Intersect(freeInLine).Intersect(freeInColumn);

            if (!possibilities.Any())
                throw new InvalidOperationException("Not solvable");

            if (possibilities.Count() == 1) cell.Value = possibilities.First();
            else cell.Possibilities = possibilities;

            if (!cell.IsSolved && cell.Possibilities.Count() < initialPossibilitiesNumber) SolveCell(i, j);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            var builder = new StringBuilder();
            for (int i = 0; i < _size; i++)
            {
                builder.Append("|");
                for (int j = 0; j < _size; j++)
                {
                    builder.Append(_cells[i, j].Value ?? 0);
                }
                builder.Append("|");
                builder.AppendLine();
            }
            return builder.ToString();
        }
        /// <summary>
        /// Gets the free values in a column.
        /// </summary>
        /// <param name="i">The easting coordinate.</param>
        /// <param name="j">The northing coordinate.</param>
        /// <returns>The free values.</returns>
        private IEnumerable<int> GetFreeInColumn(int i, int j)
        {
            List<int?> used = new List<int?>();

            for (int x = 0; x < _size; x++)
            {
                if (x == i) continue;

                used.Add(_cells[x, j].Value);
            }
            return _possibleValues.Except(used.Where(p => p != null).Select(p => (int)p));
        }

        /// <summary>
        /// Gets the free values in a line.
        /// </summary>
        /// <param name="i">The easting coordinate.</param>
        /// <param name="j">The northing coordinate.</param>
        /// <returns>The free values.</returns>
        private IEnumerable<int> GetFreeInLine(int i, int j)
        {
            List<int?> used = new List<int?>();

            for (int y = 0; y < _size; y++)
            {
                if (y == j) continue;

                used.Add(_cells[i, y].Value);
            }
            return _possibleValues.Except(used.Where(p => p != null).Select(p => (int)p));
        }

        /// <summary>
        /// Gets the free values in a square.
        /// </summary>
        /// <param name="i">The easting coordinate.</param>
        /// <param name="j">The northing coordinate.</param>
        /// <returns>The free values.</returns>
        private IEnumerable<int> GetFreeInSquare(int i, int j)
        {
            Tuple<int, int> coordinates = GetSquareTopLeftCoordinates(i, j);
            List<int?> used = new List<int?>();

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (coordinates.Item1 + x == i && coordinates.Item2 + y == j) continue;

                    used.Add(_cells[coordinates.Item1 + x, coordinates.Item2 + y].Value);
                }
            }
            return _possibleValues.Except(used.Where(p => p != null).Select(p => (int)p));
        }

        /// <summary>
        /// Gets the coordinates of the top left cell of the square.
        /// </summary>
        /// <param name="i">The easting coordinate.</param>
        /// <param name="j">The northing coordinate.</param>
        /// <returns>The top left cell coordinates.</returns>
        private Tuple<int, int> GetSquareTopLeftCoordinates(int i, int j)
        {
            int squareSize = (int)Math.Sqrt(_size);
            i = i / squareSize * squareSize;
            j = j / squareSize * squareSize;
            return new Tuple<int, int>(i, j);
        }
    }
}
