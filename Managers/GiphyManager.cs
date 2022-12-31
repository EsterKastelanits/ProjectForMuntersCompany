using Newtonsoft.Json;
using ProjectForMunters.Classes;

namespace ProjectForMunters.Managers
{
    public class GiphyManager : IGiphyManager
    {
        private const string ApiKey = "aFFKTuSMjd6j0wwjpFCPXZipQbcnw3vB";
        private const string Trending = "trending";
        private const string Search = "search";
        private const string GiphyClient = "GiphyClient";
        private const string RequestUrl = $"https://api.giphy.com/v1/gifs/";
        private const string NullDateTime = "0000-00-00 00:00:00";
        private readonly IHttpClientFactory _httpClientFactory;
        private Dictionary<string, List<UrlResponse>> Cache { get; set; } = new();

        public GiphyManager(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IEnumerable<IUrl> GetTrendingGifsUrlsOfDoday()
        {
            return GetTrendingGifsUrlsOfSpecificDay(DateTime.Today);
        }

        public IEnumerable<IUrl> GetTrendingGifsUrlsOfSpecificDay(DateTime date)
        {
            var httpResponse = CreateHttpRequest(RequestUrl + Trending + "?api_key=" + ApiKey);
            var gifs = GetGifsFromHttpResponse(httpResponse.Result).Result;
            return gifs.Where(gif => IsTodayGif(gif.TrendingDatetime, date)).Select(gif => new UrlResponse(gif.Url, gif.TrendingDatetime)).ToList();
        }

        public IEnumerable<IUrl> GetGifsUrlsBySearch(string inputForSearch)
        {
            if (Cache.TryGetValue(inputForSearch, out var value))
                return value;
            var httpResponse = CreateHttpRequest(RequestUrl + Search + "?api_key=" + ApiKey + "&q=" + inputForSearch.Replace(" ", "%"));
            var gifs = GetGifsFromHttpResponse(httpResponse.Result).Result;
            var urlResponses = gifs.Select(gif => new UrlResponse(gif.Url, gif.AdditionalData)).ToList();
            Cache.Add(inputForSearch, urlResponses);
            return urlResponses;
        }

        private async Task<HttpResponseMessage> CreateHttpRequest(string url)
        {
            using var client = _httpClientFactory.CreateClient(GiphyClient);
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await client.SendAsync(request);
            return response;
        }

        private async Task<List<Gif>> GetGifsFromHttpResponse(HttpResponseMessage httpResponseMessage)
        {
            var responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
            var jsonResponse = JsonConvert.DeserializeObject<JsonResponse>(responseContent);
            return jsonResponse is null ? new List<Gif>() :
                jsonResponse.GifsData;
        }

        private bool IsTodayGif(string trendingDatetime, DateTime dateTime) =>
            trendingDatetime != NullDateTime &&
            Convert.ToDateTime(trendingDatetime).Date.Equals(dateTime);
    }
}