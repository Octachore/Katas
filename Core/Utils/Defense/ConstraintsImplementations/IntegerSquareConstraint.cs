using System;

namespace Core.Utils.Defense.ConstraintsImplementations
{
    /// <summary>
    /// Provide a constraint for <see cref="int"/> to ensure it is a square.
    /// </summary>
    internal class IntegerSquareConstraint : IGuardConstraint<int>
    {
        private readonly int? _value = null;

        /// <summary>
        /// Gets the inner exception in case of failure.
        /// </summary>
        public Exception InnerException => new ArgumentException($"Integer {_value} is not a square.");

        /// <summary>
        /// Evaluates the constraint against an argument.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <returns>The evaluation result.</returns>
        public bool Pass(int argument)
        {
            int intSqrt = (int)Math.Sqrt(argument);
            return intSqrt * intSqrt == argument;
        }
    }
}