using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace ArdalisRating.Utils
{
    public static class Serializer
    {
        public static TResponse Deserialize<TResponse>(string json) where TResponse : class
        {
            return JsonConvert.DeserializeObject<TResponse>(json, converters: new StringEnumConverter());
        }

        public static string Serialize<TObject>(TObject @object) where TObject : class
        {
            return JsonConvert.SerializeObject(@object);
        }
    }
}