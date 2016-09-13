using Core.Katas.RomanCalculator.Lexica;
using System.Collections.Generic;
using System.Linq;

namespace Core.Katas.RomanCalculator
{
    internal static class Combiner
    {
        public static void Combine(ref List<Token> tokens)
        {
            if (tokens.Count <= 1) return;

            List<Token> combined = DoCombine(tokens);

            while (combined.Count != tokens.Count)
            {
                combined = DoCombine(combined);
            }

            tokens = combined;
        }

        private static List<Token> DoCombine(List<Token> tokens)
        {
            var combined = new List<Token>();
            var buffer = new Queue<Token>(5);

            tokens.Reverse();

            foreach (Token token in tokens)
            {
                buffer.Enqueue(token);

                if (buffer.Count(t => t != null) != 5) continue;

                if (buffer.GroupBy(t => t.Type).Count() == 1)
                {
                    combined.Add(new Token(buffer.First().Type + 1));
                    buffer.Clear();
                }
                else
                {
                    combined.Add(buffer.First());
                }
            }

            combined.AddRange(buffer.Where(t => t != null));

            return combined;
        }
    }
}