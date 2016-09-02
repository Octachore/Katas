using System;

namespace Core.Utils.Defense
{
    /// <summary>
    /// Provides constraints checking on arguments.
    /// </summary>
    internal static class Guard
    {
        public static void That<T>(T argument, IGuardConstraint<T> constraint, string argumentName = null)
        {
            if (!constraint.Pass(argument)) throw new GuardException<T>(constraint);
        }

        public static void Requires(Func<bool> condition)
        {
            if (!condition()) throw new GuardException();
        }

        public static void Requires<T>(Func<bool> condition) where T : Exception, new()
        {
            if (!condition()) throw new T();
        }
    }
}
