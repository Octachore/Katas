namespace Core.Katas.Draughts
{
    public class SimpleMouve : Mouve
    {
        public SimpleMouve(Piece origin, IPosition target) : base(origin, target)
        {
        }

        protected override string Type => "Simple";
    }
}