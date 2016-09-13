namespace Core.Katas.Draughts
{
    /// <summary>
    /// Represents a square on a board.
    /// </summary>
    public class Square : IPosition
    {
        /// <summary>
        /// Gets the horizontal position coordinate.
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Gets the veetical position coordinate.
        /// </summary>
        public int Y { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Square"/> class.
        /// </summary>
        /// <param name="x">The horizontal position coordinate.</param>
        /// <param name="y">The vertical position coordinate.</param>
        public Square(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Compares an <see cref="object"/> to the current <see cref="Square"/> for equality.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>The equality comparison result.</returns>
        public override bool Equals(object obj) => obj as Square == this;

        /// <summary>
        /// Gets the hash code of the current <see cref="Square"/>.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode() => X.GetHashCode() + 7 * Y.GetHashCode();

        /// <summary>
        /// Gets a <see cref="string"/> representation of the current <see cref="Square"/>.
        /// </summary>
        /// <returns>The <see cref="string"/> representation.</returns>
        public override string ToString() => $"{X}|{Y}";

        /// <summary>
        /// Compares two <see cref="Square"/> objects for equality.
        /// </summary>
        /// <param name="square1">The first object.</param>
        /// <param name="square2">The second object.</param>
        /// <returns><c>true</c> if <see cref="square1"/> and <see cref="square2"/> are equal, <c>false</c> otherwise.</returns>
        public static bool operator ==(Square square1, Square square2) => (square1?.X == square2?.X) && (square1?.Y == square2?.Y);

        /// <summary>
        /// Compares two <see cref="Square"/> objects for inequality.
        /// </summary>
        /// <param name="square1">The first object.</param>
        /// <param name="square2">The second object.</param>
        /// <returns><c>true</c> if <see cref="square1"/> and <see cref="square2"/> are not equal, <c>false</c> otherwise.</returns>
        public static bool operator !=(Square square1, Square square2) => !(square1 == square2);
    }
}