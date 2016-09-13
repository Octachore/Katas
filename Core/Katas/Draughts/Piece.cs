namespace Core.Katas.Draughts
{
    public class Piece : IPosition
    {
        public Square Square { get; set; }

        public int X => Square.X;

        public int Y => Square.Y;

        public Color Color { get; set; }

        public bool IsQueen { get; set; } = false;

        public Piece(int x, int y, Color color)
        {
            Square = new Square(x, y);
            Color = color;
        }

        public override string ToString() => $"{X}|{Y} {Color}";

        public Piece Clone() => MemberwiseClone() as Piece;

        public override bool Equals(object obj) => (obj as Piece) == this;

        public override int GetHashCode() => Square.GetHashCode() + 7 * Color.GetHashCode();

        public static bool operator ==(Piece p1, Piece p2) => p1?.Square == p2?.Square && p1?.Color == p2?.Color;

        public static bool operator !=(Piece p1, Piece p2) => !(p1 == p2);
    }
}