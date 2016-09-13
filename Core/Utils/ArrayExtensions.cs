using System;
using System.Text;

namespace Core.Utils
{
    public static class ArrayExtensions
    {
        public static string Print<T>(this T[,] array)
        {
            var builder = new StringBuilder();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    builder.Append(array[i, j]);
                }
                builder.Append(Environment.NewLine);
            }
            return builder.ToString();
        }
    }
}