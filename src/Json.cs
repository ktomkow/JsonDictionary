using System.Collections.Generic;

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
            return new Dictionary<string, Json>();
        }
    }
}
