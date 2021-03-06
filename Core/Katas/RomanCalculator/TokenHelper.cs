﻿using Core.Katas.RomanCalculator.Lexica;
using System.Collections.Generic;
using System.Linq;

namespace Core.Katas.RomanCalculator
{
    internal static class TokenHelper
    {
        public static bool HasFourIdentiqualTokens(this Queue<Token> buffer) => !buffer.GroupBy(t => t.Type).HasMoreThan(1);

        public static bool IsSubstractiveForm(this Queue<Token> buffer)
        {
            if (!buffer.Skip(1).Any()) return false;
            if (buffer.Skip(3).Any()) return false;

            return buffer.First().Type < buffer.Last().Type;
        }
    }
}