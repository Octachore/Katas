using Core.Katas.RomanCalculator.Lexica;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Katas.RomanCalculator
{
    internal static class Compacter
    {
        public static void Compact(ref List<Token> tokens)
        {
            if (tokens.Count <= 1) return;

            var compacted = new List<Token>();
            var buffer = new Queue<Token>(4);
            foreach (Token token in tokens)
            {
                buffer.Enqueue(token);

                compacted.AddRange(buffer.SquashIfPossible());
            }

            compacted.AddRange(buffer);

            tokens = compacted.Where(t => t != null).ToList();
        }

        public static void Uncompact(ref List<Token> tokens)
        {
            if (tokens.Count <= 1) return;

            var uncompacted = new List<Token>();
            var buffer = new Queue<Token>(2);
            foreach (Token token in tokens)
            {
                buffer.Enqueue(token);

                uncompacted.AddRange(buffer.InAdditiveForm());
            }

            uncompacted.AddRange(buffer);

            tokens = uncompacted.Where(t => t != null).ToList();
        }

        private static IEnumerable<Token> InAdditiveForm(this Queue<Token> buffer)
        {
            if (buffer.IsSubstractiveForm())
            {
                foreach (Token token in TransformToAdditiveForm(buffer))
                {
                    yield return token;
                }
                buffer.Clear();
            }
            else if (buffer.HasMoreThan(1))
            {
                yield return buffer.Dequeue();
            }
        }

        private static IEnumerable<Token> SquashIfPossible(this Queue<Token> buffer)
        {
            if (buffer.HasFourIdentiqualTokens())
            {
                foreach (Token token in SquashTokens(buffer))
                {
                    yield return token;
                }
                buffer.Clear();
            }
            else if (buffer.HasMoreThan(3))
            {
                yield return buffer.Dequeue();
            }
        }

        private static IEnumerable<Token> SquashTokens(IEnumerable<Token> buffer)
        {
            //Guard.That(buffer.HasFourIdentiqualTokens(), Is.True);

            TokenType type = buffer.First().Type;
            yield return new Token(type);
            yield return new Token(type + 1);
        }

        private static IEnumerable<Token> TransformToAdditiveForm(Queue<Token> buffer)
        {
            TokenType subType = buffer.Dequeue().Type;
            TokenType baseType = buffer.Dequeue().Type;

            //Guard.That(baseType, Is.GreaterThan(subType);

            switch (baseType - subType)
            {
                case 1:
                    break;

                case 2:
                    yield return new Token(baseType - 1);
                    break;

                default:
                    throw new InvalidOperationException($"The previous token ({subType}) must be one or two symbols lower than the token ({baseType})");
            }

            for (int i = 0; i < 4; i++)
            {
                yield return new Token(subType);
            }
        }
    }
}