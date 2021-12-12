using System.Collections.Generic;
using System.Linq;

namespace JsonDictionary.Tests
{
    public static class KeyFinder
    {
        public static IEnumerable<string> GetKeys(this string json)
        {
            return Enumerable.Empty<string>();
        }
    }
}
