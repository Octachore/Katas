using System.Collections.Generic;
using static System.Math;

namespace Core.Utils
{
    internal static class NumberExtensions
    {
        public static bool IsMultipleOf(this int a, int b)
        {
            return b.IsDividerOf(a);
        }

        public static bool IsDividerOf(this int a, int b)
        {
            if (a == 0 && b == 0) return true;
            if (a == 0 || b == 0) return false;
            return b % a == 0;
        }

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

        public static IEnumerable<int> GetPrimes(this IEnumerable<int> integers)
        {
            foreach (var integer in integers)
            {
                if (integer.IsPrime()) yield return integer;
            }
        }
    }
}
