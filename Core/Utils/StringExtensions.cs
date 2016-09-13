using System.Linq;

namespace Core.Utils
{
    public static class StringExtensions
    {
        public static string Repeat(this string str, int times) => string.Concat(Enumerable.Repeat(str, times));
    }
}