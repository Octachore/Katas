using System.Linq;

namespace Core.Katas.Draughts
{
    /// <summary>
    /// Represents the move of a piece on a board.
    /// </summary>
    public abstract class Move
    {
        /// <summary>
        /// Gets or sets the piece that does the move.
        /// </summary>
        public Piece Origin { get; set; }

        /// <summary>
        /// Gets or sets the target.
        /// </summary>
        public IPosition Target { get; set; }

        /// <summary>
        /// Gets the color of the move. If corresponds to the color of the <see cref="Origin"/>.
        /// </summary>
        public Color Color => Origin.Color;

        /// <summary>
        /// Gets a <see cref="string"/> describing the move type.
        /// </summary>
        protected abstract string Type { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Move"/> class.
        /// </summary>
        /// <param name="origin">The origin.</param>
        /// <param name="target">The target.</param>
        protected Move(Piece origin, IPosition target)
        {
            Origin = origin;
            Target = target;
        }

        /// <summary>
        /// Gets a <see cref="string"/> representation of the current <see cref="Move"/>.
        /// </summary>
        /// <returns>The <see cref="string"/> representation.</returns>
        public override string ToString() => $"{Color.ToString().First()} {Origin.X}|{Origin.Y} --> {Target.X}|{Target.Y} ({Type})";

        /// <summary>
        /// Compares an <see cref="object"/> to the current <see cref="Move"/> for equality.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>The equality comparison result.</returns>
        public override bool Equals(object obj)
        {
            var m = obj as Move;
            return (m?.Origin?.Equals(Origin) ?? false) && (m.Target?.Equals(Target) ?? false) && (m.Color == Color);
        }

        /// <summary>
        /// Gets the hash code of the current <see cref="Move"/>.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode() => Origin.GetHashCode() + 5 * Target.GetHashCode() + 7 * Color.GetHashCode();
    }
}