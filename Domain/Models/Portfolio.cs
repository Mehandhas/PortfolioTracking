using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Portfolio
    {
        public string Name { get; set; }
        public List<Position> Positions { get; set; }
        public decimal TotalProfitLoss { get; set; }
        public decimal TotalPercentChange { get; set; }
    }
}
