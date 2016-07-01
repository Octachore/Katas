using System.Collections.Generic;

namespace Core.Utils
{
    internal static class Producer
    {
        public static IEnumerable<int> ProduceIntegers(int minValue, int maxValue)
        {
            for (int i = minValue; i <= maxValue; i++)
            {
                yield return i;
            }
        }
    }
}
