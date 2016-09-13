namespace Core.Katas.Draughts
{
    /// <summary>
    /// Represents a draughts piece.
    /// </summary>
    public class Piece : IPosition
    {
        /// <summary>
        /// Gets or sets the square containing the current piece.
        /// </summary>
        public Square Square { get; set; }

        /// <summary>
        /// Gets the horizontal coordinate of the position on the board.
        /// </summary>
        public int X => Square.X;

        /// <summary>
        /// Gets the vertical coordinate of the position on the board.
        /// </summary>
        public int Y => Square.Y;

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the current piece is a queen or not.
        /// </summary>
        public bool IsQueen { get; set; } = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="Piece"/> class.
        /// </summary>
        /// <param name="x">The horizontal position coordinate.</param>
        /// <param name="y">The vertical position coordinate.</param>
        /// <param name="color">The color.</param>
        public Piece(int x, int y, Color color)
        {
            Square = new Square(x, y);
            Color = color;
        }

        /// <summary>
        /// Gets a <see cref="string"/> representation of the current <see cref="Piece"/>.
        /// </summary>
        /// <returns>The <see cref="string"/> representation.</returns>
        public override string ToString() => $"{X}|{Y} {Color}";

        /// <summary>
        /// Creates a shallow copy of the current <see cref="Piece"/>.
        /// </summary>
        /// <returns>The clone.</returns>
        public Piece Clone() => MemberwiseClone() as Piece;

        /// <summary>
        /// Compares an <see cref="object"/> to the current <see cref="Piece"/> for equality.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>The equality comparison result.</returns>
        public override bool Equals(object obj) => obj as Piece == this;

        /// <summary>
        /// Gets the hash code of the current <see cref="Move"/>.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode() => Square.GetHashCode() + 7 * Color.GetHashCode();

        /// <summary>
        /// Compares two <see cref="Piece"/> objects for equality.
        /// </summary>
        /// <param name="p1">The first object.</param>
        /// <param name="p2">The second object.</param>
        /// <returns><c>true</c> if <see cref="p1"/> and <see cref="p2"/> are equal, <c>false</c> otherwise.</returns>
        public static bool operator ==(Piece p1, Piece p2) => (p1?.Square == p2?.Square) && (p1?.Color == p2?.Color);

        /// <summary>
        /// Compares two <see cref="Piece"/> objects for inequality.
        /// </summary>
        /// <param name="p1">The first object.</param>
        /// <param name="p2">The second object.</param>
        /// <returns><c>true</c> if <see cref="p1"/> and <see cref="p2"/> are not equal, <c>false</c> otherwise.</returns>
        public static bool operator !=(Piece p1, Piece p2) => !(p1 == p2);
    }
}