using System;

namespace Core.Katas.Draughts.Exceptions
{
    public class FriendlyAttackException : Exception
    {
        public Piece Attacker { get; set; }

        public Piece Target { get; set; }

        public FriendlyAttackException(string message, Piece attacker, Piece target) : base(message)
        {
            Attacker = attacker;
            Target = target;
        }
    }
}
