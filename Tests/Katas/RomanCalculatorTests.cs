using System.Collections.Generic;
using Core.Katas.RomanCalculator;
using Core.Katas.RomanCalculator.Lexica;
using NUnit.Framework;

namespace Tests.Katas
{
    internal class RomanCalculatorTests
    {
        [Test]
        [Category("Playground")]
        [Category("Dummy")]
        [Category("Transversal")]
        [TestCase("I", "I", "II")]
        [TestCase("I", "II", "III")]
        [TestCase("II", "II", "IV")]
        [TestCase("XIV", "LX", "LXXIV")]
        [TestCase("XX", "II", "XXII")]
        [TestCase("XI", "XI", "XXII")]
        [TestCase("D", "D", "M")]
        [TestCase("CCCLXIX", "DCCCXLV", "MCCXIV")]
        public void RomanCalculator_can_add_roman_numbers(string num1, string num2, string expectedResult)
        {
            var calculator = new RomanCalculator();
            string result = calculator.Add(num1, num2);

            Assert.That(result, Is.EqualTo(result));
        }

        [Test]
        [Category("Dummy")]
        [Category("Unitary")]
        [TestCase(TokenType.I, TokenType.V, "IIII")]
        [TestCase(TokenType.I, TokenType.X, "VIIII")]
        [TestCase(TokenType.X, TokenType.L, "XXXX")]
        [TestCase(TokenType.L, TokenType.X, "LX")]
        public void GetUncompactedToken_gets_uncompacted_token(TokenType tokenType, TokenType previousTokenType, string expectedRepresentation)
        {
            IEnumerable<Token> tokens = new Token[] { new Token(tokenType), new Token(previousTokenType) };
            Compacter.Uncompact(ref tokens);
            var printed = RomanCalculator.Print(tokens);
            Assert.That(printed, Is.EqualTo(expectedRepresentation));
        }
    }
}
