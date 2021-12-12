using System.Collections.Generic;
using System.Linq;

namespace JsonDictionary
{
    public static class KeyFinder
    {
        public static IEnumerable<string> Find(this string json)
        {
            if(string.IsNullOrWhiteSpace(json) || (json.Contains(':') == false))
            {
                return Enumerable.Empty<string>();
            }

            var result = new List<string>();
            var starts = new List<int>();
            var ends = new List<int>();
            int nestLevel = -1;
            bool readingProperty = true;
            bool readingValue = false;
            bool started = false;
            bool isAfterFirstColon = false;

            int j = 0;

            for (int i = 0; i < json.Length; i++)
            {
                char analyzed = json[i];
                if(analyzed == '{')
                {
                    nestLevel++;
                    if(isAfterFirstColon)
                    {
                        readingProperty = false;
                        readingValue = true;
                    }
                }
                
                if (analyzed == '}')
                {
                    nestLevel--;
                    if(nestLevel == 0)
                    {
                        readingValue = false;
                    }
                }

                if(analyzed == ':')
                {
                    readingProperty = !readingProperty;
                    if (!isAfterFirstColon)
                    {
                        isAfterFirstColon = true;
                    }
                }

                if (nestLevel != 0)
                {
                    continue;
                }

                if (readingProperty == false && analyzed == ',' && readingValue == false)
                {
                    readingProperty = !readingProperty;
                }

                if(readingProperty)
                {
                    if (analyzed == '"')
                    {
                        if (started)
                        {
                            ends.Add(i);
                        }
                        else
                        {
                            starts.Add(i);
                        }

                        started = !started;
                    }
                }
                else
                {
                    if (analyzed == '"')
                    {
                        j++;
                        if(j == 2)
                        {
                            j = 0;
                            readingProperty = false;
                        }
                    }
                }

                if(analyzed == '"' && readingProperty == false)
                {
                    readingValue = !readingValue;
                }
            }

            for (int i = 0; i < starts.Count; i++)
            {
                result.Add(json.Substring(starts[i] + 1, ends[i] - starts[i] - 1));
            }

            return result;
        }
    }
}
