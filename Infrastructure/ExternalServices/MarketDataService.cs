using Domain.Interfaces.ExternalServices;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Infrastructure.ExternalServices
{
    public class MarketDataService: IMarketDataService
    {
        private readonly string _apiKey = string.Empty;
        private readonly string _alphaVantageUrl = string.Empty;
        private readonly HttpClient _httpClient = new HttpClient();

        public MarketDataService(IConfiguration configuration)
        {
            _apiKey = configuration.GetSection("ApiKey").Value;
            _alphaVantageUrl = configuration.GetSection("AlphaVantageUrl").Value;
        }
        public async Task<decimal> GetMarketPrice(string symbol)
        {
                var queryParams = $"function=GLOBAL_QUOTE&symbol={symbol}&apikey={_apiKey}";
                var response = await _httpClient.GetAsync($"{_alphaVantageUrl}?{queryParams}");
                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<AlphaVantageResponse>(response.Content.ReadAsStringAsync().Result);
                    return Convert.ToDecimal(result?.GlobalQuote?.Price);
                }
            return 0;
        }
    }
}
