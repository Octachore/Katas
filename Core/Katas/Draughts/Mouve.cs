using System.Linq;

namespace Core.Katas.Draughts
{
    public abstract class Mouve
    {
        public Piece Origin { get; set; }

        public IPosition Target { get; set; }

        public Color Color => Origin.Color;

        protected abstract string Type { get; }

        protected Mouve(Piece origin, IPosition target)
        {
            Origin = origin;
            Target = target;
        }

        public override string ToString() => $"{Color.ToString().First()} {Origin.X}|{Origin.Y} --> {Target.X}|{Target.Y} ({Type})";

        public override bool Equals(object obj)
        {
            var m = obj as Mouve;
            return (m?.Origin?.Equals(Origin) ?? false) && (m.Target?.Equals(Target) ?? false) && (m.Color == Color);
        }

        public override int GetHashCode() => Origin.GetHashCode() + 5 * Target.GetHashCode() + 7 * Color.GetHashCode();
    }
}