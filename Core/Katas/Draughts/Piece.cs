namespace Core.Katas.Draughts
{
    public class Piece
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
    }
}