using System;

namespace Core.Katas.Draughts.Exceptions
{
    public class FriendlyAttackException : Exception
    {
        public FriendlyAttackException(string message) : base(message)
        {

        }
    }
}
