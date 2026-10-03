#nullable enable
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DeserializeJsonToListT
{
    public static class ClienteJsonDeserializer
    {
        public static List<Cliente>? Deserialize(string json)
        {
            var settings = new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
            };

            return JsonConvert.DeserializeObject<List<Cliente>>(json, settings);
        }
    }
}
