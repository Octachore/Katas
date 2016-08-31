using System;

namespace Core.Utils.Defense.ConstraintsImplementations
{
    /// <summary>
    /// Provide a constraint for <see cref="int"/> to ensure it values at least a specific value.
    /// </summary>
    internal class IntegerAtMostConstraint : IGuardConstraint<int>
    {
        private readonly int _bound;

        /// <summary>
        /// Gets the inner exception in case of failure.
        /// </summary>
        public Exception InnerException => new ArgumentException($"Integer {Value} is more than {_bound}.");

        public int? Value { get; set; }

        public IntegerAtMostConstraint(int bound)
        {
            _bound = bound;
        }

        /// <summary>
        /// Evaluates the constraint against an argument.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <returns>The evaluation result.</returns>
        public bool Pass(int argument)
        {
            Value = argument;
            return Value <= _bound;
        }
    }
}
