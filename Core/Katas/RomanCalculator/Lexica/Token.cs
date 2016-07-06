namespace Core.Katas.RomanCalculator.Lexica
{
    internal class Token
    {
        public Token(TokenType type)
        {
            Type = type;
        }

        public TokenType Type { get; private set; }

        public override string ToString()
        {
            return Type.ToString();
        }
    }
}
