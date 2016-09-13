namespace Core.Katas.Draughts
{
    /// <summary>
    /// Represents a simple move (without taking).
    /// </summary>
    public class SimpleMove : Move
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleMove"/> class.
        /// </summary>
        /// <param name="origin">The orifin.</param>
        /// <param name="target">The target.</param>
        public SimpleMove(Piece origin, IPosition target) : base(origin, target)
        {
        }

        /// <summary>
        /// Gets a <see cref="string"/> describing the move type.
        /// </summary>
        protected override string Type => "Simple";
    }
}