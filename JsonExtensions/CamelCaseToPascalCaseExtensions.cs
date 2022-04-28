using Newtonsoft.Json.Linq;

namespace JsonExtensions
{
    public static class CamelCaseToPascalCaseExtensions
    {
        public static void Capitalize(this JArray jArr)
        {
            foreach (var x in jArr.ToList())
            {
                if (x is JObject childObj)
                {
                    childObj.Capitalize();
                    continue;
                }
                if (x is JArray childArr)
                {
                    childArr.Capitalize();
                }
            }
        }

        public static void Capitalize(this JObject jObj)
        {
            foreach (var kvp in jObj.Cast<KeyValuePair<string, JToken>>().ToList())
            {
                jObj.Remove(kvp.Key);
                var newKey = kvp.Key.Capitalize();
                if (kvp.Value is JObject childObj)
                {
                    childObj.Capitalize();
                    jObj.Add(newKey, childObj);
                    return;
                }

                if (kvp.Value is JArray childArr)
                {
                    childArr.Capitalize();
                    jObj.Add(newKey, childArr);
                    return;
                }
                jObj.Add(newKey, kvp.Value);
            }
        }

        public static string Capitalize(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException("empty string");
            }
            char[] arr = str.ToCharArray();
            arr[0] = char.ToUpper(arr[0]);
            return new string(arr);
        }
    }
}
