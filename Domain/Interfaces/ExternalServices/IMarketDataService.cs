
namespace Domain.Interfaces.ExternalServices
{
    public interface IMarketDataService
    {
        Task<decimal> GetMarketPrice(string symbol);
    }
}
