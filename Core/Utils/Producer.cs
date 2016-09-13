using System.Collections.Generic;

namespace Core.Utils
{
    /// <summary>
    /// An helper to produce values.
    /// </summary>
    internal static class Producer
    {
        /// <summary>
        /// Produces <see cref="int"/> in a range.
        /// </summary>
        /// <param name="minValue">The min value.</param>
        /// <param name="maxValue">The max value.</param>
        /// <returns>The generated integers.</returns>
        public static IEnumerable<int> ProduceIntegers(int minValue, int maxValue)
        {
            for (int i = minValue; i <= maxValue; i++)
            {
                yield return i;
            }
        }
    }
}