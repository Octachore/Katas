namespace Core.Katas.Draughts
{
    public class Mouve
    {
        public Square Origin { get; set; }

        public Square Target { get; set; }

        public MouveType Type { get; set; }

        public Mouve(Square origin, Square target, MouveType type)
        {
            Origin = origin;
            Target = target;
            Type = type;
        }

        public override string ToString() => $"{Origin} --> {Target} ({Type})";
    }
}
