using Core.Katas.RomanCalculator.Lexica;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Katas.RomanCalculator
{
    internal class RomanCalculator
    {
        internal string Add(string num1, string num2)
        {
            List<Token> tokens1 = Tokenize(num1).ToList();
            List<Token> tokens2 = Tokenize(num2).ToList();

            // Transform all subtractions in additions (e.g. IV -> IIII)
            Compacter.Uncompact(ref tokens1);
            Compacter.Uncompact(ref tokens2);

            // Join the two numbers
            List<Token> tokens = tokens1.Union(tokens2).ToList();

            // Sort the symbols, the highest first
            tokens = tokens.OrderByDescending(t => t.Type).ToList();

            // Combine symbols from lower to highest
            Combiner.Combine(ref tokens);

            // Transform additions in subtractions when possible (e.g. IIII -> IV)
            Compacter.Compact(ref tokens);

            return Print(tokens);
        }

        public static IEnumerable<Token> Tokenize(string num)
        {
            var lexer = new Lexer(num);
            Token token;
            while ((token = lexer.GetNextToken()) != null)
            {
                yield return token;
            }
        }

        public static string Print(IEnumerable<Token> tokens)
        {
            var builder = new StringBuilder();
            foreach (Token token in tokens)
            {
                builder.Append(token);
            }
            return builder.ToString();
        }
    }
}