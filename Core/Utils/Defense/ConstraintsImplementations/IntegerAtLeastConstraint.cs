using System;

namespace Core.Utils.Defense.ConstraintsImplementations
{
    /// <summary>
    /// Provide a constraint for <see cref="int"/> to ensure it values at least a specific value.
    /// </summary>
    internal class IntegerAtLeastConstraint : IGuardConstraint<int>
    {
        private int? _value;
        private readonly int _bound;

        /// <summary>
        /// Gets the inner exception in case of failure.
        /// </summary>
        public Exception InnerException => new ArgumentException($"Integer {_value} is less than {_bound}.");

        public IntegerAtLeastConstraint(int bound)
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
            _value = argument;
            return _value >= _bound;
        }
    }
}