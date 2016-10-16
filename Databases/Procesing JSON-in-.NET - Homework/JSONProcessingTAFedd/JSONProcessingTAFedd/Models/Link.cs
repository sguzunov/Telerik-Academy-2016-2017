using Newtonsoft.Json;

namespace JSONProcessingTAFedd.Models
{
    public class Link
    {
        [JsonProperty("@href")]
        public string Href { get; set; }

        [JsonProperty("@rel")]
        public string Rel { get; set; }
    }
}
