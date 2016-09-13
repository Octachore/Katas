using System.Linq;

namespace Core.Katas.Draughts
{
    public abstract class Mouve
    {
        public IPosition Origin { get; set; }

        public IPosition Target { get; set; }

        public Color Color { get; set; }

        protected abstract string Type { get; }

        protected Mouve(IPosition origin, IPosition target, Color color)
        {
            Origin = origin;
            Target = target;
            Color = color;
        }

        public override string ToString() => $"{Color.ToString().First()} {Origin.X}|{Origin.Y} --> {Target.X}|{Target.Y} ({Type})";
    }
}
