using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ArdalisRating.Utils
{
    public static class Serializer
    {
        public static TResponse Deserialize<TResponse>(string json) where TResponse : class
        {
            var settings = new JsonSerializerSettings
            {
                Error = (object sender, ErrorEventArgs errorArgs) => errorArgs.ErrorContext.Handled = true
            };

            return JsonConvert.DeserializeObject<TResponse>(json, settings);
        }

        public static string Serialize<TObject>(TObject @object) where TObject : class
        {
            return JsonConvert.SerializeObject(@object);
        }
    }
}