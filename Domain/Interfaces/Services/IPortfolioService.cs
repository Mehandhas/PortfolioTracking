﻿using Domain.Models;
namespace Domain.Interfaces.Services
{
    public interface IPortfolioService
    {
        Task<Portfolio> GetPortfolios();
    }
}
