namespace Core.Katas.Draughts
{
    public class Square
    {
        public int X { get; }

        public int Y { get; }

        public Square(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>Determines whether the specified object is equal to the current object.</summary>
        /// <returns>true if the specified object  is equal to the current object; otherwise, false.</returns>
        /// <param name="obj">The object to compare with the current object. </param>
        public override bool Equals(object obj) => (obj as Square) == this;

        /// <summary>Serves as the default hash function. </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode() => X.GetHashCode() + 7 * Y.GetHashCode();

        public override string ToString() => $"{X}|{Y}";

        public static bool operator ==(Square square1, Square square2) => (square1?.X == square2?.X) && (square1?.Y == square2?.Y);

        public static bool operator !=(Square square1, Square square2) => !(square1 == square2);
    }
}
