using System;
using System.Collections.Generic;
using System.Linq;
using Core.Katas.RomanCalculator.Lexica;

namespace Core.Katas.RomanCalculator
{
    internal static class Compacter
    {
        public static void Compact(ref IEnumerable<Token> tokens)
        {
            if (!tokens.HasMoreThan(1)) return;

            var compacted = new List<Token>();
            var buffer = new Queue<Token>(4);
            foreach (Token token in tokens)
            {
                buffer.Enqueue(token);

                if (buffer.HasFourIdentiqualTokens())
                {
                    compacted.AddRange(SquashTokens(buffer));
                    buffer.Clear();
                }
                else if (buffer.HasMoreThan(3)) compacted.Add(buffer.Dequeue());
            }

            compacted.AddRange(buffer);

            tokens = compacted.Where(t => t != null);
        }

        public static void Uncompact(ref IEnumerable<Token> tokens)
        {
            if (!tokens.HasMoreThan(1)) return;

            var uncompacted = new List<Token>();
            var buffer = new Queue<Token>(2);
            foreach (Token token in tokens)
            {
                buffer.Enqueue(token);

                if (buffer.IsSubstractiveForm())
                {
                    uncompacted.AddRange(TransformToAdditiveForm(buffer));
                    buffer.Clear();
                }
                else if (buffer.HasMoreThan(1)) uncompacted.Add(buffer.Dequeue());
            }

            uncompacted.AddRange(buffer);

            tokens = uncompacted.Where(t => t != null);
        }

        private static IEnumerable<Token> SquashTokens(Queue<Token> buffer)
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
