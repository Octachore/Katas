using System.Linq;

namespace Core.Utils
{
    /// <summary>
    /// An helper to compare arguments.
    /// </summary>
    internal static class Comparer
    {
        /// <summary>
        /// Checks if two two-dimensional arrays are sequence equal.
        /// </summary>
        /// <typeparam name="T">The type of the arguments in the arrays.</typeparam>
        /// <param name="a">The first array.</param>
        /// <param name="b">The second array.</param>
        /// <returns>The comparison result.</returns>
        public static bool AreSequenceEqual<T>(T[,] a, T[,] b)
        {
            return a.Rank == b.Rank
                    && Enumerable.Range(0, a.Rank).All(dimension => a.GetLength(dimension) == b.GetLength(dimension))
                    && a.Cast<T>().SequenceEqual(b.Cast<T>());
        }
    }
}
