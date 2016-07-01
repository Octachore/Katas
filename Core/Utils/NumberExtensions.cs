using System.Collections.Generic;
using static System.Math;

namespace Core.Utils
{
    /// <summary>
    /// Provides extension methods for numbers.
    /// </summary>
    internal static class NumberExtensions
    {
        /// <summary>
        /// Checks if an <see cref="int"/> is a multiple of another.
        /// </summary>
        /// <param name="a">The potential multiple.</param>
        /// <param name="b">The other <see cref="int"/>.</param>
        /// <returns>The check result.</returns>
        public static bool IsMultipleOf(this int a, int b)
        {
            return b.IsDividerOf(a);
        }

        /// <summary>
        /// Checks if an <see cref="int"/> is a divider of another.
        /// </summary>
        /// <param name="a">The potential divider.</param>
        /// <param name="b">The other <see cref="int"/>.</param>
        /// <returns>The check result.</returns>
        public static bool IsDividerOf(this int a, int b)
        {
            if (a == 0 && b == 0) return true;
            if (a == 0 || b == 0) return false;
            return b % a == 0;
        }

        /// <summary>
        /// Checks if an <see cref="int"/> is a prime.
        /// </summary>
        /// <param name="a">The number to check.</param>
        /// <returns>The check result.</returns>
        public static bool IsPrime(this int a)
        {
            if (a <= 1) return false;
            if (a == 2) return true;
            if (a % 2 == 0) return false;

            int upperLimit = (int)Floor(Sqrt(a));
            for (int i = 3; i <= upperLimit; i += 2)
            {
                if (a % i == 0) return false;
            }

            return true;
        }

        /// <summary>
        /// Gets the primes from an input.
        /// </summary>
        /// <param name="integers">The input.</param>
        /// <returns>The primes.</returns>
        public static IEnumerable<int> GetPrimes(this IEnumerable<int> integers)
        {
            foreach (var integer in integers)
            {
                if (integer.IsPrime()) yield return integer;
            }
        }
    }
}
