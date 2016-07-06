using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Katas.RomanCalculator.Lexica;

namespace Core.Katas.RomanCalculator
{
    internal class RomanCalculator
    {
        internal string Add(string num1, string num2)
        {
            IEnumerable<Token> tokens1 = GetTokens(num1);
            IEnumerable<Token> tokens2 = GetTokens(num2);

            // Transform all subtractions in additions (e.g. IV -> IIII)
            Uncompact(ref tokens1);
            Uncompact(ref tokens2);

            // Join the two numbers
            IEnumerable<Token> tokens = tokens1.Union(tokens2);

            // Sort the symbols, the highest first
            Order(ref tokens);

            // Combine symbols from lower to highest
            Combine(ref tokens);

            // Transform additions in subtractions when possible (e.g. IIII -> IV)
            Compact(ref tokens);

            return Print(tokens);
        }

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

        public static void Compact(ref IEnumerable<Token> tokens)
        {
            if (tokens.Count() <= 1) return;
            tokens = GetCompactedTokens(tokens);
        }

        public static IEnumerable<Token> GetTokens(string num)
        {
            var lexer = new Lexer(num);
            Token token;
            while ((token = lexer.GetNextToken()) != null)
            {
                yield return token;
            }
        }

        public static IEnumerable<Token> GetUncompactedTokens(IEnumerable<Token> tokens)
        {
            Token previousToken = null;

            List<Token> list = tokens.ToList();

            for (int i = 0; i < list.Count; i++)
            {
                Token token = list[i];
                if (previousToken == null) previousToken = token;

                else if (previousToken.Type < token.Type)
                {
                    IEnumerable<Token> uncompackedToken = GetUncompactedToken(token, previousToken);

                    foreach (Token tokenComponent in uncompackedToken)
                    {
                        yield return tokenComponent;
                    }
                    i++;
                    continue;
                }

                else
                {
                    yield return previousToken;
                    if (i == list.Count - 1) yield return token;
                }

                previousToken = token;
            }
        }


        public static IEnumerable<Token> GetUncompactedToken(Token token, Token previousToken)
        {
            //Guard.That(token.Type, Is.GreaterThan(previousToken.Type);

            if (token.Type - 1 == previousToken.Type) // the previous token is the symbol just before the current token (e.g. IV, XL, DM?)
            {
                // get four times the previous token (e.g. IV -> IIII, XL ->XXXX)
                return new Token[]
                {
                    previousToken,
                    previousToken,
                    previousToken,
                    previousToken
                };
            }
            else if (token.Type - 2 == previousToken.Type) // the previous token is two symbols before the current token (e.g. IX, XC, CM)
            {
                // get once the -1 level token and four times the previousToken (e.g. IX -> VIIII, XC -> LXXXX)
                Token levelMinusoneToken = new Token(token.Type - 1);
                return new Token[]
                {
                    levelMinusoneToken,
                    previousToken,
                    previousToken,
                    previousToken,
                    previousToken
                };
            }

            throw new InvalidOperationException($"The previous token ({nameof(previousToken)}: {previousToken} must be one or two symbols lower than the token ({nameof(token)}: {token}");
        }

        public static IEnumerable<Token> GetCompactedTokens(IEnumerable<Token> tokens)
        {
            List<Token> compacted = new List<Token>();

            Queue<Token> buffer = new Queue<Token>(4);
            foreach (Token token in tokens.Reverse())
            {
                buffer.Enqueue(token);
                // replace each group of four symbols with the compacted form (e.g. IIII -> IV)
                if (buffer.Count(t => t != null) == 4)
                {
                    if (buffer.GroupBy(t => t.Type).Count() == 1)
                    {
                        compacted.Add(new Token(buffer.First().Type));
                        compacted.Add(new Token(buffer.First().Type + 1));
                        buffer.Clear();
                    }
                    else
                    {
                        compacted.Add(buffer.First());
                    }
                }
            }
            compacted.AddRange(buffer.Where(t => t != null));
            return compacted;
        }

        public static void Order(ref IEnumerable<Token> tokens)
        {
            tokens = tokens.OrderByDescending(t => t.Type);
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

        public static void Uncompact(ref IEnumerable<Token> tokens)
        {
            if (tokens.Count() <= 1) return;
            tokens = GetUncompactedTokens(tokens);
        }
    }
}
