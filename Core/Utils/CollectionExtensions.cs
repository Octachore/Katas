using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Utils
{
    internal static class CollectionExtensions
    {
        public static T PickRandom<T>(this ICollection<T> collection)
        {
            int i = new Random().Next(collection.Count - 1);
            return collection.ElementAt(i);
        }
    }
}
