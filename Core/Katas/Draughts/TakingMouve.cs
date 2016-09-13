using Core.Utils.Defense;
using System;

namespace Core.Katas.Draughts
{
    public class TakingMouve : Mouve
    {
        public TakingMouve(Piece origin, Piece target, Color color) : base(origin, target, color)
        {
            Guard.Requires(origin != null, new ArgumentException($"The {nameof(origin)} must not be null."));
            Guard.Requires(target != null, new ArgumentException($"The {nameof(target)} must not be null."));
        }

        protected override string Type => "Taking";
    }
}