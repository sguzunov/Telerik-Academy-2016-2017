using Newtonsoft.Json;

namespace JSONProcessingTAFedd.Models
{
    public class Video
    {
        [JsonProperty("yt:videoId")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("link")]
        public Link Link { get; set; }
    }
}
