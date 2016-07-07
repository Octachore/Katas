using System.Collections.Generic;
using System.Linq;
using Core.Katas.RomanCalculator.Lexica;

namespace Core.Katas.RomanCalculator
{
    internal static class Combiner
    {
        public static void Combine(ref IEnumerable<Token> tokens)
        {
            if (tokens.Count() <= 1) return;

            IEnumerable<Token> combined = DoCombine(tokens);

            while (combined.Count() != tokens.Count())
            {
                combined = DoCombine(combined);
            }

            tokens = combined;
        }

        private static IEnumerable<Token> DoCombine(IEnumerable<Token> tokens)
        {
            List<Token> combined = new List<Token>();

            Queue<Token> buffer = new Queue<Token>(5);
            foreach (Token token in tokens.Reverse())
            {
                buffer.Enqueue(token);
                // replace each group of five symbols with the upper symbol (e.g.IIIII->V)
                if (buffer.Count(t => t != null) == 5)
                {
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
            }
            combined.AddRange(buffer.Where(t => t != null));
            return combined;
        }
    }
}
