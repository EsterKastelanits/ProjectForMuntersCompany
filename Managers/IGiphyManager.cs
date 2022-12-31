using ProjectForMunters.Classes;

namespace ProjectForMunters.Managers
{
    public interface IGiphyManager
    {
        IEnumerable<IUrl> GetTrendingGifsUrlsOfDoday();
        IEnumerable<IUrl> GetTrendingGifsUrlsOfSpecificDay(DateTime date);
        IEnumerable<IUrl> GetGifsUrlsBySearch(string inputForSearch);
    }
}
