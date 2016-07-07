using System.Collections.Generic;
using System.Linq;

namespace Core.Katas.RomanCalculator
{
    internal static class EnumHelper
    {
        public static bool HasMoreThan<T>(this IEnumerable<T> elements, int strictLowerLimit)
        {
            return elements.Skip(strictLowerLimit).Any();
        }
    }
}
