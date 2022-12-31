using Microsoft.AspNetCore.Mvc;
using ProjectForMunters.Classes;
using ProjectForMunters.Managers;

namespace ProjectForMunters.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class GiphyController : ControllerBase
    {
        private readonly IGiphyManager _giphyManager;

        public GiphyController(IGiphyManager giphyManager)
        {
            _giphyManager = giphyManager;
        }

        [HttpGet(Name = "GetTrendingGifsUrls")]
        public IEnumerable<IUrl> GetTrendingGifsUrls() =>
            _giphyManager.GetTrendingGifsUrlsOfDoday();

        [HttpGet(Name = "GetTrendingGifsUrlsOfSpecificDay")]
        public IEnumerable<IUrl> GetTrendingGifsUrlOfSpecificDay(DateTime date) =>
            _giphyManager.GetTrendingGifsUrlsOfSpecificDay(date);

        [HttpGet(Name = "GetGifByName")]
        public IEnumerable<IUrl> GetSearchGifsUrls(string searchInput) =>
            _giphyManager.GetGifsUrlsBySearch(searchInput);
    }
}