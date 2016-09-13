using System;

namespace Core.Utils.Defense
{
    /// <summary>
    /// Represents a guard constraint.
    /// </summary>
    /// <typeparam name="T">The type of the constrained argument.</typeparam>
    public interface IGuardConstraint<in T>
    {
        /// <summary>
        /// Gets the inner exception in case of failure.
        /// </summary>
        Exception InnerException { get; }

        /// <summary>
        /// Evaluates the constraint against an argument.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <returns>The evaluation result.</returns>
        bool Pass(T argument);
    }
}