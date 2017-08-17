using System.Collections.Generic;
using System.Linq;

namespace Seedling.Readability
{
    public static class DictionaryExtension
    {
        public static Dictionary<TKey, TValue> Combine<TKey, TValue>(this Dictionary<TKey, TValue> source,
            Dictionary<TKey, TValue> appendix)
        {
            return source
                .Concat(appendix)
                .ToDictionary(pair => pair.Key, pair => pair.Value);
        }
    }
}