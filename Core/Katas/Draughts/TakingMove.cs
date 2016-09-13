using Core.Utils.Defense;
using System;

namespace Core.Katas.Draughts
{
    /// <summary>
    /// Represents a taking move.
    /// </summary>
    public class TakingMove : Move
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TakingMove"/> class.
        /// </summary>
        /// <param name="origin">The origin.</param>
        /// <param name="target">The target.</param>
        public TakingMove(Piece origin, Piece target) : base(origin, target)
        {
            Guard.Requires(origin != null, new ArgumentException($"The {nameof(origin)} must not be null."));
            Guard.Requires(target != null, new ArgumentException($"The {nameof(target)} must not be null."));
        }

        /// <summary>
        /// Gets a <see cref="string"/> describing the move type.
        /// </summary>
        protected override string Type => "Taking";
    }
}