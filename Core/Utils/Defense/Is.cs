using Core.Utils.Defense.ConstraintsImplementations;

namespace Core.Utils.Defense
{
    /// <summary>
    /// Provides constraints.
    /// </summary>
    internal static class Is
    {
        /// <summary>
        /// Gets an <see cref="IntegerSquareConstraint"/>.
        /// </summary>
        public static IntegerSquareConstraint Square { get; } = new IntegerSquareConstraint();
    }
}
