using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using System.Xml.Serialization;

namespace Infrastructure.Repositories
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly string _xmlFilePath = string.Empty;

        public PortfolioRepository(IConfiguration configuration)
        {
            _xmlFilePath = configuration.GetSection("XmlFilePath").Value;
        }
        public Portfolio GetPortfolio()
        {
            using (var fileStream = new FileStream(_xmlFilePath, FileMode.Open))
            {
                var serializer = new XmlSerializer(typeof(Portfolio));
                return (Portfolio)serializer.Deserialize(fileStream);
            }
        }
    }
}
