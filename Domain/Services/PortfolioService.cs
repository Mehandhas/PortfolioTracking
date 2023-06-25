using Domain.Interfaces.ExternalServices;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Domain.Services
{
    public  class PortfolioService: IPortfolioService
    {
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly IMarketDataService _marketDataService;
        public PortfolioService(IPortfolioRepository portfolioRepository, IMarketDataService marketDataService)
        {
            _portfolioRepository = portfolioRepository;
            _marketDataService = marketDataService;
        }

        public async Task<Portfolio> GetPortfolios()
        {
            Portfolio portfolio =  _portfolioRepository.GetPortfolio();
            foreach (Position position in portfolio.Positions)
            {
                position.MarketPrice = await _marketDataService.GetMarketPrice(position.Symbol);
                position.ProfitLoss = Decimal.Round((position.MarketPrice - position.PurchasePrice) * position.Quantity, 2);
                position.PercentChange = Decimal.Round(position.ProfitLoss / (position.PurchasePrice * position.Quantity), 2);
            }
            portfolio.TotalProfitLoss = portfolio.Positions.Sum(p => p.ProfitLoss);
            portfolio.TotalPercentChange = portfolio.Positions.Sum(p => p.PercentChange);
            return portfolio;
        }
    }
}
