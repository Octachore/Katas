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
    }
}
