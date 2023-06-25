using Newtonsoft.Json;

namespace Domain.Models
{
    public class GlobalQuote
    {
        [JsonProperty(PropertyName = "05. price")]
        public string Price { get; set; }
    }
}
