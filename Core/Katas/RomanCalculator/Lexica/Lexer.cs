using System;

namespace Core.Katas.RomanCalculator.Lexica
{
    internal class Lexer
    {
        private readonly string _input;

        private int _pos = 0;

        public Lexer(string input)
        {
            _input = input;
        }

        public Token GetNextToken()
        {
            if (_pos >= _input.Length) return null;

            char symbol = _input[_pos];
            _pos++;

            switch (symbol)
            {
                case 'I':
                    return new Token(TokenType.I);

                case 'V':
                    return new Token(TokenType.V);

                case 'X':
                    return new Token(TokenType.X);

                case 'L':
                    return new Token(TokenType.L);

                case 'C':
                    return new Token(TokenType.C);

                case 'D':
                    return new Token(TokenType.D);

                case 'M':
                    return new Token(TokenType.M);

                default:
                    throw new ArgumentException($"Unrecognized token: {symbol}.");
            }
        }
    }
}