using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioTracking.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly IPortfolioService _portfolioService;
        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }
        public async Task<ActionResult> Index()
        {
            Portfolio portfolio = await _portfolioService.GetPortfolios();
            return View(portfolio);
        }
    }
}
