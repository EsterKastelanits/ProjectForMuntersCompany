using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ProjectForMunters.Classes
{
    public class JsonResponse
    {
        [JsonProperty("Data")] 
        public List<Gif> GifsData { get; set; }

        [JsonExtensionData]
        public Dictionary<string, JToken> Data { get; set; } = new();

        public JsonResponse(List<Gif> gifsData)
        {
            GifsData = gifsData;
        }
    }
}
