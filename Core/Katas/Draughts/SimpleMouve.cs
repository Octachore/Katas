namespace Core.Katas.Draughts
{
    public class SimpleMouve : Mouve
    {
        public SimpleMouve(IPosition origin, IPosition target, Color color) : base(origin, target, color)
        {
        }

        protected override string Type => "Simple";
    }
}
