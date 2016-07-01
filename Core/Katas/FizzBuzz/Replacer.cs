using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Katas.FizzBuzz
{
    /// <summary>
    /// A <see cref="Replacer{T, U}"/> produces an output <see cref="IEnumerable{U}"/> equivalent to an input <see cref="IEnumerable{T}"/> with some item replaced according to specified <see cref="Constraint{T, U}"/>.
    /// </summary>
    /// <typeparam name="T">The type of the items in the input enumeration.</typeparam>
    /// <typeparam name="U">The type of the items in the output enumeration.</typeparam>
    internal class Replacer<T, U>
    {
        private Constraint<T, U>[] _constraints;
        private Func<IEnumerable<U>, U> _joiner;

        /// <summary>
        /// Initializes a new instance of the <see cref="Replacer{T, U}"/> class.
        /// </summary>
        /// <param name="joiner">A function to join multiple <see cref="U"/> into one.</param>
        /// <param name="constraints">The replacement constraints.</param>
        public Replacer(Func<IEnumerable<U>, U> joiner, params Constraint<T, U>[] constraints)
        {
            _joiner = joiner;
            _constraints = constraints;
        }

        /// <summary>
        /// Produces an output <see cref="IEnumerable{U}"/> equivalent to an input <see cref="IEnumerable{T}"/> with some item replaced according to specified <see cref="Constraint{T, U}"/>.
        /// </summary>
        /// <param name="input">The input enumeration.</param>
        /// <returns>The output enumeration.</returns>
        public IEnumerable<U> Replace(IEnumerable<T> input)
        {
            foreach (T item in input)
            {
                List<U> replacements = new List<U>();
                foreach (Constraint<T, U> constraint in _constraints)
                {
                    if (constraint.Evaluate(item)) replacements.Add(constraint.Replacement);
                }
                if (replacements.Any()) yield return _joiner(replacements);
                else yield return (U)Convert.ChangeType(item, typeof(U));
            }
        }
    }
}
