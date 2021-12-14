using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JsonDictionary
{
    public class Json
    {
        private IDictionary<string, Json> values;

        public string Value { get; }

        public IEnumerable<string> Keys
        { 
            get
            {
                if(values is null)
                {
                    this.values = this.FindKeysAndValues();
                }

                return this.values.Keys;
            }
        }

        public Json this[string key]
        {
            get
            {
                if (this.values is null)
                {
                    this.values = this.FindKeysAndValues();
                }

                return this.values[key];
            }
        }

        public Json(string json)
        {
            this.Value = json;
        }

        private IDictionary<string, Json> FindKeysAndValues()
        {
            var result = new Dictionary<string, Json>();

            var keyBuilder = new StringBuilder();
            var valueBuilder = new StringBuilder();
            int nestLevel = 0;
            bool readingKey = false;
            bool keyRead = false;

            bool readingValue = false;
            bool valueRead = false;

            int kk = 0;
            bool possibleNull = false;

            foreach (char character in this.Value)
            {
                if (char.IsWhiteSpace(character)) continue;

                if (character == '{')
                {
                    nestLevel++;
                }

                if (nestLevel > 1)
                {
                    valueBuilder.Append(character);
                }

                if (character == '}')
                {
                    nestLevel--; 
                    if(nestLevel == 1)
                    {
                        valueRead = true;
                    }

                    if(nestLevel == 0)
                    {
                        if (readingValue && valueRead == false && keyRead)
                        {
                            string key = keyBuilder.ToString();
                            string value = valueBuilder.ToString();
                            if(possibleNull && (value == "null" || value == "undefined"))
                            {
                                value = "";
                            }

                            result[key] = new Json(value);
                            readingValue = false;
                            keyBuilder.Clear();
                            valueBuilder.Clear();
                            keyRead = false;
                            readingValue = false;
                            valueRead = false;
                            continue;
                        }
                    }
                }

                if (nestLevel > 1)
                {
                    continue;
                }

                if (character == '"' && readingKey == false && keyRead == false)
                {
                    readingKey = true;
                    continue;
                }

                if (character == '"' && readingKey == true && keyRead == false)
                {
                    keyRead = true;
                    readingKey = false;
                    continue;
                }

                if (character == '"' && keyRead && readingValue == false)
                {
                    possibleNull = false;
                    readingValue = true;
                    continue;
                }

                if (readingKey == false && keyRead == true && readingValue == false && valueRead == false && character == ':')
                {
                    kk = 1;
                    possibleNull = true;
                    readingValue = true;
                    continue;
                }

                if (valueRead || (character == '"' && keyRead && readingValue))
                {
                    if (possibleNull)
                    {
                        possibleNull = false;
                        continue;
                    }

                    string key = keyBuilder.ToString();
                    string value = valueBuilder.ToString();
                    result[key] = new Json(value);
                    readingValue = false;
                    keyBuilder.Clear();
                    valueBuilder.Clear();
                    keyRead = false;
                    readingValue = false;
                    valueRead = false;
                    continue;
                }

                if(readingKey)
                {
                    keyBuilder.Append(character);
                    continue;
                }

                if(readingValue)
                {
                    valueBuilder.Append(character);
                    continue;
                }


            }

            IDictionary<string, Json> r = result.Where(x => string.IsNullOrWhiteSpace(x.Key) == false).ToDictionary(x => x.Key, y => y.Value);
            return r;
        }
    }
}
