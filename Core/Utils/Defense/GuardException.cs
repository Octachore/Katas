using System;

namespace Core.Utils.Defense
{
    /// <summary>
    /// Represents a exception occurring when a <see cref="IGuardConstraint{T}"/> evaluation fails.
    /// </summary>
    /// <typeparam name="T">The type of the evaluated argument.</typeparam>
    internal class GuardException<T> : Exception
    {
        public GuardException(IGuardConstraint<T> constraint) : base("Guard failed.", constraint.InnerException)
        {
        }
    }
    internal class GuardException : Exception
    {
    }

}