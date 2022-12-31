using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ProjectForMunters.Classes
{
    public class Gif : IUrl
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Slug { get; set; }
        public string Url { get; set; }

        [JsonProperty("trending_datetime")]
        public string TrendingDatetime { get; set; }
        [JsonProperty("Title")]
        public string AdditionalData { get; set; }

        [JsonExtensionData]
        public Dictionary<string, JToken> Data { get; set; } = new();

        public Gif(string id, string type, string slug, string url)
        {
            Id = id;
            Type = type;
            Slug = slug;
            Url = url;
        }
    }
}