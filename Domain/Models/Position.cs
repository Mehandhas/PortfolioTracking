using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Position
    {
        public string Symbol { get; set; }
        public decimal PurchasePrice { get; set; }
        public int Quantity { get; set; }
        public decimal MarketPrice { get; set; }
        public decimal ProfitLoss { get; set; }
        public decimal PercentChange { get; set; }
    }
}
