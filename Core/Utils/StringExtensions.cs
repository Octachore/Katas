using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utils
{
    public static class StringExtensions
    {
        public static string Repeat(this string str, int times) => string.Concat(Enumerable.Repeat(str, times));
    }
}
