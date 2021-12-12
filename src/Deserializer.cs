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

            if(json.Contains(property))
            {
                int startIndex = json.IndexOf(property);
                string secondHalf = json.Substring(startIndex).Split(":")[1].Trim();                
                return secondHalf.Substring(0, secondHalf.Length - 1);
            }

            return string.Empty;
        }
    }
}
