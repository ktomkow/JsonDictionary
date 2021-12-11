using System;

namespace JsonDictionary
{
    public static class Deserializer
    {
        public static string Take(this string json, string property)
        {
            if (string.IsNullOrWhiteSpace(property))
            {
                throw new ArgumentNullException(nameof(property));
            }

            return string.Empty;
        }
    }
}
