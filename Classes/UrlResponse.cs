namespace ProjectForMunters.Classes
{
    public class UrlResponse : IUrl
    {
        public string Url { get; set; }
        public string AdditionalData { get; set; }

        public UrlResponse(string url, string additionalData)
        {
            Url = url;
            AdditionalData = additionalData;
        }
    }
}