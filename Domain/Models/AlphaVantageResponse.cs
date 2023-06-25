using Newtonsoft.Json;

namespace Domain.Models
{
    public class AlphaVantageResponse
    {
        [JsonProperty(PropertyName = "Global Quote")]
        public GlobalQuote GlobalQuote { get; set; }
    }
}
