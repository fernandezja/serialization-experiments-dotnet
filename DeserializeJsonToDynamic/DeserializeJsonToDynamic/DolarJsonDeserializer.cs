using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DeserializeJsonToDynamic
{
    public static class DolarJsonDeserializer
    {
        public static JObject ParseDynamic(string json)
        {
            return JObject.Parse(json);
        }

        public static DolarViewModel Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<DolarViewModel>(json);
        }
    }
}
