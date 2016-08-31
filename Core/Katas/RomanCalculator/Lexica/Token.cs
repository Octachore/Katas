namespace Core.Katas.RomanCalculator.Lexica
{
    internal class Token
    {
        public Token(TokenType type)
        {
            Type = type;
        }

        public TokenType Type { get; }

        public override string ToString() => Type.ToString();
    }
}
