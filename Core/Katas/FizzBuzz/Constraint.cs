using System;

namespace Core.Katas.FizzBuzz
{
    /// <summary>
    /// A <see cref="Constraint{T, U}"/> represents a causality link between a <see cref="TArgument"/> and a <see cref="Replacement"/>.
    /// It has an evaluation function that tells if the <see cref="TArgument"/> should be replaced with the <see cref="Replacement"/>.
    /// </summary>
    /// <typeparam name="TArgument">The type of the object to check.</typeparam>
    /// <typeparam name="TReplacement">The type of the <see cref="Replacement"/>.</typeparam>
    internal class Constraint<TArgument, TReplacement>
    {
        private readonly Func<TArgument, bool> _evaluation;

        /// <summary>
        /// Initializes a new instance of the <see cref="Constraint{T, U}"/> class.
        /// </summary>
        /// <param name="evaluation">An evaluation function that tells if the <see cref="TArgument"/> should be replaced with the <see paramref="replacement"/>.</param>
        /// <param name="replacement">A <see cref="TReplacement"/> that should replace any item <see cref="TArgument"/> if <see paramref="evaluation"/> evaluates to <c>true</c> on that item.</param>
        public Constraint(Func<TArgument, bool> evaluation, TReplacement replacement)
        {
            _evaluation = evaluation;
            Replacement = replacement;
        }

        /// <summary>
        /// Gets the replacement.
        /// </summary>
        public TReplacement Replacement { get; }

        /// <summary>
        /// Evaluates whether the <paramref name="elementToTest"/> should be replaced with <see cref="Replacement"/>.
        /// </summary>
        /// <param name="elementToTest">The element to test.</param>
        /// <returns>A value indicating whether the <paramref name="elementToTest"/> should be replaced with <see cref="Replacement"/>.</returns>
        public bool Evaluate(TArgument elementToTest) => _evaluation(elementToTest);
    }
}
